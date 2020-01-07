using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class WebPages_DelBoyDetails : System.Web.UI.Page
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
    protected void DelBoy_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand objcmd = new SqlCommand("USP_DelBoy", con);
            objcmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
            //Ad_Id1.Value = Text_Id.Text;

            SqlParameter DelBoy_Name1 = objcmd.Parameters.Add("@DelBoy_Name", SqlDbType.NVarChar);
            DelBoy_Name1.Value = DelBoy_Name.Text;

            SqlParameter DelBoy_Addr1 = objcmd.Parameters.Add("@DelBoy_Addr", SqlDbType.NVarChar);
            DelBoy_Addr1.Value = DelBoy_Addr.Text;

            SqlParameter Mobno1 = objcmd.Parameters.Add("@DelBoy_MobNo", SqlDbType.BigInt);
            Mobno1.Value = DelBoy_MobNo.Text;

            SqlParameter DelBoy_Email1 = objcmd.Parameters.Add("@DelBoy_Email", SqlDbType.NVarChar);
            DelBoy_Email1.Value = DelBoy_Email.Text;

            SqlParameter DelBoy_Status1 = objcmd.Parameters.Add("@DelBoy_Status", SqlDbType.SmallInt);
            DelBoy_Status1.Value = 1;


            SqlParameter DelBoy_UserId = objcmd.Parameters.Add("@DelBoy_UserId", SqlDbType.SmallInt);
            DelBoy_UserId.Value = UserId;



            SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

            objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            if (flag == 2)
            {
                flag1.Value = 'U';
                SqlParameter Cust_Id1 = objcmd.Parameters.Add("@DelBoy_Id", SqlDbType.SmallInt);
                Cust_Id1.Value = DelBoy_Id.Text;
            }
            else
                flag1.Value = 'I';

            try
            {   
                if(con.State== ConnectionState.Closed)
                con.Open();
                objcmd.ExecuteNonQuery();
                string id = objcmd.Parameters["@id"].Value.ToString();
                DelBoy_Status.Visible = true;
                DelBoy_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                DelBoy_Status.ForeColor = System.Drawing.Color.Green;
                //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                gvbind();

            }
            catch (Exception eee)
            {
                DelBoy_Status.Visible = true;
                DelBoy_Status.Text = eee.Message;
                string id = objcmd.Parameters["@id"].Value.ToString();
                DelBoy_Status.Text = "Record Already Exists .";
                DelBoy_Status.ForeColor = System.Drawing.Color.Red;

            }
            finally
            {
                con.Close();
            }
   
        }
        catch
        {
            DelBoy_Status.Text = "Record Already Exists .";
        }

    }

    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_DelBoy", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter DelBoy_Status1 = cmd.Parameters.Add("@DelBoy_Status", SqlDbType.SmallInt);
            DelBoy_Status1.Value = 1;

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
        SqlCommand objcmd = new SqlCommand("USP_DelBoy", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlParameter DelBoy_Id1 = objcmd.Parameters.Add("@DelBoy_Id", SqlDbType.SmallInt);
        DelBoy_Id1.Value = gv_movimage.DataKeys[e.RowIndex].Value.ToString();

        SqlParameter DelBoy_Status1 = objcmd.Parameters.Add("@DelBoy_Status", SqlDbType.SmallInt);
        DelBoy_Status1.Value = 0;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        flag1.Value = 'D';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            DelBoy_Status.Visible = true;
            DelBoy_Status.Text = "Delete Successful.";// Your User Id=" + id ;
            DelBoy_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
            gvbind();

        }
        catch (Exception eee)
        {
            DelBoy_Status.Visible = true;
            DelBoy_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            DelBoy_Status.Text = "Record Already Exists .";
            DelBoy_Status.ForeColor = System.Drawing.Color.Red;

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

            DelBoy_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
            DelBoy_Name.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
            
            DelBoy_MobNo.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
       
            DelBoy_Email.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
            DelBoy_Addr.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[4].Text;
       
            DelBoy_Save.Text = "Update";
        }
        catch { }
    
    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        try
        {
            flag = 1;
            DelBoy_Id.Text = "";
            DelBoy_Name.Text = "";
            DelBoy_MobNo.Text = "";
            DelBoy_Email.Text = "";
            DelBoy_Addr.Text = "";
            DelBoy_Save.Text = "Save";
        }
        catch
        {


        }
    }
}