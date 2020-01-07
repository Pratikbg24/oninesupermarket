<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/UserMasterPage.master" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="WebPages_ConformOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 35px;
        }
        .style2
        {
            height: 35px;
            width: 264px;
        }
        .style3
        {
            width: 264px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="container-fluid"  align="center">
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
   <div id="Div1">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Customer  Registration</a>
          </li>
                 </ol>

          <table class="container-fluid" align="center" bgcolor="Silver">
               <tr>
                  <td bgcolor="White">
    
                      </td>
                  <td bgcolor="White">
                      <asp:TextBox ID="Cust_Id" runat="server" Visible="False"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="White" class="style2" align="justify">
        Customer Name :
                      <br />
                      </td>
                  <td bgcolor="White" class="style1" align="justify">
                      <asp:TextBox ID="Cust_Name" runat="server" Height="33px" Width="231px"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="Cust_Name" ErrorMessage="Please Enter Name !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White" align="justify" class="style3">
        Password :
                      <br />
                      </td>
                  <td bgcolor="White" align="justify">
                      <asp:TextBox ID="Cust_Password" runat="server" TextMode="Password" 
                          Height="33px" Width="231px"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="Cust_Password" ErrorMessage="Please Enter Password !!! "></asp:RequiredFieldValidator>
                  </td>
              </tr>
   
              <tr>
                  <td bgcolor="White" align="justify" class="style3">
            Customer Mobile No:<br />
&nbsp;</td>
                  <td bgcolor="White" align="justify">
                      <asp:TextBox ID="Cust_MobNo" runat="server" Height="33px" Width="231px"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="Cust_MobNo" ErrorMessage="Please Enter Mobile No !!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                          ControlToValidate="Cust_MobNo" ErrorMessage="Please Enter Correct Contact !!!!" 
                          ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White" align="justify" class="style3">
            Customer Email :
                      <br />
                      </td>
                  <td bgcolor="White" align="justify">
                      <asp:TextBox ID="Cust_Email" runat="server" Height="33px" Width="231px"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="Cust_Email" ErrorMessage="Please Enter Email !!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                          ControlToValidate="Cust_Email" ErrorMessage="Please Enter Correct Email !!! " 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White" align="justify" class="style3">
            Customer Address :<br />
&nbsp;</td>
                  <td bgcolor="White" align="justify">
                      <asp:TextBox ID="Cust_Addr" runat="server" Height="33px" Width="231px"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                          ControlToValidate="Cust_Addr" ErrorMessage="Please Enter Address !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="White" class="style3">
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
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" 
                          OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" 
                          OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" 
                          Font-Names="Times New Roman" Visible="False" Width="560px">
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

          </table><br /><br /><br />

<br /><br /><br /><br /> <br /><br /><br />






        </div>

      </div>
</asp:Content>

