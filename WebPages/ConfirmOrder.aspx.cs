using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Text;

public partial class WebPages_ConformOrder : System.Web.UI.Page
{
    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            connstring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            con = new SqlConnection(connstring);
            gvbind();

        }

    }
    protected void Cust_Save_Click(object sender, EventArgs e)
    {
        string new_sub2 = Cust_MobNo.Text;
        string new_sub1 = Cust_Password.Text;
        string new_sub3 = Cust_Email.Text;
        string prev_sub2 = null;
        string prev_sub3 = null;

        string prev_sub1 = null;
        bool contain = false;

        if (gv_movimage.Rows.Count > 0)
        {
            for (int i = 0; i < gv_movimage.Rows.Count; i++)
            {
                try
                {
                    prev_sub1 = gv_movimage.Rows[i].Cells[2].Text;
                    prev_sub2 = gv_movimage.Rows[i].Cells[3].Text;
                    prev_sub3 = gv_movimage.Rows[i].Cells[4].Text;

                }
                catch { }
                if ( new_sub1 == prev_sub1 || new_sub2 == prev_sub2 || new_sub3 == prev_sub3)
                {
                    contain = true;
                    break;
                }

            }
        }
        if (contain == true)
        {
            Cust_Status.Text = "Record Already Exists.";
            Cust_Status.ForeColor = System.Drawing.Color.Red;

        }
       

        else{

            if (IsValid)
            {
                try
                {
                    SqlCommand objcmd = new SqlCommand("USP_CustomerMaster", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    //SqlParameter Ad_Id1 = objcmd.Parameters.Add("@Ad_Id", SqlDbType.SmallInt);
                    //Ad_Id1.Value = Text_Id.Text;

                    SqlParameter Cust_Name1 = objcmd.Parameters.Add("@Cust_Name", SqlDbType.NVarChar);
                    Cust_Name1.Value = Cust_Name.Text;

                    SqlParameter Cust_Pass1 = objcmd.Parameters.Add("@Cust_Password", SqlDbType.NVarChar);
                    Cust_Pass1.Value = Cust_Password.Text;

                    SqlParameter Mobno1 = objcmd.Parameters.Add("@Cust_MobNo", SqlDbType.BigInt);
                    Mobno1.Value = Cust_MobNo.Text;

                    SqlParameter Cust_Email1 = objcmd.Parameters.Add("@Cust_Email", SqlDbType.NVarChar);
                    Cust_Email1.Value = Cust_Email.Text;

                    SqlParameter Cust_Addr1 = objcmd.Parameters.Add("@Cust_Addr", SqlDbType.NVarChar);
                    Cust_Addr1.Value = Cust_Addr.Text;


                    SqlParameter Cust_Status1 = objcmd.Parameters.Add("@Cust_Status", SqlDbType.SmallInt);
                    Cust_Status1.Value = 1;

                    SqlParameter Cust_UserId1 = objcmd.Parameters.Add("@Cust_UserId", SqlDbType.SmallInt);
                    Cust_UserId1.Value = UserId;

                    SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

                    objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    if (flag == 2)
                    {
                        flag1.Value = 'U';
                        SqlParameter Cust_Id1 = objcmd.Parameters.Add("@Cust_Id", SqlDbType.SmallInt);
                        Cust_Id1.Value = Cust_Id.Text;
                    }
                    else
                        flag1.Value = 'I';

                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        objcmd.ExecuteNonQuery();
                        string id = objcmd.Parameters["@id"].Value.ToString();
                        Cust_Status.Visible = true;
                        Cust_Status.Text = "Registration Successful.";// Your User Id=" + id ;
                        Cust_Status.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("CustLogin.aspx"); 
                        //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
                        gvbind();

                        string str = null;
                        //double netamt = 0;
                        //long invno = 0;
                        int admissions = 0;
                        DateTime today = DateTime.Today;
                        DataSet ds;
                        //ConnectionClass obj = new ConnectionClass();

                            ///////////////////////
                            string sURL = null;
                            int flag4 = 1;
                            string message = "User Name =" + Cust_Name.Text + " Password =" + Cust_Password.Text + " ";
                            sURL = "http://smslogin.pcexpert.in/api/mt/SendSMS?user=CarloFashions&password=CarloFashions&senderid=CarloF&channel=trans&DCS=0&flashsms=0&number=7498978822&text='" + message + "'&route=02";
                            // }

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
                            request.MaximumAutomaticRedirections = 4;
                            request.Credentials = CredentialCache.DefaultCredentials;
                            try
                            {
                                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                Stream receiveStream = response.GetResponseStream();
                                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                                string sResponse = readStream.ReadToEnd();
                                response.Close();
                                readStream.Close();
                                // SendToday = true;
                            }
                            catch (Exception ex)
                            {
                    //            MessageBox.Show(ex.Message);
                            }
                    


                    }
                    catch (Exception eee)
                    {
                        Cust_Status.Visible = true;
                        Cust_Status.Text = eee.Message;
                        string id = objcmd.Parameters["@id"].Value.ToString();
                        Response.Redirect("CustLogin.aspx"); 
                        Cust_Status.Text = "Record Already Exists .";
                      
                        Cust_Status.ForeColor = System.Drawing.Color.Red;

                    }
                    finally
                    {
                        con.Close();
                        Cust_Id.Text = "";
                        Cust_Name.Text = "";
                        Cust_MobNo.Text = "";
                        Cust_Email.Text = "";
                        Cust_Addr.Text = "";
                        Cust_Password.Text = "";
                    }

                }
                catch
                {
                    Cust_Status.Text = "Record Already Exists .";
                }
            }
        }
    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        try
        {
            flag = 1;
            Cust_Id.Text = "";
            Cust_Name.Text = "";
            Cust_MobNo.Text = "";
            Cust_Email.Text = "";
            Cust_Addr.Text = "";
            Cust_Password.Text = "";
           Cust_Save.Text = "Save";
        }
        catch
        {


        }
    }
    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_CustomerMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Cust_Status1 = cmd.Parameters.Add("@Cust_Status", SqlDbType.SmallInt);
            Cust_Status1.Value = 1;

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
    protected void gv_movimage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        SqlCommand objcmd = new SqlCommand("USP_CustomerMaster", con);
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlParameter Cust_Id1 = objcmd.Parameters.Add("@Cust_Id", SqlDbType.SmallInt);
        Cust_Id1.Value = gv_movimage.DataKeys[e.RowIndex].Value.ToString();

        SqlParameter Cust_Status1 = objcmd.Parameters.Add("@Cust_Status", SqlDbType.SmallInt);
        Cust_Status1.Value = 0;

        SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);

        objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        flag1.Value = 'D';

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            objcmd.ExecuteNonQuery();
            string id = objcmd.Parameters["@id"].Value.ToString();
            Cust_Status.Visible = true;
            Cust_Status.Text = "Delete Successful.";// Your User Id=" + id ;
            Cust_Status.ForeColor = System.Drawing.Color.Green;
            //SendSMS(txt_MobileNo.Text, UserId, pwd, txt_UserName.Text);
            gvbind();

        }
        catch (Exception eee)
        {
            Cust_Status.Visible = true;
            Cust_Status.Text = eee.Message;
            string id = objcmd.Parameters["@id"].Value.ToString();
            Cust_Status.Text = "Record Already Exists .";
            Cust_Status.ForeColor = System.Drawing.Color.Red;

        }
        finally
        {
            con.Close();
        }

    }
    protected void gv_movimage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
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

            Cust_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;

            Cust_Name.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[1].Text;
            Cust_Password.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;

            Cust_MobNo.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[3].Text;
            Cust_Email.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[4].Text;
            Cust_Addr.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[5].Text;
            Cust_Save.Text = "Update";
        }
        catch { }


    
    }
}