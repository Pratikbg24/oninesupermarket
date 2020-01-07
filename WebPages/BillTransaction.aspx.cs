using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class WebPages_BillTransaction : System.Web.UI.Page
{

    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            connstring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            con = new SqlConnection(connstring);
            ddlbind();
            ddlbind1();
            ddlbind2();
            gvbind();
        }
    
    }
    protected void Prod_Save_Click(object sender, EventArgs e)
    {
            try
        {
     
                    SqlCommand objcmd = new SqlCommand("USP_BillTransaction", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter Bill_Id1 = objcmd.Parameters.Add("@Bill_Id", SqlDbType.SmallInt);
                    Bill_Id1.Value = Bill_Id.Text;

                    SqlParameter Prod_Id1 = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
                    Prod_Id1.Value = Prod_Id.Text;

                    SqlParameter Unit_Id1 = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
                    Unit_Id1.Value = Unit_Id.Text;

                    SqlParameter Prod_Quantity1 = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
                    Prod_Quantity1.Value = Prod_Quantity.Text;

                    SqlParameter Prod_Rate1 = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.Float);
                    Prod_Rate1.Value = Prod_Rate.Text;

                    SqlParameter Prod_Total1 = objcmd.Parameters.Add("@BillT_Total", SqlDbType.Float);
                    Prod_Total1.Value = BillT_Total.Text;

                    SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

                    objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    if (flag == 2)
                    {
                        flag1.Value = 'V';
                        SqlParameter BillT_Id1 = objcmd.Parameters.Add("@BillT_Id", SqlDbType.SmallInt);
                        BillT_Id1.Value = BillT_Id.Text;
                    }
                    else
                        flag1.Value = 'I';

                    try
                    {
                           if(con.State== ConnectionState.Closed)
                        con.Open();
                        objcmd.ExecuteNonQuery();
                        string id = objcmd.Parameters["@id"].Value.ToString();
                        Prod_Status.Visible = true;
                        Prod_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                        Prod_Status.ForeColor = System.Drawing.Color.Green;
                        //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                        // gvbind();

                    }
                    catch (Exception eee)
                    {
                        Prod_Status.Visible = true;
                        Prod_Status.Text = eee.Message;
                        string id = objcmd.Parameters["@id"].Value.ToString();
                        Prod_Status.Text = "Record Already Exists .";
                        Prod_Status.ForeColor = System.Drawing.Color.Red;

                     }
                    finally
                    {
                        con.Close();
                    }
                       
                }
             catch
            {
                Prod_Status.Text = "Record Already Exists .";
             }
   
    
    
    }

    protected void ddlbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_BillMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Bill_Status1 = cmd.Parameters.Add("@BillT_Status", SqlDbType.VarChar);
            Bill_Status1.Value = 0;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");

            if (ds.Tables["TT"].Rows.Count > 0)
            {
                Bill_Id.DataSource = ds.Tables["TT"];
                Bill_Id.DataTextField = "Bill_Id";
                Bill_Id.DataValueField = "Bill_Id";
                Bill_Id.DataBind();
            }
        }
        catch { }
    }

    protected void ddlbind1()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Prod_Status = cmd.Parameters.Add("@Prod_Status", SqlDbType.VarChar);
            Prod_Status.Value = 0;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");

            if (ds.Tables["TT"].Rows.Count > 0)
            {
                Prod_Id.DataSource = ds.Tables["TT"];
                Prod_Id.DataTextField = "Prod_Name";
                Prod_Id.DataValueField = "Prod_Id";
                Prod_Id.DataBind();
            }
        }
        catch { }
    }

    protected void ddlbind2()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_UnitMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Unit_Status1 = cmd.Parameters.Add("@Unit_Status", SqlDbType.VarChar);
            Unit_Status1.Value = 0;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");

            if (ds.Tables["TT"].Rows.Count > 0)
            {
                Unit_Id.DataSource = ds.Tables["TT"];
                Unit_Id.DataTextField = "Unit_Name";
                Unit_Id.DataValueField = "Unit_Id";
                Unit_Id.DataBind();
            }
        }
        catch { }
    }
    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_BillTransaction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new System.Data.DataSet("TT");
            da.Fill(ds, "TT");
            if (ds.Tables["TT"].Rows.Count > 0)
            {
                gv_movimage.DataSource = ds;
                gv_movimage.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gv_movimage.DataSource = ds;
                gv_movimage.DataBind();
                int columncount = gv_movimage.Rows[0].Cells.Count;
                gv_movimage.Rows[0].Cells.Clear();
                gv_movimage.Rows[0].Cells.Add(new TableCell());
                gv_movimage.Rows[0].Cells[0].ColumnSpan = columncount;
                gv_movimage.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch (Exception ee) { }

    }

    protected void gv_movimage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gv_movimage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void gv_movimage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_movimage_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gv_movimage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gv_movimage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            flag = 2;
            BillT_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
            Bill_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
          
            Prod_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
            Unit_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
            Prod_Quantity.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[4].Text;
            Prod_Rate.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[5].Text;
            BillT_Total.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[6].Text;
            //btn_Register.Text = "Update";
        }
        catch { }
    
    }
}