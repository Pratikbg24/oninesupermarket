<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="StockDetails.aspx.cs" Inherits="WebPages_StockDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Stock Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        Stock Id :
                      </td>
                  <td>
                      <asp:TextBox ID="Stock_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="**Required Product Id** " ControlToValidate="Stock_Id" 
                ForeColor="Red"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Product Id :
                      </td>
                  <td>
                      <asp:DropDownList ID="Prod_Id" runat="server" Height="27px" Width="190px">
                      </asp:DropDownList>           </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Quantity :
                      </td>
                  <td>
                      <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Rate :
                      </td>
                  <td>
                      <asp:TextBox ID="Rate" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="Stock_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Stock_Save_Click"  />
                      <asp:Button ID="Stock_Update" runat="server" Text="Update" ForeColor="#CC3300" />
                  </td>
              
                  <td>
                      <asp:Button ID="Stock_Delete" runat="server" Text="Delete"  
                              ForeColor="#CC3300"  />
                      <asp:Button ID="Stock_Back" runat="server" Text="Back" ForeColor="#CC3300" />
                      <asp:Label ID="Stcok_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                      <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Stock_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>
                                         <asp:BoundField DataField="Stock_Id" HeaderText="Id" />                               
                                                <asp:BoundField DataField="Prod_Id" HeaderText="Prod_Id" />
                                                <asp:BoundField DataField="Prod_Quantity" HeaderText="Quantity" />                    
                                                <asp:BoundField DataField="Prod_Rate" HeaderText="Rate " />                    
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />                                 
                                        </Columns>
                             </asp:GridView>
                  </td>
              </tr>
          </table>
        </div>

      </div>

</asp:Content>

