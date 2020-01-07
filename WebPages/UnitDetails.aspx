<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="UnitDetails.aspx.cs" Inherits="WebPages_UnitDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Unit Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        Unit Id :
                      </td>
                  <td>
                      <asp:TextBox ID="Unit_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Unit Name :
                      </td>
                  <td>
                      <asp:TextBox ID="Unit_Name" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Button ID="Unit_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Unit_Save_Click"  />
                  </td>
              
                  <td>
                      <asp:Button ID="Clear" runat="server" Text="Clear" ForeColor="#CC3300" 
                          onclick="Clear_Click" />
                      <asp:Label ID="Unit_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
   <td colspan="3"> <asp:GridView ID="gv_movimage" runat="server" 
           DataKeyNames="Unit_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          
           OnRowCancelingEdit="gv_movimage_RowCancelingEdit" 
           OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" 
           OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" 
           Font-Names="Times New Roman" onrowcommand="gv_movimage_RowCommand">
                                        <Columns>                               
                                                <asp:BoundField DataField="Unit_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Unit_Name" HeaderText="Name" />                    
                                               
                                                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />   
                                                 <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" />                                
                                        </Columns>
                             </asp:GridView>                    </td>
              </tr>
          </table>
        </div>

      </div>

</asp:Content>

