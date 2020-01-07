<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="DelBoyDetails.aspx.cs" Inherits="WebPages_DelBoyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Delivery Boy  Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        Delivery Boy Id :
                      </td>
                  <td>
                      <asp:TextBox ID="DelBoy_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Delivery Boy Name :
                      </td>
                  <td>
                      <asp:TextBox ID="DelBoy_Name" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="DelBoy_Name" ErrorMessage="Please Enter Name !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Delivary Boy Mobile No :
                      </td>
                  <td>
                      <asp:TextBox ID="DelBoy_MobNo" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="DelBoy_MobNo" ErrorMessage="Please Enter Mobile No!!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                          ControlToValidate="DelBoy_MobNo" 
                          ErrorMessage="Please Enter Correct Mobile No !!!!" 
                          ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Delivary Boy Email :
                      </td>
                  <td>
                      <asp:TextBox ID="DelBoy_Email" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="DelBoy_Email" ErrorMessage="Please Enter Email !!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                          ControlToValidate="DelBoy_Email" 
                          ErrorMessage="Please Enter Correct Contact !!!!" 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
           Delivary Boy Address :
                      </td>
                  <td>
                      <asp:TextBox ID="DelBoy_Addr" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="DelBoy_Addr" ErrorMessage="Pleas Enter Address !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="DelBoy_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="DelBoy_Save_Click"  />
                  </td>
                    <td>
                        <asp:Button ID="Clear" runat="server" onclick="Clear_Click" Text="Clear" />
                        <asp:Label ID="DelBoy_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                     <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="DelBoy_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="DelBoy_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="DelBoy_Name" HeaderText="Name" />                    
                                              
                                                <asp:BoundField DataField="DelBoy_MobNo" HeaderText="Mobile No" />                    
                                                <asp:BoundField DataField="DelBoy_Email" HeaderText="Email" />                                               
                                                <asp:BoundField DataField="DelBoy_Addr" HeaderText="Address" />                                               
                                             
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />
                                                   <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" />                                   
                                        </Columns>
                             </asp:GridView>
                  </td>
              </tr>
          </table>
        </div>

      </div>

</asp:Content>

