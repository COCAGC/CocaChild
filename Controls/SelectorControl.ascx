<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectorControl.ascx.cs" Inherits="SelectorControl" %>

<div align="center">
    <table style="width: 50%;">
        <tr>
            <td align="right">
                Select School:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlSchool" runat="server" 
                    onselectedindexchanged="ddlSchool_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td align="right">
                Select Year:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlYear" runat="server" 
                    onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>     
        </tr>
        <tr>
            <td align="right">
                Select Group Name:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlGroupName" runat="server" 
                    onselectedindexchanged="ddlGroupName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td align="right">
                Select Season (if applicable):
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlSeason" runat="server" 
                    onselectedindexchanged="ddlSeason_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>        
        </tr>
    </table>
</div>

