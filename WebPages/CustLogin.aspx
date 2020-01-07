<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/UserMasterPage.master" AutoEventWireup="true" CodeFile="CustLogin.aspx.cs" Inherits="WebPages_CustLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
          <table align="center" bgcolor="Silver">
                   <tr>
                          <td align="center" >
      
                           <div class="container">
                                <div class="card card-login mx-auto mt-5">
                                    <div class="card-header">Customer Login</div>
                                       <div class="card-body">
        
                                             <asp:Label ID="Label1" runat="server" Text="Email ID "></asp:Label>  
   
                                              <asp:TextBox ID="Txt_Email" runat="server" Height="36px"  Width="284px"></asp:TextBox>         
                                               <div class="form-group"><br />
             
                                                   <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label> 

                                                   <asp:TextBox ID="Txt_Pass" runat="server" Height="36px" TextMode="Password"  Width="286px"></asp:TextBox>
                                                   </div>
                                                <a  href="PlaceOrder.html">
                                                 <asp:Button ID="Btn_Login" runat="server" Text="Login" BackColor="#0033CC" 
                                                  BorderColor="#0033CC" ForeColor="Black" onclick="Btn_Login_Click" /></a>
        
                                          </div>
                                      </div>
                                        </div>
      
      
             </td>
              </tr>

  </table>
 





 <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />




</asp:Content>

