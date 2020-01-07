using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPages_Payment : System.Web.UI.Page
{
    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag = 1;
    static float allTot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            connstring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            con = new SqlConnection(connstring);
        }

    }
    protected void Next_Click(object sender, EventArgs e)

    {
        Session.Abandon();
        Response.Redirect("UserHome.aspx");
    }
}