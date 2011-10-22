<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyInfo.aspx.cs" Inherits="SurveyInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                <tr>                             
                    <td><%# Eval("FirstName")%></td>
                    <td><%# Eval("LastName")%></td>
                    <td><%# Eval("BullyOthersCount")%></td>    
                    <td><%# Eval("BulliedByOthersCount")%></td>  
                    <td><%# Eval("Comments")%></td>                                       
                </tr>
            </ItemTemplate>
                   
            <EditItemTemplate> 
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
                        <asp:TextBox ID="Label1" runat="server" Text='<%# Eval("Comments") %>' />
                    </td>                                    
                   
                </tr> 
            </EditItemTemplate>
                   
        </asp:ListView>

 
    </div>
    </form>
</body>
</html>
