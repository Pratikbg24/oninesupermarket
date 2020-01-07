using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class WebPages_ViewCart : System.Web.UI.Page
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
            gvbind();
            ddlbind();
            ddlbind1();

        }
    }
    protected void ddlbind1()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_UnitMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';

            SqlParameter Unit_Status = cmd.Parameters.Add("@Unit_Status", SqlDbType.VarChar);
            Unit_Status.Value = 1;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");

            if (ds.Tables["TT"].Rows.Count > 0)
            {
                ddl_UnitName.DataSource = ds.Tables["TT"];
                ddl_UnitName.DataTextField = "Unit_Name";
                ddl_UnitName.DataValueField = "Unit_Id";
                ddl_UnitName.DataBind();
            }
        }
        catch { }
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
                ddl_Prod_Name.DataSource = ds.Tables["TT"];
                ddl_Prod_Name.DataTextField = "Prod_Name";
                ddl_Prod_Name.DataValueField = "Prod_Id";
                ddl_Prod_Name.DataBind();
            }
        }
        catch { }
    }
    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_CartTransaction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'P';

            SqlParameter sess = cmd.Parameters.Add("@Sess_Id", SqlDbType.NVarChar);
            sess.Value = Session["CurrentSession"] ;

            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new System.Data.DataSet("TT");
            da.Fill(ds, "TT");
            if (ds.Tables["TT"].Rows.Count > 0)
            {
                gv_movimage.DataSource = ds;
                gv_movimage.DataBind();
                Txt_AllTot.Text = ds.Tables["TT"].Rows[0]["CM_Total"].ToString();
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

       
           ddl_Prod_Name.Text=gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[7].Text;
           Txt_Quantity.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[2].Text;
           Txt_Rate.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[4].Text;
            ddl_UnitName.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[6].Text;
            Txt_Total.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[5].Text;
            Txt_Batch.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[8].Text;
            Txt_CT_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[0].Text;
            Unit_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[6].Text;
            Prod_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[7].Text;
            Txt_CM_Id.Text = gv_movimage.Rows[gv_movimage.SelectedIndex].Cells[9].Text;
        }
        catch { }
    
    }
    protected void ddl_Prod_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_StockMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'L';
            SqlParameter Ad_Status1 = cmd.Parameters.Add("@Stock_Status", SqlDbType.SmallInt);
            Ad_Status1.Value = 1;
            SqlParameter Prod_Id1 = cmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
            Prod_Id1.Value = ddl_Prod_Name.SelectedValue;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new System.Data.DataSet("TT");
            da.Fill(ds, "TT");
            if (ds.Tables["TT"].Rows.Count > 0)
            {
                Txt_Rate.Text = ds.Tables["TT"].Rows[0]["Prod_Rate"].ToString();
                ddl_UnitName.SelectedValue = ds.Tables["TT"].Rows[0]["Unit_Id"].ToString();
               Txt_Batch.Text = ds.Tables["TT"].Rows[0]["Batch"].ToString();
            }
            
        }
        catch (Exception ee)
        { 
        
        }

    }
    protected void ddl_Prod_Name_TextChanged(object sender, EventArgs e)
    {
       
       }
    protected void Txt_Total_TextChanged(object sender, EventArgs e)
    {
    
    }
    protected void Txt_Quantity_TextChanged(object sender, EventArgs e)
    {

        float rate=0 ;
        float total = 0, quantity = 0;

        try
        {
            rate = float.Parse(Txt_Rate.Text);

        }
        catch { }
        try
        {
            quantity = float.Parse(Txt_Quantity.Text);

        }
        catch { }

        try
        {
            total = rate * quantity;

        }
        catch { }
       // allTot += total;
        Txt_Total.Text = total.ToString();
       // Txt_AllTot.Text = allTot.ToString();
    }
  
    protected void btn_Save_Click1(object sender, EventArgs e)
    {

        SqlCommand objcmd = null;
        string id1 = null;

        if (Session["CurrentSession"] == null)
        {
        
        }
        else
            {
                id1 = Session["CurrentSession"].ToString();
                string id = Session["CM_Id"].ToString();

                //  To Insert Into Cart Master Table 

                objcmd = new SqlCommand("USP_CartMaster", con);
                objcmd.CommandType = CommandType.StoredProcedure;

                
                SqlParameter Cart_Id1 = objcmd.Parameters.Add("@CM_Id", SqlDbType.SmallInt);
                Cart_Id1.Value = id;

                SqlParameter CM_Total = objcmd.Parameters.Add("@CM_Total", SqlDbType.Float);
                CM_Total.Value = allTot;

                SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                flag1.Value = 'P';

                //objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                    con.Open();
                objcmd.ExecuteNonQuery();


                    try
                    {
                        objcmd = new SqlCommand("USP_CartTransaction", con);
                        objcmd.CommandType = CommandType.StoredProcedure;

                        // calculation
                        SqlParameter Cart_Id2 = objcmd.Parameters.Add("@CM_Id", SqlDbType.SmallInt);
                        Cart_Id2.Value = Txt_CM_Id.Text;


                        SqlParameter Prod_Id1 = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
                        Prod_Id1.Value = Prod_Id.Text;

                        SqlParameter Unit_Id1 = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
                        Unit_Id1.Value = Unit_Id.Text;

                        SqlParameter Quantity = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
                        Quantity.Value = Txt_Quantity.Text;

                        SqlParameter Batch1 = objcmd.Parameters.Add("@Batch", SqlDbType.NVarChar);
                        Batch1.Value = "2-2-2012";

                        SqlParameter TotalAmount2 = objcmd.Parameters.Add("@Prod_Total", SqlDbType.Float);
                        TotalAmount2.Value = Txt_Total.Text;

                        SqlParameter Rate = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.Float);
                        Rate.Value = Txt_Rate.Text;

                        SqlParameter CT_Status1 = objcmd.Parameters.Add("@CT_Status", SqlDbType.SmallInt);
                        CT_Status1.Value = 1;


                        SqlParameter CartT_Id1 = objcmd.Parameters.Add("@CT_Id", SqlDbType.SmallInt);
                        CartT_Id1.Value = Txt_CT_Id.Text;

                        SqlParameter flag2 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                        flag2.Value = 'U';
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        objcmd.ExecuteNonQuery();

                        gvbind();
                 }
                 catch { }
                
            }

        }



    protected void Order_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");   
    }
}
