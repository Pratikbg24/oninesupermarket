<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="GroupMaster.aspx.cs" Inherits="WebPages_GroupMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Group Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        Group Id :
                      </td>
                  <td>
                      <asp:TextBox ID="Grp_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Group Name :
                      </td>
                  <td>
                      <asp:TextBox ID="Grp_Name" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="Grp_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Grp_Save_Click"  />
                  </td>
              
                  <td>
                      <asp:Button ID="Clear" runat="server" onclick="Clear_Click" Text="Clear" />
                      <asp:Label ID="Grp_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3"> <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Grp_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="Grp_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Grp_Name" HeaderText="Name" />                    
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

