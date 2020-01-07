<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="AdminRegistration.aspx.cs" Inherits="WebPages_AdminRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Admin   Registration</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        User Id :
                      </td>
                  <td>
                      <asp:TextBox ID="Text_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        User Name :
                      </td>
                  <td>
                      <asp:TextBox ID="Text_Name" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="Text_Name" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Password :
                      </td>
                  <td>
                      <asp:TextBox ID="Text_Password" runat="server" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="Text_Password" ErrorMessage="Please Enter Password !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Mobile No :
                      </td>
                  <td>
                      <asp:TextBox ID="Text_MobileNo" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="Text_MobileNo" ErrorMessage="Enter Mobile No"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                          ControlToValidate="Text_MobileNo" 
                          ErrorMessage="Please Enter Correct Mobile No !!!!" 
                          ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Email :
                      </td>
                  <td>
                      <asp:TextBox ID="Text_Email" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="Text_Email" ErrorMessage="Please Enter Email !!!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                          ControlToValidate="Text_Email" ErrorMessage="Please Enter Correct Email !!!! " 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="Ad_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Ad_Save_Click" 
                          CausesValidation="true"    />
                  </td>
                    <td>
                        <asp:Button ID="Clear" runat="server" onclick="Clear_Click" Text="Clear" />
                        <asp:Label ID="Ad_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                              <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Ad_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="Ad_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Ad_Name" HeaderText="Name" />                    
                                                <asp:BoundField DataField="Ad_Password" HeaderText="Password" />                    
                                                <asp:BoundField DataField="Ad_Mobno" HeaderText="Mobile" />                                               
                                                <asp:BoundField DataField="Ad_Email" HeaderText="Email" />                                               
                                               
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" /> 
                                               <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" />                                 
                                        </Columns>
                             </asp:GridView>
                 </td>
              </tr>
          </table>
        </div>

      </div>
      <!-- /.container-fluid -->

</asp:Content>

