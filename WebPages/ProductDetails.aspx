<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="WebPages_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 163px;
        }
        .style2
        {
            width: 163px;
            height: 30px;
        }
        .style3
        {
            height: 30px;
            width: 181px;
        }
        .style4
        {
            width: 163px;
            height: 29px;
        }
        .style5
        {
            height: 29px;
            width: 181px;
        }
        .style6
        {
            width: 181px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div id="content-wrapper">

      <div class="container-fluid" align="center">
              <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Product Details</a>
          </li>
                 </ol>

          <table align="center" bgcolor="Silver">
              <tr>
                  <td bgcolor="#999966" class="style1">
        Product Id :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="Prod_Id" runat="server" Height="25px"></asp:TextBox>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style1">
        Product Name :
                      </td>
                  <td class="style6">
                      <asp:TextBox ID="Prod_Name" runat="server" Height="25px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style2">
            Unit Id :
                      </td>
                  <td class="style3">
                     <asp:DropDownList ID="Unit_Id" runat="server" AutoPostBack="True" Height="27px" 
                          Width="177px">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999966" class="style4">
                    
            Group Id :
                      </td>
                  <td class="style5">
                      <asp:DropDownList ID="Grp_Id" runat="server" AutoPostBack="True" Height="27px" 
                          Width="177px">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td class="style1">
                      <asp:Button ID="Prod_Save" runat="server" Text="Save"  
                              ForeColor="#CC3300" onclick="Prod_Save_Click"  />
                  </td>
              
                  <td class="style6">
                      <asp:Button ID="Clear" runat="server" onclick="Clear_Click" Text="Clear" />
                      <asp:Label ID="Prod_Status" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
        
                            <asp:GridView ID="gv_movimage" runat="server" DataKeyNames="Prod_Id" AutoGenerateColumns="false" OnPageIndexChanging="gv_movimage_PageIndexChanging" 
                                          OnRowCancelingEdit="gv_movimage_RowCancelingEdit" OnRowDeleting="gv_movimage_RowDeleting" OnRowEditing="gv_movimage_RowEditing"
                                           OnRowUpdating="gv_movimage_RowUpdating" OnSelectedIndexChanged="gv_movimage_SelectedIndexChanged" Font-Names="Times New Roman">
                                        <Columns>                               
                                                <asp:BoundField DataField="Prod_Id" HeaderText="Id" />
                                                <asp:BoundField DataField="Prod_Name" HeaderText="Name" />                    
                                                <asp:BoundField DataField="Unit_Id" HeaderText="Unit Name" />                    
                                                <asp:BoundField DataField="Grp_Id" HeaderText="Group Name" />                                               
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

