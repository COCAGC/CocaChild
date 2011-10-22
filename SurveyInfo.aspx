<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/StudentSite.master" CodeFile="SurveyInfo.aspx.cs" Inherits="SurveyInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
          <asp:ListView ID="lvStudentBullyList" runat="server" Visible="true" >
            <LayoutTemplate>            
                <table id="tableOne" class="yui">    
                    <tr class="header">                         
                        <th style="text-align: left">                         
                            <asp:Label runat="server" ID="FirstName">First Name</asp:Label>                          
                        </th>                    
                        <th style="text-align: left">
                            <asp:Label runat="server" ID="LastName">Last Name</asp:Label>                          
                        </th>
                        <th style="text-align: left">
                            <asp:Label runat="server" ID="BullyOthersCount">Bully others Count</asp:Label>                          
                        </th>
                        <th style="text-align: left">
                            <asp:Label runat="server" ID="BulliedByOthersCount">Bullied By others Count</asp:Label>                         
                        </th>
                        <th style="text-align: left">
                            <asp:Label runat="server" ID="Comments">Comments</asp:Label>                       
                        </th>
                         <th style="text-align: left"></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                            
                </table>     
            </LayoutTemplate>
                         
            <ItemTemplate> 
                <tr style="">
                    <td>
                        <asp:Label ID="lblEditFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>  
                     <td>
                        <asp:Label ID="lblEditLastName" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>                                        
                    <td>                                        
                        <asp:DropDownList ID="ddlBullyOthersCountID" runat="server"  DataTextField="BullyOthersCount" DataValueField="BullyOthersCount" >
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>        
                    </td>   
                    
                     <td>                      
                        <asp:DropDownList ID="ddlBulliedByOthersCount" runat="server" DataTextField="BulliedByOthersCount" DataValueField="BulliedByOthersCount" >
                         <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>        
                    </td>  

                    <td>
                        <asp:TextBox ID="txtComments" runat="server" Text='<%# Eval("Comments") %>' />
                    </td>                                    
                   
                </tr> 
            </ItemTemplate>
                   
        </asp:ListView>

 <asp:Button Text="Finished" runat="server"  ID="FinishedId" onclick="FinishedId_Click"/>
    </div>
    </asp:Content>
    

