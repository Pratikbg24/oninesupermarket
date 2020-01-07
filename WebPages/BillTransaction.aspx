<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="BillTransaction.aspx.cs" Inherits="WebPages_BillTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Bill Transaction</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966" class="style1">
        Transaction Id :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="BillT_Id" runat="server" Height="25px"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="**Required Product Id** " ControlToValidate="BillT_Id" 
                ForeColor="Red"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style1">
        Bill Id :
                      </td>
                  <td class="style6">
                  
                  
                      <asp:DropDownList ID="Bill_Id" runat="server" Width="176px">
                      </asp:DropDownList>      
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style2">
            Product Name :
                      </td>
                  <td class="style3">
                     <asp:DropDownList ID="Prod_Id" runat="server" AutoPostBack="True" Height="27px" 
                          Width="176px">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style4">
                    
            Unit Name :
                      </td>
                  <td class="style5">
                      <asp:DropDownList ID="Unit_Id" runat="server" AutoPostBack="True" Height="27px" 
                          Width="178px">
                      </asp:DropDownList>
                  </td>
              </tr>
                     <tr>
                  <td bgcolor="#999966" class="style1">
        Product Quantity :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="Prod_Quantity" runat="server" Height="25px"></asp:TextBox>
                  </td>
              </tr>
                     <tr>
                  <td bgcolor="#999966" class="style1">
        Product Rate :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="Prod_Rate" runat="server" Height="25px"></asp:TextBox>
                  </td>
              </tr>

               <tr>
                  <td bgcolor="#999966" class="style1">
        Total :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="BillT_Total" runat="server" Height="25px"></asp:TextBox>
                  </td>
              </tr>

       
       
                  <td class="style1">
                      <asp:Button ID="Prod_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Prod_Save_Click"  />
                      <asp:Button ID="Prod_Update" runat="server" Text="Update" ForeColor="#CC3300" />
                  </td>
              
                  <td class="style6">
                      <asp:Button ID="Prod_Delete" runat="server" Text="Delete"  
                              ForeColor="#CC3300"  />
                      <asp:Button ID="Prod_Back" runat="server" Text="Back" ForeColor="#CC3300" />
                      <asp:Label ID="Prod_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                      
                            <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Prod_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>
                                               <asp:BoundField DataField="BillT_Id" HeaderText="Transaction Id" />
                                               <asp:BoundField DataField="Bill_Id" HeaderText="Bill MasterId" />
                                                               
                                                <asp:BoundField DataField="Prod_Id" HeaderText="Product Name" />
                                                <asp:BoundField DataField="Unit_Id" HeaderText="Unit Name" />                    
                                                <asp:BoundField DataField="Prod_Quantity" HeaderText="Quantity" />                                               
                                                <asp:BoundField DataField="Prod_Rate" HeaderText="Rate" />                    
                                                <asp:BoundField DataField="BillT_Total" HeaderText="Total" />
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />                                 
                                        </Columns>
                             </asp:GridView>
                  </td>
              </tr>
          </table>
        </div>

      </div>
 
</asp:Content>

