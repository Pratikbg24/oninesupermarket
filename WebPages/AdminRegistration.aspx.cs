using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class WebPages_AdminRegistration : System.Web.UI.Page
    {
        static SqlConnection con;
        static string connstring;
        DataSet ds;
        static string user_Name;
        static int UserId;
        static int flag=1;


    protected void Page_Load(object sender, EventArgs e)
    {
       


        if (!IsPostBack)
        {
            connstring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            con = new SqlConnection(connstring);
            gvbind();
        }

    }
    protected void Ad_Save_Click(object sender, EventArgs e)
    {
        string new_sub = Text_Name.Text;
        string new_sub2 = Text_MobileNo.Text;
        string new_sub1 = Text_Password.Text;
        string new_sub3 = Text_Email.Text;
        string prev_sub2 = null;
        string prev_sub3 = null;
      
        string prev_sub1 = null;
        string prev_sub = null;
        bool contain = false;

        if (gv_movimage.Rows.Count > 0)
        {
            for (int i = 0; i < gv_movimage.Rows.Count; i++)
            {
                try
                {
                    prev_sub = gv_movimage.Rows[i].Cells[1].Text;
                    prev_sub1 = gv_movimage.Rows[i].Cells[2].Text;
                    prev_sub2 = gv_movimage.Rows[i].Cells[3].Text;
                    prev_sub3 = gv_movimage.Rows[i].Cells[4].Text;
       
                }
                catch { }
                if (new_sub == prev_sub || new_sub1 == prev_sub1 || new_sub2 == prev_sub2 || new_sub3 == prev_sub3)
                {
                    contain = true;
                    break;
                }
               
            }
        }
        if (contain == true)
        {
            Ad_Status.Text = "Record Already Exists.";
            Ad_Status.ForeColor = System.Drawing.Color.Red;

        }
        else {



            if (IsValid)
            {
                //if (Text_Name.Text != "")
                //{
                SqlCommand objcmd = new SqlCommand("USP_AdminLogin", con);
                objcmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
                //Ad_Id1.Value = Text_Id.Text;

                SqlParameter Ad_Name1 = objcmd.Parameters.Add("@Ad_Name", SqlDbType.NVarChar);
                Ad_Name1.Value = Text_Name.Text;

                SqlParameter Ad_Password1 = objcmd.Parameters.Add("@Ad_Password", SqlDbType.NVarChar);
                Ad_Password1.Value = Text_Password.Text;

                SqlParameter Mobno1 = objcmd.Parameters.Add("@Ad_Mobno", SqlDbType.BigInt);
                Mobno1.Value = Text_MobileNo.Text;

                SqlParameter Ad_Email1 = objcmd.Parameters.Add("@Ad_Email", SqlDbType.NVarChar);
                Ad_Email1.Value = Text_Email.Text;

                SqlParameter Ad_Status1 = objcmd.Parameters.Add("@Ad_Status", SqlDbType.SmallInt);
                Ad_Status1.Value = 1;

                SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

                objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                if (flag == 2)
                {
                    flag1.Value = 'U';
                    SqlParameter Ad_Id = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
                    Ad_Id.Value = Text_Id.Text;
                }
                else
                    flag1.Value = 'I';

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();
                    string id = objcmd.Parameters["@id"].Value.ToString();
                    Ad_Status.Visible = true;
                    Ad_Status.Text = "Registration Successful. Your User Id=" + id;
                    Ad_Status.ForeColor = System.Drawing.Color.Green;
                    //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                    gvbind();

                }
                catch (Exception eee)
                {
                    Ad_Status.Visible = true;
                    Ad_Status.Text = eee.Message;
                    Ad_Status.Text = "Record Already Exists .";
                    Ad_Status.ForeColor = System.Drawing.Color.Red;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        //}
    }
    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_AdminLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';
            SqlParameter Ad_Status1 = cmd.Parameters.Add("@Ad_Status", SqlDbType.SmallInt);
            Ad_Status1.Value = 1;


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

    protected void Ad_Update_Click(object sender, EventArgs e)
    {

    }
    protected void gv_movimage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlCommand objcmd = new SqlCommand("USP_AdminLogin", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
        Ad_Id1.Value = gv_movimage.DataKeys[e.RowIndex].Value.ToString();

        SqlParameter Ad_Status1 = objcmd.Parameters.Add("@Ad_Status", SqlDbType.SmallInt);
        Ad_Status1.Value =0;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            flag1.Value = 'D';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            Ad_Status.Visible = true;
            Ad_Status.Text = "Delete Successful.";// Your User Id=" + id ;
            Ad_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
            gvbind();

        }
        catch (Exception eee)
        {
            Ad_Status.Visible = true;
            Ad_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            Ad_Status.Text = "Record Already Exists .";
            Ad_Status.ForeColor = System.Drawing.Color.Red;

        }
        finally
        {
            con.Close();
        }
   
    }
    protected void gv_movimage_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gv_movimage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void gv_movimage_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

            Text_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
            Text_Name.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
            Text_Password.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
            Text_MobileNo.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
           Text_Email.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[4].Text;
            Ad_Save.Text = "Update";
        }
        catch { }
    

    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        try
        {
            flag = 1;
            Text_Id.Text = "";
            Text_Name.Text = "";
            Text_MobileNo.Text = "";
            Text_Email.Text = "";
            Text_Password.Text = "";
            Ad_Save.Text = "Save";
        }
        catch
        {


        }
    }
}