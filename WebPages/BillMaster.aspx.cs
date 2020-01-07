using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPages_BillMaster : System.Web.UI.Page
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
            gvbind();

        }
    }

    protected void Bill_Save_Click(object sender, EventArgs e)
    {
        try
        {

            SqlCommand objcmd = new SqlCommand("USP_BillTransaction", con);
            objcmd.CommandType = CommandType.StoredProcedure;

          
            SqlParameter Cust_Id1 = objcmd.Parameters.Add("@Cust_Id", SqlDbType.SmallInt);
            Cust_Id1.Value = Cust_Id.Text;

          //  SqlParameter Bill_Date1 = objcmd.Parameters.Add("@Bill_Date", SqlDbType.Date);
            //Bill_Date1.Value = Bill_Date.Text;

            SqlParameter Bill_TotAmt1 = objcmd.Parameters.Add("@Bill_TotAmt", SqlDbType.Float);
            Bill_TotAmt1.Value = Bill_TotAmt.Text;

            SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

            objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            if (flag == 2)
            {
                flag1.Value = 'V';
                SqlParameter Bill_Id1 = objcmd.Parameters.Add("@Bill_Id", SqlDbType.SmallInt);
                Bill_Id1.Value = Bill_Id.Text;
            }
            else
                flag1.Value = 'I';

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                objcmd.ExecuteNonQuery();
                string id = objcmd.Parameters["@id"].Value.ToString();
                Bill_Status.Visible = true;
                Bill_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                Bill_Status.ForeColor = System.Drawing.Color.Green;
                //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                // gvbind();

            }
            catch (Exception eee)
            {
                Bill_Status.Visible = true;
                Bill_Status.Text = eee.Message;
                string id = objcmd.Parameters["@id"].Value.ToString();
                Bill_Status.Text = "Record Already Exists .";
                Bill_Status.ForeColor = System.Drawing.Color.Red;

            }
            finally
            {
                con.Close();
            }

        }
        catch
        {
            Bill_Status.Text = "Record Already Exists .";
        }
   
    }
    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_BillMaster", con);
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

    protected void ddlbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_CustomerMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Bill_Status1 = cmd.Parameters.Add("@Bill_Status", SqlDbType.VarChar);
            Bill_Status1.Value = 0;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");

            if (ds.Tables["TT"].Rows.Count > 0)
            {
                Cust_Id.DataSource = ds.Tables["TT"];
                Cust_Id.DataTextField = "Cust_Name";
                Cust_Id.DataValueField = "Cust_Id";
                Cust_Id.DataBind();
            }
        }
        catch { }
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
            Bill_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
        
            Cust_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
       //     Bill_Date.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
           Bill_TotAmt.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
            //btn_Register.Text = "Update";
        }
        catch { }
    }
}