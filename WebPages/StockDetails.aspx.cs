using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPages_StockDetails : System.Web.UI.Page
{
    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null && Session["UserName"] != null)
        {
            UserId = Int32.Parse(Session["UserId"].ToString());
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
        if (!IsPostBack)
        {
            connstring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            con = new SqlConnection(connstring);
            ddlbind();
            gvbind();
        }

    }
    protected void Stock_Save_Click(object sender, EventArgs e)
    {
        try
        {

            SqlCommand objcmd = new SqlCommand("USP_StockMaster", con);
            objcmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
            //Ad_Id1.Value = Text_Id.Text;

            SqlParameter Prod_Id1 = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
            Prod_Id1.Value = Prod_Id.Text;
 
            SqlParameter Prod_Quantity1 = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
            Prod_Quantity1.Value = Quantity.Text;
            SqlParameter Prod_Rate1 = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.SmallInt);
            Prod_Rate1.Value = Rate.Text;



            SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

            objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            if (flag == 2)
            {
                flag1.Value = 'V';
                SqlParameter Stock_Id1 = objcmd.Parameters.Add("@Stock_Id", SqlDbType.SmallInt);
                Stock_Id1.Value = Stock_Id.Text;
            }
            else
                flag1.Value = 'I';

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                objcmd.ExecuteNonQuery();
                string id = objcmd.Parameters["@id"].Value.ToString();
                Stcok_Status.Visible = true;
                Stcok_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                Stcok_Status.ForeColor = System.Drawing.Color.Green;
                //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                // gvbind();

            }
            catch (Exception eee)
            {
                Stcok_Status.Visible = true;
                Stcok_Status.Text = eee.Message;
                string id = objcmd.Parameters["@id"].Value.ToString();
                Stcok_Status.Text = "Record Already Exists .";
                Stcok_Status.ForeColor = System.Drawing.Color.Red;

            }
            finally
            {
                con.Close();
            }

        }
        catch
        {
            Stcok_Status.Text = "Record Already Exists .";
        }
   

    }

    protected void ddlbind()
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

    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_StockMaster", con);
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
           Stock_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
         
            Prod_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
           Quantity.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
            Rate.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
              //btn_Register.Text = "Update";
        }
        catch { }
    
    }
}