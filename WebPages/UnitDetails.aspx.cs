using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPages_UnitDetails : System.Web.UI.Page
{
    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag=1;


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
            gvbind();
        }

    }
    protected void Unit_Save_Click(object sender, EventArgs e)
    {
        SqlCommand objcmd = new SqlCommand("USP_UnitMaster", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
        //Ad_Id1.Value = Text_Id.Text;

        SqlParameter Unit_Name1 = objcmd.Parameters.Add("@Unit_Name", SqlDbType.NVarChar);
        Unit_Name1.Value = Unit_Name.Text;

        SqlParameter Unit_Status1 = objcmd.Parameters.Add("@Unit_Status", SqlDbType.SmallInt);
        Unit_Status1.Value = 1;

        SqlParameter BillT_UserId = objcmd.Parameters.Add("@Unit_UserId", SqlDbType.SmallInt);
        BillT_UserId.Value = UserId;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        if (flag == 2)
        {
            flag1.Value = 'U';
            SqlParameter Unit_Id1 = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
            Unit_Id1.Value = Unit_Id.Text;
        }
        else
            flag1.Value = 'I';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            Unit_Status.Visible = true;
            Unit_Status.Text = "Registration Successful.";// Your User Id=" + id ;
            Unit_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
             gvbind();

        }
        catch (Exception eee)
        {
            Unit_Status.Visible = true;
            Unit_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            Unit_Status.Text = "Record Already Exists .";
            Unit_Status.ForeColor = System.Drawing.Color.Red;

        }
        finally
        {
            con.Close();
        }
    }
    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_UnitMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter Unit_Status1 = cmd.Parameters.Add("@Unit_Status", SqlDbType.SmallInt);
            Unit_Status1.Value = 1;

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
    protected void gv_movimage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gv_movimage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void gv_movimage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        SqlCommand objcmd = new SqlCommand("USP_UnitMaster", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlParameter Unit_Id1 = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
        Unit_Id1.Value = gv_movimage.DataKeys[e.RowIndex].Value.ToString();

        SqlParameter Unit_Status1 = objcmd.Parameters.Add("@Unit_Status", SqlDbType.SmallInt);
        Unit_Status1.Value = 0;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        flag1.Value = 'D';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            Unit_Status.Visible = true;
            Unit_Status.Text = "Delete Successful.";// Your User Id=" + id ;
            Unit_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
            gvbind();

        }
        catch (Exception eee)
        {
            Unit_Status.Visible = true;
            Unit_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            Unit_Status.Text = "Record Already Exists .";
            Unit_Status.ForeColor = System.Drawing.Color.Red;


        }
        finally
        {
            con.Close();
        }
   
   
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

            Unit_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
            Unit_Name.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
            Unit_Save.Text = "Update";
        }
        catch { }
    

    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        try
        {
            flag = 1;
            Unit_Id.Text = "";
             Unit_Name.Text = "";

            Unit_Save.Text = "Save";
        }
        catch
        {


        }
    }
}