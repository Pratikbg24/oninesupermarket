using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class WebPages_Vendor : System.Web.UI.Page
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
    protected void Ven_Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            try
            {
                SqlCommand objcmd = new SqlCommand("USP_VenderMaster", con);
                objcmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
                //Ad_Id1.Value = Text_Id.Text;

                SqlParameter Ven_Name1 = objcmd.Parameters.Add("@Ven_Name", SqlDbType.NVarChar);
                Ven_Name1.Value = Ven_Name.Text;

                SqlParameter Mobno1 = objcmd.Parameters.Add("@Ven_MobNo", SqlDbType.BigInt);
                Mobno1.Value = Ven_MobNo.Text;

                SqlParameter Ven_Email1 = objcmd.Parameters.Add("@Ven_Email", SqlDbType.NVarChar);
                Ven_Email1.Value = Ven_Email.Text;

                SqlParameter Ven_Addr1 = objcmd.Parameters.Add("@Ven_Addr", SqlDbType.NVarChar);
                Ven_Addr1.Value = Ven_Addr.Text;

                SqlParameter Ven_OpeningBal1 = objcmd.Parameters.Add("@Ven_OpeningAmt", SqlDbType.NVarChar);
                Ven_OpeningBal1.Value = Ven_OpeningBal.Text;

                SqlParameter Ven_Status1 = objcmd.Parameters.Add("@Ven_Status", SqlDbType.SmallInt);
                Ven_Status1.Value = 1;

                SqlParameter BillT_UserId = objcmd.Parameters.Add("@Ven_UserId", SqlDbType.SmallInt);
                BillT_UserId.Value = UserId;

                SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

                objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                if (flag == 2)
                {
                    flag1.Value = 'U';
                    SqlParameter Ven_Id1 = objcmd.Parameters.Add("@Ven_Id", SqlDbType.SmallInt);
                    Ven_Id1.Value = Ven_Id.Text;
                }
                else
                    flag1.Value = 'I';

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();
                    string id = objcmd.Parameters["@id"].Value.ToString();
                    Ven_Status.Visible = true;
                    Ven_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                    Ven_Status.ForeColor = System.Drawing.Color.Green;
                    //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                    gvbind();

                }
                catch (Exception eee)
                {
                    Ven_Status.Visible = true;
                    Ven_Status.Text = eee.Message;
                    string id = objcmd.Parameters["@id"].Value.ToString();
                    Ven_Status.Text = "Record Already Exists .";
                    Ven_Status.ForeColor = System.Drawing.Color.Red;

                }
                finally
                {
                    con.Close();
                }

            }
            catch
            {
                Ven_Status.Text = "Record Already Exists .";
            }
        }
    }

    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_VenderMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Ven_Status1 = cmd.Parameters.Add("@Ven_Status", SqlDbType.SmallInt);
            Ven_Status1.Value = 1;

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

        SqlCommand objcmd = new SqlCommand("USP_VenderMaster", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlParameter Ven_Id1 = objcmd.Parameters.Add("@Ven_Id", SqlDbType.SmallInt);
        Ven_Id1.Value = gv_movimage.DataKeys[e.RowIndex].Value.ToString();

        SqlParameter Ven_Status1 = objcmd.Parameters.Add("@Ven_Status", SqlDbType.SmallInt);
        Ven_Status1.Value = 0;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        flag1.Value = 'D';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            Ven_Status.Visible = true;
            Ven_Status.Text = "Delete Successful.";// Your User Id=" + id ;
            Ven_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
            gvbind();

        }
        catch (Exception eee)
        {
            Ven_Status.Visible = true;
            Ven_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            Ven_Status.Text = "Record Already Exists .";
            Ven_Status.ForeColor = System.Drawing.Color.Red;

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

            Ven_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
            Ven_Name.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
            Ven_MobNo.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
            Ven_Email.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
            Ven_Addr.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[4].Text;
            Ven_OpeningBal.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[5].Text;
     
            Ven_Save.Text = "Update";
        }
        catch { }
    

    }
    protected void Ven_Clear_Click(object sender, EventArgs e)
    {
        try
        {
            flag = 1;
            Ven_Id.Text = "";
            Ven_Name.Text = "";
            Ven_MobNo.Text = "";
            Ven_Email.Text = "";
            Ven_Addr.Text = "";
            Ven_OpeningBal.Text = "";
            Ven_Save.Text = "Save";

        }
        catch { }
    }
}