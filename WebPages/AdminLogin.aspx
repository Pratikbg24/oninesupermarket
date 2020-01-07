<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="WebPages_Adminogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CommonFonts.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;



          <table align="center" bgcolor="Silver">
              <tr>
                  <td >
      
  <div class="container">
    <div class="card card-login mx-auto mt-5" align="center">
      <div class="card-header" align="center">Login</div>
      <div class="card-body">
        
      <asp:Label ID="Label1" runat="server" Text="Email ID "></asp:Label>  
   
      <asp:TextBox ID="Txt_Email" runat="server" Height="36px"  Width="284px"></asp:TextBox>         
      <div class="form-group"><br />
             
          <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label> 

          <asp:TextBox ID="Txt_Pass" runat="server" Height="36px" TextMode="Password" 
                    Width="286px"></asp:TextBox></div>
          <a  href="AdminRegistration.html">
      <asp:Button ID="Btn_Login" runat="server" Text="Login" BackColor="#0033CC" 
              BorderColor="#0033CC" ForeColor="Black" onclick="Btn_Login_Click" /></a>
        
    </div>
  </div>
      
      
      
                      </td>
              </tr>

  </table>
 
</asp:Content>

