<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/UserMasterPage.master" AutoEventWireup="true" CodeFile="ViewItems.aspx.cs" Inherits="WebPages_ViewItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
      <br />  
   <div class="jumbotron" style="width:60%; margin:0 auto;">
  <table align="center" class="table-responsive">
  

   <tr>
        <td>
        
    <asp:Button ID="Go" runat="server" Text="Go to Cart >>>>>>" BackColor="Red" 
        BorderColor="Red" ForeColor="Black" onclick="Go_Click" Width="160px" Font-Bold="true" />
        
        
        </td>
   
   </tr>
   <tr>
        
   <asp:DataList ID="Rep" runat="server" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" 
        RepeatColumns="4" RepeatDirection="Horizontal" Width="100%" 
           class="text-center" OnItemCommand="AddToCartClick" 
           onselectedindexchanged="Rep_SelectedIndexChanged"><%-- OnItemDataBound="dl_ItemDataBound" DataKeyField="R_Id">--%>
        <ItemTemplate>
       <asp:HiddenField ID="HiddenField3" Value='<%# Bind("Unit_Id") %>' runat="server" />
        <asp:HiddenField ID="HiddenField2" Value='<%# Bind("Prod_Rate") %>' runat="server" />
         <asp:HiddenField ID="HiddenField1" Value='<%# Bind("Prod_Id") %>' runat="server" />
         <asp:HiddenField ID="HiddenField4" Value='<%# Bind("Stock_Id") %>' runat="server" />
        
            Product Name:
            <asp:Label ID="lblProductNane" runat="server" Text='<%# Bind("Prod_Name") %>'></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" GenerateEmptyAlternateText="True" Height="100px" ImageUrl='<%# Eval("Img_Path") %>' Width="100px" />
            <br />
            Price:
            <asp:Label ID="lblListPrice" runat="server" Text='<%# Eval("Prod_Rate") %>'></asp:Label> ₹
           
            <br />
            Qty:
            <asp:TextBox ID="Txt_Quantity" runat="server" Width="40"  Height="18">
             </asp:TextBox> <asp:Label ID="Unit_Name" runat="server" Text='<%# Eval("Unit_Name") %>'></asp:Label>
        
               <br />
             
               <asp:TextBox ID="Batch" runat="server" Text='<%# Eval("Batch")%>'  Width="70"  Height="18" Visible="False"></asp:TextBox>
            <br />
       
            <asp:Button ID="Btn_AddCart" runat="server" Text="Add to Cart" CommandName="add" Width="139px" BackColor="#FF8000" 
        BorderColor="#FF6600" ForeColor="#000066" Font-Bold="true" />
                        
        </ItemTemplate>
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    </asp:DataList>
   
   </tr>
  

   </table>
  </div>

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
  
</asp:Content>

