using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Specialized;
public partial class WebPages_TransactionDetails : System.Web.UI.Page
{

    static SqlConnection con;
    static string connstring;
    DataSet ds;
    static string user_Name;
    static int UserId;
    static int flag = 1;
    static int id;



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
            SetInitialRow();
            txt_BillDate.Attributes["type"] = "date";
         //   txt_BillDate.Text = DateTime.Today.ToString("yyyy-MM-dd");

               }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        double amt = 0, paid = 0, rem = 0;
        int  custid = 0;
      
        try
        {
            custid = Int16.Parse(ddl_CustomerName.SelectedValue.ToString());
        }
        catch { }
        try
        {
            amt = double.Parse((Gridview1.FooterRow.FindControl("txt_FooterTotal") as TextBox).Text);
            amt = Math.Round(amt, 2, MidpointRounding.AwayFromZero);
        }
        catch { }
        try
        {
            paid = double.Parse(txt_PaidAmount.Text);
            paid = Math.Round(paid, 2, MidpointRounding.AwayFromZero);
        }
        catch { }
        try
        {
            rem = amt - paid;
            rem = double.Parse((Gridview1.FooterRow.FindControl("txt_RemAmount") as TextBox).Text);
            rem = Math.Round(rem, 2, MidpointRounding.AwayFromZero);
        }
        catch { }
    
        try
        {
            SqlCommand objcmd = new SqlCommand("USP_BillMaster", con);
            objcmd.CommandType = CommandType.StoredProcedure;

           /* SqlParameter Bill_Id1 = objcmd.Parameters.Add("@Bill_Id", SqlDbType.SmallInt);
            Bill_Id1.Value = UserId;
            */
            SqlParameter Bill_Date = objcmd.Parameters.Add("@Bill_Date", SqlDbType.DateTime);
            Bill_Date.Value = txt_BillDate.Text;

            SqlParameter Cust_Id = objcmd.Parameters.Add("@Cust_Id", SqlDbType.Int);
            Cust_Id.Value = custid;



            SqlParameter Bill_TotAmt1 = objcmd.Parameters.Add("@Bill_TotAmt", SqlDbType.Float);
            Bill_TotAmt1.Value = amt;

            SqlParameter Paid_Amt = objcmd.Parameters.Add("@Paid_Amt", SqlDbType.Float);
            Paid_Amt.Value = paid;

            SqlParameter Rem_Amt = objcmd.Parameters.Add("@Rem_Amt", SqlDbType.Float);
            Rem_Amt.Value = rem;

               SqlParameter Bill_Status1 = objcmd.Parameters.Add("@Bill_Status", SqlDbType.SmallInt);
               Bill_Status1.Value = 1;


               SqlParameter Bill_UserId = objcmd.Parameters.Add("@Bill_UserId", SqlDbType.SmallInt);
               Bill_UserId.Value = UserId;


            SqlParameter flag1 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'I';


            objcmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                objcmd.ExecuteNonQuery();
                string id = objcmd.Parameters["@id"].Value.ToString();
                lbl_Status.Visible = true;
                lbl_Status.Text = "Bill Saved. Bill No =" + id;
                lbl_Status.ForeColor = System.Drawing.Color.Green;

                //To Update Pending amount and Trey 
               if (rem != 0)
                {
                    objcmd = new SqlCommand("USP_VenderMaster", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    Cust_Id = objcmd.Parameters.Add("@Ven_Id", SqlDbType.Int);
                    Cust_Id.Value = custid;



                  SqlParameter  Dueamt1 = objcmd.Parameters.Add("@Ven_DueAmt", SqlDbType.Float);
                   Dueamt1.Value = rem;
                    // For Due Amount
                    SqlParameter flag3 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                    //SqlParameter ST = objcmd.Parameters.Add("@ST", SqlDbType.VarChar);

                    if (paid < amt)
                    {
                        flag3.Value = 'P';
                      //  ST.Value = 'P';
                    }
                    else
                    {
                        flag3.Value = 'P';
                        //ST.Value = 'Q';
                    }
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();
                }
              
               
                foreach (GridViewRow row in Gridview1.Rows)
                {
                    string field1 = ((TextBox)row.Cells[2].FindControl("txt_Quantity")).Text;
                    string field2 = ((TextBox)row.Cells[4].FindControl("txt_Rate")).Text;
                    string field5 = ((TextBox)row.Cells[1].FindControl("txt_NECC")).Text;
                    string field6 = ((DropDownList)row.Cells[3].FindControl("ddl_UnitName")).SelectedItem.Value;
                    string field3 = ((DropDownList)row.Cells[0].FindControl("ddl_ItemName")).SelectedItem.Value;
                    string field4 = ((TextBox)row.Cells[4].FindControl("txt_Total")).Text;

                    double rate = 0, total = 0;
                    long qty = 0;
                    try
                    {
                        qty = Int64.Parse(field1);
                    }
                    catch { }

                    try
                    {
                        rate = double.Parse(field2);
                        rate = Math.Round(rate, 2, MidpointRounding.AwayFromZero);
                    }
                    catch { }
                    try
                    {
                        total = double.Parse(field4);
                        total = Math.Round(total, 2, MidpointRounding.AwayFromZero);
                    }
                    catch { }

                    objcmd = new SqlCommand("USP_BillTransaction", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter Bill_Id = objcmd.Parameters.Add("@Bill_Id", SqlDbType.SmallInt);
                    Bill_Id.Value = id;

                    SqlParameter Prod_Id = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
                    Prod_Id.Value = field3;

                    SqlParameter Unit_Id = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
                    Unit_Id.Value = field6;

                    SqlParameter Quantity = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
                    Quantity.Value = qty;

                    SqlParameter Batch1 = objcmd.Parameters.Add("@Batch", SqlDbType.NVarChar);
                    Batch1.Value = field5;

                    SqlParameter TotalAmount2 = objcmd.Parameters.Add("@BillT_Total", SqlDbType.Float);
                    TotalAmount2.Value = total;

                    SqlParameter Rate = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.Float);
                    Rate.Value = rate;

                    SqlParameter BillT_UserId = objcmd.Parameters.Add("@BillT_UserId", SqlDbType.SmallInt);
                    BillT_UserId.Value = UserId;

                
                    SqlParameter flag2 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                    flag2.Value = 'I';
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();

                    // To Insert Into Stock Table 

                    objcmd = new SqlCommand("USP_StockMaster", con);
                    objcmd.CommandType = CommandType.StoredProcedure;

                    Prod_Id = objcmd.Parameters.Add("@Prod_Id", SqlDbType.SmallInt);
                    Prod_Id.Value = field3;

                    Unit_Id = objcmd.Parameters.Add("@Unit_Id", SqlDbType.SmallInt);
                    Unit_Id.Value = field6;

                    Quantity = objcmd.Parameters.Add("@Prod_Quantity", SqlDbType.Float);
                    Quantity.Value = qty;

                    SqlParameter Prod_Rate = objcmd.Parameters.Add("@Prod_Rate", SqlDbType.Float);
                    Prod_Rate.Value = rate;

                    SqlParameter Batch = objcmd.Parameters.Add("@Batch", SqlDbType.NVarChar);
                    Batch.Value = field5;


                    SqlParameter Stock_UserId = objcmd.Parameters.Add("@Stock_UserId", SqlDbType.SmallInt);
                    Stock_UserId.Value = UserId;


                    flag2 = objcmd.Parameters.Add("@Flag", SqlDbType.VarChar);
                    flag2.Value = 'I';
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    objcmd.ExecuteNonQuery();
                }

                Clear();
            }
            catch { }
        }
        catch (Exception eee)
        {
            lbl_Status.Visible = true;
            lbl_Status.Text = eee.Message;
            lbl_Status.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    

    
    }



    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void Clear()
    {
        txt_PaidAmount.Text = String.Empty;
        txt_RemAmount.Text = String.Empty;
      }

    protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }

    protected void ddlbind()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_VenderMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';


            SqlParameter Ven_Status1 = cmd.Parameters.Add("@Ven_Status", SqlDbType.SmallInt);
            Ven_Status1.Value = 1;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");

            if (ds.Tables["TT"].Rows.Count > 0)
            {
                ddl_CustomerName.DataSource = ds.Tables["TT"];
                ddl_CustomerName.DataTextField = "Ven_Name";
                ddl_CustomerName.DataValueField = "Ven_Id";
                ddl_CustomerName.DataBind();
            }
        }
        catch { }
    }
    protected void Calculate2(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            TextBox txt1 = (TextBox)currentRow.FindControl("txt_Quantity");
            TextBox txt2 = (TextBox)currentRow.FindControl("txt_NECC");
          // TextBox txt3 = (TextBox)currentRow.FindControl("txt_Commission");

            int qty = 0;
            try
            {
                qty = Convert.ToInt32(txt1.Text);
            }
            catch { }

            double rate = 0, neccrate = 0;
            try
            {
                neccrate = Convert.ToDouble(txt2.Text);
            }
            catch { }

            //double commi = 0;
            //try
            //{
            //    commi = Convert.ToDouble(txt3.Text);
            //}
            //catch { }

            //rate = neccrate - commi;

            double amt = 0;
            try
            {
                amt = qty * rate;
                amt = Math.Round(amt, 0, MidpointRounding.AwayFromZero);
            }
            catch { }

            ((TextBox)currentRow.FindControl("txt_Total")).Text = (amt).ToString();
            ((TextBox)currentRow.FindControl("txt_Rate")).Text = (rate).ToString();

            string field1 = null;
            string field2 = null;
            double total = 0;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                field1 = ((TextBox)row.Cells[1].FindControl("txt_Quantity")).Text;
                field2 = ((TextBox)row.Cells[2].FindControl("txt_Rate")).Text;
                try
                {
                    qty = Convert.ToInt32(field1);
                }
                catch { }
                try
                {
                    rate = Convert.ToDouble(field2);
                }
                catch { }
                total += (qty * rate);
            }

            (Gridview1.FooterRow.FindControl("txt_FooterTotal") as TextBox).Text = total.ToString();

            double rem=0.0,paid=0.0;
          //  paid = txt_PaidAmount.Text;

            rem = amt - paid;
        }
        catch { }
    }

    protected void Calculate(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            TextBox txt1 = (TextBox)currentRow.FindControl("txt_Quantity");
            TextBox txt2 = (TextBox)currentRow.FindControl("txt_Rate");
            int qty = 0;
            try
            {
                qty = Convert.ToInt32(txt1.Text);
            }
            catch { }

            double rate = 0;
            try
            {
                rate = Convert.ToDouble(txt2.Text);
            }
            catch { }
            double amt = 0;
            try
            {
                amt = qty * rate;
                amt = Math.Round(amt, 0, MidpointRounding.AwayFromZero);
            }
            catch { }

            ((TextBox)currentRow.FindControl("txt_Total")).Text = (amt).ToString();

            string field1 = null;
            string field2 = null;
            double total = 0;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                field1 = ((TextBox)row.Cells[1].FindControl("txt_Quantity")).Text;
                field2 = ((TextBox)row.Cells[2].FindControl("txt_Rate")).Text;
                try
                {
                    qty = Convert.ToInt32(field1);
                }
                catch { }
                try
                {
                    rate = Convert.ToDouble(field2);
                }
                catch { }
                total += (qty * rate);
            }

            (Gridview1.FooterRow.FindControl("txt_FooterTotal") as TextBox).Text = total.ToString();
            txt_PaidAmount.Text = total.ToString();

        }
        catch { }
    }


    private void FillDropDownList(DropDownList ddl)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';
            SqlParameter Prod_Status1 = cmd.Parameters.Add("@Prod_Status", SqlDbType.SmallInt);
            Prod_Status1.Value = 1;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");
            if (ds.Tables["TT"].Rows.Count > 0)
            {
               ddl.DataSource = ds.Tables["TT"];
                ddl.DataTextField = "Prod_Name";
                ddl.DataValueField = "Prod_Id";
                ddl.DataBind();
            }
        }
        catch
        { }

    }
    private void FillDropDownList1(DropDownList ddl)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("USP_UnitMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter flag1 = cmd.Parameters.Add("@Flag", SqlDbType.VarChar);
            flag1.Value = 'A';
            SqlParameter Unit_Status1 = cmd.Parameters.Add("@Unit_Status", SqlDbType.SmallInt);
            Unit_Status1.Value = 1;

            ds = new System.Data.DataSet("TT");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TT");
            if (ds.Tables["TT"].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables["TT"];
                ddl.DataTextField = "Unit_Name";
                ddl.DataValueField = "Unit_Id";
                ddl.DataBind();
            }
        }
        catch
        { }

    }
        
        
    private void SetInitialRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value 
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value 
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for DropDownList selected item 
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item 
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string))); // For Trey

        dr = dt.NewRow();
        //dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column6"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;

        //Bind the Gridview 
        Gridview1.DataSource = dt;
        Gridview1.DataBind();

        //After binding the gridview, we can then extract and fill the DropDownList with Data 
        DropDownList ddl1 = (DropDownList)Gridview1.Rows[0].Cells[0].FindControl("ddl_ItemName");
        FillDropDownList(ddl1);
        //After binding the gridview, we can then extract and fill the DropDownList with Data 
      DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[3].FindControl("ddl_UnitName");
          FillDropDownList1(ddl2);
    
    }

    private void AddNewRowToGrid()
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
        //        drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                //add new row to DataTable 
                dtCurrentTable.Rows.Add(drCurrentRow);
                
                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {
                    TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txt_NECC");
                    TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("txt_Quantity");
                    TextBox box4 = (TextBox)Gridview1.Rows[i].Cells[4].FindControl("txt_Rate");
                    TextBox box5 = (TextBox)Gridview1.Rows[i].Cells[5].FindControl("txt_Total");
                    TextBox box6 = (TextBox)Gridview1.FooterRow.FindControl("txt_FooterTotal");


                    dtCurrentTable.Rows[i]["Column2"] = box1.Text;
                    dtCurrentTable.Rows[i]["Column3"] = box2.Text;
                    dtCurrentTable.Rows[i]["Column5"] = box4.Text;
                    dtCurrentTable.Rows[i]["Column6"] = box5.Text;

                    //extract the DropDownList Selected Items 

                    DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[0].FindControl("ddl_ItemName");
            
                    // Update the DataRow with the DDL Selected Items 

                    dtCurrentTable.Rows[i]["Column1"] = ddl1.SelectedItem.Text;
                    DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[3].FindControl("ddl_UnitName");

                    dtCurrentTable.Rows[i]["Column4"] = ddl2.SelectedItem.Text;
                }

                //Store the current data to ViewState for future reference 
                ViewState["CurrentTable"] = dtCurrentTable;
                
                //Rebind the Grid with the current data to reflect changes 
                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");

        }
        //Set Previous Data on Postbacks 
        SetPreviousData();
    }

    private void SetPreviousData()
    {
        try
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txt_NECC");
                        TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("txt_Quantity");
                        TextBox box4 = (TextBox)Gridview1.Rows[i].Cells[4].FindControl("txt_Rate");
                        TextBox box5 = (TextBox)Gridview1.Rows[i].Cells[5].FindControl("txt_Total");
                        TextBox box6 = (TextBox)Gridview1.FooterRow.FindControl("txt_FooterTotal");                        
                       
                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[0].FindControl("ddl_ItemName");
                        FillDropDownList(ddl1);
                       
                       DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[3].FindControl("ddl_UnitName");
                        FillDropDownList1(ddl2);

                        if (i < dt.Rows.Count - 1)
                        {
                            box1.Text = dt.Rows[i]["Column2"].ToString();
                            box2.Text = dt.Rows[i]["Column3"].ToString();
                            box4.Text = dt.Rows[i]["Column5"].ToString();
                            box5.Text = dt.Rows[i]["Column6"].ToString();
                            box6.Text = dt.Rows[i]["Column6"].ToString();
                            ddl1.ClearSelection();
                            ddl2.ClearSelection();
                            ddl1.Items.FindByText(dt.Rows[i][0].ToString()).Selected = true;
                           ddl2.Items.FindByText(dt.Rows[i][3].ToString()).Selected = true;
                            
                        }
                        rowIndex++;
                    }
                }
            }
        }
        catch { }
    }

    protected void LinkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data and reset row number
                    dt.Rows.Remove(dt.Rows[rowID]);
                    //ResetRowID(dt);
                }
            }

            //Store the current data in ViewState for future reference
            ViewState["CurrentTable"] = dt;

            //Re bind the GridView for the updated data
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
    }

    private void ResetRowID(DataTable dt)
    {
        int rowNumber = 1;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[0] = rowNumber;
                rowNumber++;
            }
        }
    }






    protected void txt_PaidAmount_TextChanged(object sender, EventArgs e)
    {
        double total = 0, paid = 0, rem = 0;

        try
        {
            total = double.Parse((Gridview1.FooterRow.FindControl("txt_FooterTotal") as TextBox).Text);
        }
        catch { }
        try
        {
            paid = double.Parse(txt_PaidAmount.Text);
        }
        catch { }

        rem = total - paid;

        txt_RemAmount.Text = rem.ToString();

    }
}

 


