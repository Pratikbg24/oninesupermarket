<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/UserMasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="WebPages_ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../css/CommonFonts.css" rel="stylesheet" type="text/css" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<br />
<br />
<br /><br /><br /><br />
<br />
<br /><br /><br /><br /><br />

<table align="center" class="center-block" >
      
      <tr><td>
      <asp:Button ID="Order" runat="server" Text="Conform Order" BackColor="#66FFFF" 
          ForeColor="Red" onclick="Order_Click" />
           </td>

      
      </tr>

           <tR>

      <td colspan="2" >
  <h1> <asp:Label ID="Label1" runat="server" Text="View My Cart" ForeColor="Red"></asp:Label></h1> 
  </td>
  </tr>
  
    <tr>
            <td >
                      <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
    
            </td>
            <td >
            <asp:DropDownList ID="ddl_Prod_Name" runat="server" Height="25px"  AutoPostBack="true"
              Width="111px" onselectedindexchanged="ddl_Prod_Name_SelectedIndexChanged" 
              ontextchanged="ddl_Prod_Name_TextChanged">
          </asp:DropDownList>
    

            </td>
    </tr>
    <tr>
        <td >
          <asp:Label ID="Label4" runat="server" Text="Rate"></asp:Label>
        
        
        </td>
        <td >
      <asp:TextBox ID="Txt_Rate" runat="server" Width="62px" Enabled="False" 
              EnableTheming="True"></asp:TextBox> &nbsp; 
          <asp:TextBox ID="Txt_Batch" runat="server" Visible="False" Width="95px"></asp:TextBox>
    
    
        </td>
    </tr>
    
    <tr>
        <td >
                <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
        
        </td>
        <td >
                <asp:TextBox ID="Txt_Quantity" runat="server" Width="68px" 
              ontextchanged="Txt_Quantity_TextChanged" AutoPostBack="True"></asp:TextBox> &nbsp; 
          <asp:DropDownList ID="ddl_UnitName" runat="server" Height="28px" Width="64px" 
              Enabled="False">
          </asp:DropDownList>      
        </td>
    
    </tr>    
    
    <tr>
        <td >
                 <asp:Label ID="Label5" runat="server" Text="Total"></asp:Label>
      
        </td>
        <td >
             <asp:TextBox ID="Txt_Total" runat="server" Width="68px" Enabled="False" 
              ontextchanged="Txt_Total_TextChanged"></asp:TextBox> &nbsp; 
     
               <asp:TextBox ID="Txt_CT_Id" runat="server" Width="85px" Visible="False"></asp:TextBox>
        
        </td>
        
    
    </tr>
    <tr>
            <td colspan="2" >
                <asp:TextBox ID="Unit_Id" runat="server" Width="85px" Visible="False"></asp:TextBox>
          <asp:TextBox ID="Prod_Id" runat="server" Width="85px" Visible="False"></asp:TextBox>
          <asp:TextBox ID="Txt_CM_Id" runat="server" Visible="False" Width="81px"></asp:TextBox>
           
                <asp:Button ID="btn_Save" runat="server" Text="Update" onclick="btn_Save_Click1" 
                    Width="207px" Font-Bold="True" Font-Italic="False" ForeColor="Red" />

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
    <td colspan="2">
              <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="CT_Id" 
              AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          
              OnRowCancelingEdit="gv_movimage_RowCancelingEdit" 
              OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" 
              OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" 
              Font-Names="Times New Roman" Height="17px" Width="698px">
                                        <Columns>                               
                                                <asp:BoundField DataField="CT_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Prod_Name" HeaderText="Product Name" />   
                                              
                                                
                                               
                                                <asp:BoundField DataField="Prod_Quantity" HeaderText="Quantity" />   
                                               
                                               <asp:BoundField DataField="Unit_Name" HeaderText="Unit Name" />   
                                                <asp:BoundField DataField="Prod_Rate" HeaderText="Rate" />   
                                                <asp:BoundField DataField="Prod_Total" HeaderText="Total" />   
                                               <asp:BoundField DataField="Unit_Id" HeaderText="Unit Id" />   
                                                <asp:BoundField DataField="Prod_Id" HeaderText="Product Id" />   
                                               <asp:BoundField DataField="Batch" HeaderText="Batch" />   
                                               <asp:BoundField DataField="CM_Id" HeaderText="Master Id" />   
                                               
                                           
                                                
                                                                 
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />                                 
                                         <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" />                         
                                        </Columns>
                             </asp:GridView>     

    </td>
    
    </tr>
    </table>
   
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

</asp:Content>

