<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="WebPages_CustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Customer  Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="White">
        Customer Id :
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="White">
        Customer Name :
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_Name" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="Cust_Name" ErrorMessage="Please Enter Name !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White">
        Password :
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_Password" runat="server" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="Cust_Password" ErrorMessage="Please Enter Password !!! "></asp:RequiredFieldValidator>
                  </td>
              </tr>
   
              <tr>
                  <td bgcolor="White">
            Customer Mobile No :
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_MobNo" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="Cust_MobNo" ErrorMessage="Please Enter Mobile No !!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                          ControlToValidate="Cust_MobNo" ErrorMessage="Please Enter Correct Contact !!!!" 
                          ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White">
            Customer Email :
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_Email" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="Cust_Email" ErrorMessage="Please Enter Email !!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                          ControlToValidate="Cust_Email" ErrorMessage="Please Enter Correct Email !!! " 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White">
            Customer Address :
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_Addr" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                          ControlToValidate="Cust_Addr" ErrorMessage="Please Enter Address !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White">
                      <asp:Button ID="Cust_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Cust_Save_Click"  />
                  </td>
                    <td bgcolor="White">
                        <asp:Button ID="Clear" runat="server" onclick="Clear_Click" Text="Clear" />
                        <asp:Label ID="Cust_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3" bgcolor="White">
     <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Cust_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="Cust_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Cust_Name" HeaderText="Name" />                    
                                                <asp:BoundField DataField="Cust_Password" HeaderText="Password" />                    
                                                
                                                <asp:BoundField DataField="Cust_MobNo" HeaderText="Mobile No" />                    
                                                <asp:BoundField DataField="Cust_Email" HeaderText="Email" />                                               
                                                <asp:BoundField DataField="Cust_Addr" HeaderText="Address" />                                               
                                               
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />                                 
                                          <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" /> 
                                        </Columns>
                             </asp:GridView>                  </td>
              </tr>
          </table>
        </div>

      </div>
</asp:Content>

