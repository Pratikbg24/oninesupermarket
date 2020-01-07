<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/AdminHomeMasterPage.master" AutoEventWireup="true" CodeFile="TransactionDetails.aspx.cs" Inherits="WebPages_TransactionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="align-items-xl-center" style="background-color: #FFFFFF">
        <br />
        <br />
           <h1 class="MyFont1">Transaction Master </h1> 
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <table class="MyFont3" >
                  <tr style="border: 0px solid black;">
                     <td colspan="2">
                         <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                             <ContentTemplate>
                                <asp:Label ID="lbl_Status" runat="server" Text="Status" ForeColor="Red" Visible="false"></asp:Label>                         
                             </ContentTemplate>
                        </asp:UpdatePanel>
                     </td>                     
                  </tr>
                  <tr>
                     <td>
                         <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                         Date :                        
                     </td>  
                      <td>
                         <asp:TextBox ID="txt_BillDate" runat="server"  ></asp:TextBox>                          
                          
                  </tr>
                  <tr>
                     <td>
                         <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                         Vendor Name :
                     </td>  
                     <td>
                         <asp:UpdateProgress runat="server" id="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img alt="Please Wait..." src="../Images/loader.gif" width="30" height="25" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                              <ContentTemplate>
                                    <asp:DropDownList ID="ddl_CustomerName" runat="server" 
                                        CssClass="dropdown-header" Font-Names="Times New Roman"  AutoPostBack="true" 
                                        Width="178px"></asp:DropDownList>
                              </ContentTemplate>
                          </asp:UpdatePanel>
                     </td>                     
                  </tr>
                 
                 
                  
                  <tr>
                      <td colspan="2">
                          <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
                          <asp:UpdateProgress runat="server" id="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2">
                                <ProgressTemplate>
                                    <img alt="Please Wait..." src="../Images/loader.gif" width="30" height="25" />
                                </ProgressTemplate>
                           </asp:UpdateProgress>

                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                              <ContentTemplate>
                                <asp:gridview ID="Gridview1"  runat="server"  ShowFooter="true" 
                                      AutoGenerateColumns="false" OnRowCreated="Gridview1_RowCreated" 
                                      Font-Names="Times New Roman" Width="536px" 
                                      >
                                    <Columns>
                                       <asp:TemplateField HeaderText="Product Name">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_ItemName" runat="server" AppendDataBoundItems="false" CssClass="dropdown-header">
                                                     <asp:ListItem Value="-1">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Batch">
                                            <ItemTemplate>
                                                <asp:textbox ID="txt_NECC" runat="server"  Width="70px" MaxLength="8" ></asp:textbox>                                                  
                                            </ItemTemplate>                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:textbox ID="txt_Quantity" runat="server"  Width="70px" MaxLength="8" ></asp:textbox>                                                  
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="Label9" runat="server" Text="Total:"></asp:Label>                                            
                                            </FooterTemplate> 
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Unit Name">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_UnitName" runat="server" AppendDataBoundItems="false" CssClass="dropdown-header">
                                                     <asp:ListItem Value="-1">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Rate">
                                            <ItemTemplate>
                                                        <asp:TextBox ID="txt_Rate" runat="server" OnTextChanged="Calculate" AutoPostBack="true"  Width="70px" MaxLength="8"></asp:TextBox>                                               
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txt_FooterTotal" runat="server" Width="70px" MaxLength="8"></asp:TextBox>
                                            </FooterTemplate>  
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Total" runat="server"  Width="70px" MaxLength="8"></asp:TextBox>                                           
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Center"  />
                                            <FooterTemplate>
                                                 <asp:Button ID="ButtonAdd" runat="server" Text="Next" onclick="ButtonAdd_Click" OnClientClick="return ValidateEmptyValue();"  />
                                            </FooterTemplate>                                        
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkDelete" runat="server" onclick="LinkDelete_Click" >Del</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:gridview>
                              </ContentTemplate>
                          </asp:UpdatePanel>
                      </td>
                  </tr>
                  <tr>
                     <td >
                         Paid Amount :
                     </td>  
                      <td>
                          <asp:UpdateProgress runat="server" id="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel3">
                            <ProgressTemplate>
                                <img alt="Please Wait..." src="../Images/loader.gif" width="30" height="25" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                              <ContentTemplate>
                                    <asp:TextBox ID="txt_PaidAmount" runat="server" AutoPostBack="True" 
                                        ontextchanged="txt_PaidAmount_TextChanged" ></asp:TextBox>  
                              </ContentTemplate>
                          </asp:UpdatePanel>
                       </td>                     
                  </tr>
                  <tr>
                     <td >
                         Remaining Amount :
                     </td>  
                      <td >
                          <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                              <ContentTemplate>
                                <asp:TextBox ID="txt_RemAmount" runat="server"  ></asp:TextBox>  
                              </ContentTemplate>
                          </asp:UpdatePanel>
                    </td>                     
                  </tr>
                  <tr>
                     <td style="text-align:center;">
                         <asp:UpdateProgress runat="server" id="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel4">
                            <ProgressTemplate>
                                <img alt="Please Wait..." src="../Images/loader.gif" width="30" height="25" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                             <ContentTemplate>
                                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="Button1_Click" 
                                     ForeColor="#FF3300" />
                             </ContentTemplate>
                         </asp:UpdatePanel>
                    </td>  
                <td>
                    <asp:UpdateProgress runat="server" id="UpdateProgress4" AssociatedUpdatePanelID="UpdatePanel9">
                        <ProgressTemplate>
                            <img alt="Please Wait..." src="../Images/loader.gif" width="30" height="25" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btn_Clear" runat="server" Text="Clear" ForeColor="#FF3300"  />  
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>                     
            </tr>           
        </table>
    </div>



</asp:Content>

