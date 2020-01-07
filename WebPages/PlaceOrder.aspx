<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/UserMasterPage.master" AutoEventWireup="true" CodeFile="PlaceOrder.aspx.cs" Inherits="WebPages_PlaceOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../css/CommonFonts.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<br />
<br />
<br /><br /><br /><br />
<br />


<table align="center" class="center-block" >
      
     

           <tr>

      <td colspan="2" >
  <h1>       <asp:Label ID="Label1" runat="server" Text="Confirm Order" ForeColor="Red"></asp:Label></h1> 
  </td>
  </tr>
  
    <tr>
            <td >
                      <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
    
            </td>
            <td >
                <asp:TextBox ID="Cust_Name" runat="server" Width="173px" EnableTheming="True" 
                    Enabled="False"></asp:TextBox>
            <asp:DropDownList ID="ddl_Prod_Name" runat="server" Height="25px"  AutoPostBack="true"
              Width="111px" onselectedindexchanged="ddl_Prod_Name_SelectedIndexChanged" 
              ontextchanged="ddl_Prod_Name_TextChanged" Visible="False">
          </asp:DropDownList>
    

            </td>
    </tr>
    <tr>
        <td >
          <asp:Label ID="Label4" runat="server" Text="Mobile No:"></asp:Label>
        
        
        </td>
        <td >
      <asp:TextBox ID="Cust_Mobno" runat="server" Width="177px" Enabled="False" 
              EnableTheming="True"></asp:TextBox> &nbsp; 
          <asp:TextBox ID="Txt_Batch" runat="server" Visible="False" Width="95px" 
                Enabled="False"></asp:TextBox>
    
    
            <asp:TextBox ID="Txt_Quantity" runat="server" Enabled="False" Visible="False"></asp:TextBox>
    
    
        </td>
    </tr>
    
    <tr>
        <td >
                <asp:Label ID="Label3" runat="server" Text="EMail"></asp:Label>
        
        </td>
        <td >
                <asp:TextBox ID="Cust_Email" runat="server" Width="177px" 
              ontextchanged="Txt_Quantity_TextChanged" AutoPostBack="True" Enabled="False"></asp:TextBox> &nbsp; 
          <asp:DropDownList ID="ddl_UnitName" runat="server" Height="28px" Width="64px" 
              Enabled="False" Visible="False">
          </asp:DropDownList>      
        </td>
    
    </tr>    
    
    <tr>
        <td >
                 <asp:Label ID="Label5" runat="server" Text="Address:"></asp:Label>
      
        </td>
        <td >
             <asp:TextBox ID="Cust_Addr" runat="server" Width="178px" Enabled="False" 
              ontextchanged="Txt_Total_TextChanged"></asp:TextBox> &nbsp; 
     
               <asp:TextBox ID="Txt_CT_Id" runat="server" Width="85px" Visible="False"></asp:TextBox>
        
        </td>
        
    
    </tr>
    <tr>
            <td colspan="2" >
                <asp:TextBox ID="Unit_Id" runat="server" Width="85px" Visible="False"></asp:TextBox>
          <asp:TextBox ID="Prod_Id" runat="server" Width="85px" Visible="False"></asp:TextBox>
          <asp:TextBox ID="Txt_CM_Id" runat="server" Visible="False" Width="81px"></asp:TextBox>
           
                <asp:Button ID="btn_Save" runat="server" Text="Save" onclick="btn_Save_Click1" Visible="false"
                    Width="207px" />

           </td>
        
    
    </tr>   
    <tr>
        <td>
        
          <asp:Label ID="Label6" runat="server" Text="All Total :"></asp:Label>
          </td>
          <td>

          <asp:TextBox ID="Txt_AllTot" runat="server" Width="89px" Enabled="False"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
        <td>
        
          <asp:Label ID="Label7" runat="server" Text="Delivary Charges :"></asp:Label>
          </td>
          <td>

          <asp:TextBox ID="Txt_DelCharg" runat="server" Width="89px" Enabled="False" 
                  ontextchanged="Txt_DelCharg_TextChanged"></asp:TextBox>
        
        </td>
     </tr>
     <tr>
         <td>
        
          <asp:Label ID="Label8" runat="server" Text="Final Total :"></asp:Label>
          </td>
          <td>

          <asp:TextBox ID="Bill" runat="server" Width="89px" Enabled="False"></asp:TextBox>
        
        </td>

    </tr>
    <tr>
    <td colspan="2">
              <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="CT_Id" 
              AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          
              OnRowCancelingEdit="gv_movimage_RowCancelingEdit" 
              OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" 
              OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" 
              Font-Names="Times New Roman" Height="17px" Width="698px">
                                        <Columns>                               
                                                <asp:BoundField DataField="CT_Id" HeaderText="Id" Visible="true" />
                                                <asp:BoundField DataField="Prod_Name" HeaderText="Product Name" />   
                                              
                                                
                                               
                                                <asp:BoundField DataField="Prod_Quantity" HeaderText="Quantity" />   
                                               
                                               <asp:BoundField DataField="Unit_Name" HeaderText="Unit Name" />   
                                                <asp:BoundField DataField="Prod_Rate" HeaderText="Rate" />   
                                                <asp:BoundField DataField="Prod_Total" HeaderText="Total" />   
                                               <asp:BoundField DataField="Unit_Id" HeaderText="Unit Id" Visible="false"/>   
                                                <asp:BoundField DataField="Prod_Id" HeaderText="Product Id" Visible="true" />   
                                               <asp:BoundField DataField="Batch" HeaderText="Batch" Visible="true"/>   
                                               <asp:BoundField DataField="CM_Id" HeaderText="Master Id" Visible="true" />   
                                               
                                           
                                                
                                                                 
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" Visible="false" />                                 
                                         <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" Visible="false" />                         
                                        </Columns>
                             </asp:GridView>     

    </td>
    
    </tr>
    
     <tr><td>
      <asp:Button ID="Order" runat="server" Text="Payment" BackColor="#66FFFF" 
          ForeColor="Red" onclick="Order_Click" Enabled="False" />
           </td>

      
      </tr>
    <tr align="center"> 
    <td align="center">

        <asp:RadioButton ID="RadioButton1" runat="server" Text="Cash On Delivary"  
            ForeColor="Red"  Width="329px" Font-Bold="true" BackColor="#66FFCC" 
            BorderColor="Red" AutoPostBack="True" GroupName="Payment" Checked="True"/>
    <br /><br />
     <asp:RadioButton ID="RadioButton2" runat="server" Text=" Card  Payment"  ForeColor="Red" 
            Width="329px" Font-Bold="true" BackColor="#66FFFF" BorderColor="Red" 
            AutoPostBack="True" GroupName="Payment" />
   

        </td>
    </tr>
    
    <tr>
    <td align="center">
    <asp:Button ID="Next" runat="server" Text="Confirm Order" ForeColor="Red" 
            Width="200px" Font-Bold="true" BackColor="#66FFFF" BorderColor="Red" onclick="Next_Click"
             />
      </td>
      </tr>
 </table>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />


</asp:Content>

