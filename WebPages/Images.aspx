<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="WebPages_Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content-wrapper">

      <div class="container-fluid" align="center">
          <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Images Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966">
        Image Id :
                      </td>
                  <td>
                      <asp:TextBox ID="Img_Id" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Product Id :
                      </td>
                  <td>
                      <asp:DropDownList ID="Prod_Id" runat="server" Width="192px">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966">
        Image Path :
                      </td>
                  <td>
                      <asp:TextBox ID="Img_Path" runat="server"></asp:TextBox>
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                      <asp:Button ID="Image_Upload" runat="server" Text="Upload" ForeColor="#CC3300" 
                          onclick="Image_Upload_Click" />
                  </td>
              </tr>
              
              <tr>
                  <td>
                      <asp:Button ID="Image_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Image_Save_Click"  />
                  </td>
              
                  <td>
                      <asp:Button ID="Clear" runat="server" onclick="Clear_Click" Text="Clear" />
                      <asp:Label ID="lbl_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                         <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Img_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="Img_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Prod_Id" HeaderText="Prod_Id" />                    
                                                <asp:BoundField DataField="Img_Path" HeaderText="Path" />                    
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

