using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class WebPages_Adminogin : System.Web.UI.Page
{
    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag = 1;
    static int userid = 0;
    static string UserName = null;


    protected void Page_Load(object sender, EventArgs e)
    {
       /* if (Session["UserId"] != null && Session["UserName"] != null)
        {
            UserId = Int32.Parse(Session["UserId"].ToString());
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
        */
        if (!IsPostBack)
        {
            connstring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            con = new SqlConnection(connstring);
            Txt_Email.Attributes["type"] = "email";
         
        }

    }
    protected void Btn_Login_Click(object sender, EventArgs e)
    {

        try
        {
              SqlCommand cmd = new SqlCommand("USP_AdminLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'P';
            SqlParameter Email = cmd.Parameters.Add("@Ad_Email", SqlDbType.NVarChar);
            Email.Value = Txt_Email.Text;

            SqlParameter Pass = cmd.Parameters.Add("@Ad_Password", SqlDbType.NVarChar);
            Pass.Value = Txt_Pass.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new System.Data.DataSet("TT");
            da.Fill(ds, "TT");
           
            if (ds.Tables["TT"].Rows.Count > 0)
            {
                try
                {
                    UserId = Int32.Parse(ds.Tables["TT"].Rows[0]["Ad_Id"].ToString());


                }
                catch { }

                try
                {
                    UserName = ds.Tables["TT"].Rows[0]["Ad_Name"].ToString();


                }
                catch { }
                Session["UserId"] = UserId;
                Session["UserName"] = UserName;
                Response.Redirect("AdminRegistration.aspx");
            }
            else
            {
            
            
            
            }
        }
        catch (Exception ee) { }

        
    }
}