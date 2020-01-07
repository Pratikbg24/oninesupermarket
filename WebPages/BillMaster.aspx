<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="BillMaster.aspx.cs" Inherits="WebPages_BillMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Bill Master</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966" class="style1">
        Bill Id :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="Bill_Id" runat="server" Height="25px"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="**Required Product Id** " ControlToValidate="Bill_Id" 
                ForeColor="Red"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style1">
        Customer Id :
                      </td>
                  <td class="style6">
                  
                  
                      <asp:DropDownList ID="Cust_Id" runat="server" Width="176px">
                      </asp:DropDownList>      
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style2">
            Bill Date :
                      </td>
                  <td class="style3">
                      <asp:TextBox ID="Bill_Date" runat="server"></asp:TextBox>
                  </td>
              </tr>
                     <tr>
                  <td bgcolor="#999966" class="style1">
                Bill Total Amout  :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="Bill_TotAmt" runat="server" Height="25px"></asp:TextBox>
                  </td>
              </tr>
       
                  <td class="style1">
                      <asp:Button ID="Bill_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Bill_Save_Click"   />
                      <asp:Button ID="Bill_Update" runat="server" Text="Update" ForeColor="#CC3300" />
                  </td>
              
                  <td class="style6">
                      <asp:Button ID="Bill_Delete" runat="server" Text="Delete"  
                              ForeColor="#CC3300"  />
                      <asp:Button ID="Bill_Back" runat="server" Text="Back" ForeColor="#CC3300" />
                      <asp:Label ID="Bill_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                      
                            <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Bill_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>
                                               <asp:BoundField DataField="Bill_Id" HeaderText="Bill Master Id" />
                                               <asp:BoundField DataField="Cust_Id" HeaderText="Customer Id" />
                                                <asp:BoundField DataField="Bill_Date" HeaderText="Bill Date" />                    
                                                <asp:BoundField DataField="Bill_TotAmt" HeaderText="Total Amount" />                                               
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />                                 
                                        </Columns>
                             </asp:GridView>
                  </td>
              </tr>
          </table>
        </div>

      </div>


</asp:Content>

