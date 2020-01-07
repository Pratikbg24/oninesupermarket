using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class WebPages_SignUp : System.Web.UI.Page
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
            //gvbind();

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConfirmOrder.aspx");   
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustLogin.aspx");   
    }
}