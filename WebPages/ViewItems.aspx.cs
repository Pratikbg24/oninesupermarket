using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPages_ViewItems : System.Web.UI.Page
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

           
           //   Txt_Quantity.Attributes["type"] = "Number";
            //TextBox t = (TextBox)(Rep.Controls[0].FindControl("Txt_Quantity"));
         //   t.Attributes["type"] = "Range";
        }

    }
   

    protected void dl_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var myDropDownList = e.Item.FindControl("ddl_Quantity") as DropDownList;
            int currentItemID = int.Parse(this.Rep.DataKeys[e.Item.ItemIndex].ToString());// .dl.DataKeys[e.Item.ItemIndex].ToString());

            try
            {
                SqlCommand cmd = new SqlCommand("USP_QuantityRange", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                flag1.Value = 'A';

                SqlParameter R_Status = cmd.Parameters.Add("@R_Status", SqlDbType.SmallInt);
                R_Status.Value = 1;

           
                ds = new System.Data.DataSet("TT");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TT");

                if (ds.Tables["TT"].Rows.Count > 0)
                {

                    myDropDownList.DataSource = ds.Tables["TT"];
                    myDropDownList.DataTextField = "R_Range";
                    myDropDownList.DataValueField = "R_Id";
                    myDropDownList.DataBind();
                }
            }
            catch { }

            
        }
    }

    protected void gvbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_StockMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'G';
            SqlParameter Ad_Status1 = cmd.Parameters.Add("@Stock_Status", SqlDbType.SmallInt);
            Ad_Status1.Value = 1;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new System.Data.DataSet("TT");
            da.Fill(ds, "TT");
            if (ds.Tables["TT"].Rows.Count > 0)
            {
                Rep.DataSource = ds;
                Rep.DataBind();
            }
        
        }
        catch (Exception ee) { }

    }

    protected void AddToCartClick(Object sender, DataListCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            TextBox Batch = e.Item.FindControl("Batch") as TextBox;
            TextBox Txt_Quantity = e.Item.FindControl("Txt_Quantity") as TextBox;
            HiddenField Prod_Id = e.Item.FindControl("HiddenField1") as HiddenField;
            HiddenField Stock_Id = e.Item.FindControl("HiddenField4") as HiddenField;
            HiddenField Prod_Rate = e.Item.FindControl("HiddenField2") as HiddenField;
            HiddenField Unit_Id = e.Item.FindControl("HiddenField3") as HiddenField;
            SqlCommand objcmd = null;
            string id1=null;

            if (Session["CurrentSession"] ==null)
            {
            //To Insert Into Session Table 
                try
                {
                    objcmd = new SqlCommand("USP_UserSession", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    //SqlParameter Start_Time = objcmd.Parameters.Add("@Start_Time", SqlDbType.DateTime);
                    //Start_Time.Value = "2-2-2012";

                    SqlParameter End_Time = objcmd.Parameters.Add("@End_Time", SqlDbType.DateTime);
                    End_Time.Value = "2-2-2012";

                    SqlParameter Sess_Status = objcmd.Parameters.Add("@Sess_Status", SqlDbType.NVarChar);
                    Sess_Status.Value = 1;
                
                    SqlParameter flag3 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                    flag3.Value = 'I';
                    objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;


                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();

                    id1 = objcmd.Parameters["@id"].Value.ToString();

                    Session["CurrentSession"] = id1;
                }
                catch {}

                try
                {
                    objcmd = new SqlCommand("USP_CartMaster", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    float rate = 0;
                    float total = 0, quantity = 0;

                    try
                    {
                        rate = float.Parse(Prod_Rate.Value);

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
                    //allTot += total;
                    
                    SqlParameter Sess_Id1 = objcmd.Parameters.Add("@Sess_Id", SqlDbType.NVarChar);
                    Sess_Id1.Value = id1;

                    SqlParameter CM_Total = objcmd.Parameters.Add("@CM_Total", SqlDbType.Float);
                    CM_Total.Value = total;

                    SqlParameter CM_Status1 = objcmd.Parameters.Add("@CM_Status", SqlDbType.SmallInt);
                    CM_Status1.Value = 1;
                    
                    SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                    flag1.Value = 'I';
                    objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();

                    string id = objcmd.Parameters["@id"].Value.ToString();
                    Session["CM_Id"] = id;


                    objcmd = new SqlCommand("USP_CartMaster", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    //float rate = 0;
                    //float total = 0, quantity = 0;

                    try
                    {
                        rate = float.Parse(Prod_Rate.Value);

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
                   
                    SqlParameter Cart_Id1 = objcmd.Parameters.Add("@CM_Id", SqlDbType.SmallInt);
                    Cart_Id1.Value = id;

                     CM_Total = objcmd.Parameters.Add("@CM_Total", SqlDbType.Float);
                    CM_Total.Value = allTot;

                    flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                    flag1.Value = 'P';

                    //objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();

                    //                string id = objcmd.Parameters["@id"].Value.ToString();

                    try
                    {
                        objcmd = new SqlCommand("USP_CartTransaction", con);
                        objcmd.CommandType = CommandType.StoredProcedure;

                        // calculation

                        Cart_Id1 = objcmd.Parameters.Add("@CM_Id", SqlDbType.SmallInt);
                        Cart_Id1.Value = id;

                        //SqlParameter Stock_Id1 = objcmd.Parameters.Add("@Stock_Id", SqlDbType.SmallInt);
                        //Stock_Id1.Value = Stock_Id.Value;


                        SqlParameter Prod_Id1 = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
                        Prod_Id1.Value = Prod_Id.Value;


                        SqlParameter Unit_Id1 = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
                        Unit_Id1.Value = Unit_Id.Value;

                        SqlParameter Quantity = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
                        Quantity.Value = quantity;

                        SqlParameter Batch1 = objcmd.Parameters.Add("@Batch", SqlDbType.NVarChar);
                        Batch1.Value = Batch.Text;

                        SqlParameter TotalAmount2 = objcmd.Parameters.Add("@Prod_Total", SqlDbType.Float);
                        TotalAmount2.Value = total;

                        SqlParameter Rate = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.Float);
                        Rate.Value = rate;

                        SqlParameter CT_Status1 = objcmd.Parameters.Add("@CT_Status", SqlDbType.SmallInt);
                        CT_Status1.Value = 1;


                        SqlParameter flag2 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                        flag2.Value = 'I';
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        objcmd.ExecuteNonQuery();

                        //       Response.Write("Insert Successfuly");
                    }
                    catch { }
              

                }
                catch {}
            }
            else
            {
                id1 = Session["CurrentSession"].ToString();
                string id = Session["CM_Id"].ToString();

                //  To Insert Into Cart Master Table 

                objcmd = new SqlCommand("USP_CartMaster", con);
                objcmd.CommandType = CommandType.StoredProcedure;

                float rate = 0;
                float total = 0, quantity = 0;

                try
                {
                    rate = float.Parse(Prod_Rate.Value);

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
                allTot += total;

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

//                string id = objcmd.Parameters["@id"].Value.ToString();

                    try
                    {
                        objcmd = new SqlCommand("USP_CartTransaction", con);
                        objcmd.CommandType = CommandType.StoredProcedure;

                        // calculation

                        Cart_Id1 = objcmd.Parameters.Add("@CM_Id", SqlDbType.SmallInt);
                        Cart_Id1.Value = id;


                        SqlParameter Prod_Id1 = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
                        Prod_Id1.Value = Prod_Id.Value;

                        SqlParameter Unit_Id1 = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
                        Unit_Id1.Value = Unit_Id.Value;

                        SqlParameter Quantity = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
                        Quantity.Value = quantity;

                        SqlParameter Batch1 = objcmd.Parameters.Add("@Batch", SqlDbType.NVarChar);
                        Batch1.Value = Batch.Text;

                        SqlParameter TotalAmount2 = objcmd.Parameters.Add("@Prod_Total", SqlDbType.Float);
                        TotalAmount2.Value = total;

                        SqlParameter Rate = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.Float);
                        Rate.Value = rate;

                        SqlParameter CT_Status1 = objcmd.Parameters.Add("@CT_Status", SqlDbType.SmallInt);
                        CT_Status1.Value = 1;


                        SqlParameter flag2 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                        flag2.Value = 'I';
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        objcmd.ExecuteNonQuery();
                        Txt_Quantity.Text = "";
                        Txt_Quantity.Text = "";
                 //       Response.Write("Insert Successfuly");
                    }
                    catch { }
                
            }

        }
        }


    protected void Rep_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Go_Click(object sender, EventArgs e)
    {
            Response.Redirect("ViewCart.aspx");   
       
    }

    public object id { get; set; }
}