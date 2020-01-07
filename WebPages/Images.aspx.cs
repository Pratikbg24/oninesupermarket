using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class WebPages_Images : System.Web.UI.Page
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
            ddlbind();
            gvbind();
        }

    }
    protected void Image_Upload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != null)
        {
            string FileName = FileUpload1.PostedFile.FileName;
            FileUpload1.SaveAs(Server.MapPath("../Images/" + FileName));
            Img_Path.Text = "../Images/" + FileName;


        }
    }
    protected void Image_Save_Click(object sender, EventArgs e)
    {

        try
        {

            SqlCommand objcmd = new SqlCommand("USP_ImageMaster", con);
            objcmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
            //Ad_Id1.Value = Text_Id.Text;


            SqlParameter Prod_Id1 = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
            Prod_Id1.Value = Prod_Id.Text;

            SqlParameter Img_Path1 = objcmd.Parameters.Add("@Img_Path", SqlDbType.NVarChar);
            Img_Path1.Value = Img_Path.Text;


            SqlParameter Img_Status1 = objcmd.Parameters.Add("@Img_Status", SqlDbType.SmallInt);
            Img_Status1.Value = 1;


            SqlParameter DelBoy_UserId = objcmd.Parameters.Add("@Img_UserId", SqlDbType.SmallInt);
            DelBoy_UserId.Value = UserId;


            SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

            objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            if (flag == 2)
            {
                flag1.Value = 'U';
                SqlParameter Img_Id1 = objcmd.Parameters.Add("@Img_Id", SqlDbType.SmallInt);
                Img_Id1.Value = Img_Id.Text;
            }
            else
                flag1.Value = 'I';

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                objcmd.ExecuteNonQuery();
                string id = objcmd.Parameters["@id"].Value.ToString();
                lbl_Status.Visible = true;
                lbl_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                lbl_Status.ForeColor = System.Drawing.Color.Green;
                //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                 gvbind();

            }
            catch (Exception eee)
            {
                lbl_Status.Visible = true;
                lbl_Status.Text = eee.Message;
                string id = objcmd.Parameters["@id"].Value.ToString();
                lbl_Status.Text = "Record Already Exists .";
                lbl_Status.ForeColor = System.Drawing.Color.Red;

            }
            finally
            {
                con.Close();
            }

        }
        catch
        {
            lbl_Status.Text = "Record Already Exists .";
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
            Prod_Status.Value = 1;

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
            SqlCommand cmd = new SqlCommand("USP_ImageMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Img_Status1 = cmd.Parameters.Add("@Img_Status", SqlDbType.SmallInt);
            Img_Status1.Value = 1;
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
        SqlCommand objcmd = new SqlCommand("USP_ImageMaster", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlParameter Img_Id1 = objcmd.Parameters.Add("@Img_Id", SqlDbType.SmallInt);
        Img_Id1.Value = gv_movimage.DataKeys[e.RowIndex].Value.ToString();

        SqlParameter Img_Status1 = objcmd.Parameters.Add("@Img_Status", SqlDbType.SmallInt);
        Img_Status1.Value = 0;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        flag1.Value = 'D';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            lbl_Status.Visible = true;
            lbl_Status.Text = "Delete Successful.";// Your User Id=" + id ;
            lbl_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
            gvbind();

        }
        catch (Exception eee)
        {
            lbl_Status.Visible = true;
            lbl_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            lbl_Status.Text = "Record Already Exists .";
            lbl_Status.ForeColor = System.Drawing.Color.Red;

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

            Img_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;

            Prod_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
           Img_Path.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;

            Image_Save.Text = "Update";
        }
        catch { }
    

    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        try
        {
            flag = 1;
            Img_Id.Text = "";
            Prod_Id.SelectedIndex = -1;
            Img_Path.Text = "";
            Image_Save.Text = "Save";
        }
        catch
        {


        }
    }
}
