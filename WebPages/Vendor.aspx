<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" Inherits="WebPages_Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Vendor  Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        Vendor Id :
                      </td>
                  <td>
                      <asp:TextBox ID="Ven_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Vendor Name :
                      </td>
                  <td>
                      <asp:TextBox ID="Ven_Name" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="Ven_Name" ErrorMessage="Please Enter Name !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Vendor Mobile No :
                      </td>
                  <td>
                      <asp:TextBox ID="Ven_MobNo" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="Ven_MobNo" ErrorMessage="Please Enter Mobile No !!! "></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                          ControlToValidate="Ven_MobNo" ErrorMessage="Please Enter Correct Mobile No !!!" 
                          ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Vendor Email :
                      </td>
                  <td>
                      <asp:TextBox ID="Ven_Email" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="Ven_Email" ErrorMessage="Please Enter Email !!!"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                          ControlToValidate="Ven_Email" ErrorMessage="Please Enter Correct Email !!!" 
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
            Openinh Balance :
                      </td>
                  <td>
                      <asp:TextBox ID="Ven_OpeningBal" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                          ControlToValidate="Ven_OpeningBal" 
                          ErrorMessage="Please Enter Opening Balance !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
          
              <tr>
                  <td bgcolor="#999966">
            Vendor Address :
                      </td>
                  <td>
                      <asp:TextBox ID="Ven_Addr" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="Ven_Addr" ErrorMessage="Please Enter Address !!!"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="Ven_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Ven_Save_Click"  />
                  </td>
                    <td>
                      <asp:Button ID="Ven_Clear" runat="server" Text="Clear" ForeColor="#CC3300" 
                            onclick="Ven_Clear_Click" />
                        <asp:Label ID="Ven_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                      
     <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Ven_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="Ven_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Ven_Name" HeaderText="Name" />                    
                                                <asp:BoundField DataField="Ven_MobNo" HeaderText="Mobile No" />                    
                                                <asp:BoundField DataField="Ven_Emali" HeaderText="Email" />                                               
                                                <asp:BoundField DataField="Ven_Addr" HeaderText="Address" />                                               
                                                <asp:BoundField DataField="Ven_DueAmt" HeaderText ="DueAmt" />
                                                   <asp:BoundField DataField="Ven_OpeningBal" HeaderText ="Bal" />

                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />  
                                                <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" />
                                        </Columns>
                             </asp:GridView>                            </td>
              </tr>
          </table>
        </div>

      </div>

</asp:Content>

