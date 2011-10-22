<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateSchool.aspx.cs" Inherits="CreateSchool" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create School</title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            width: 208px;
        }
        .style3
        {
            height: 23px;
            width: 208px;
        }
    </style>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">    
        <asp:Label ID="lblSchool" runat="server" 
            Text="Create School" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
        <br />
        <br />
        <br />
    </div>
    <div align="center">    
    <table style="width: 60%;">
        <tr>
            <td class="style2" align="right">
                &nbsp;
                School Name</td>
            <td align="left">
                <asp:TextBox ID="txtSchool" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Address 
                Line 1</td>
            <td align="left">                
                <asp:TextBox ID="txtAddress1" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Address Line 2</td>
            <td align="left">                
                <asp:TextBox ID="txtAddress2" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Address Line 3</td>
            <td align="left">                
                <asp:TextBox ID="txtAddress3" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">                
                City</td>
            <td class="style1" align="left">                
                <asp:TextBox ID="txtCity" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
                State
                </td>
            <td class="style1" align="left">
                <asp:DropDownList ID="ddlStates" runat="server" Width="139px" >
                </asp:DropDownList>
&nbsp;&nbsp; Zip
                <asp:TextBox ID="txtZip" runat="server" MaxLength="10" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
                &nbsp;</td>
            <td class="style1" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="style1" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
</div>    
    </form>
    </body>
</html>
