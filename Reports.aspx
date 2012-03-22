<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true"
    CodeFile="Reports.aspx.cs" Inherits="Reports" %>

<%@ Register TagPrefix="selectorCtrl" TagName="headerCtrl" Src="~/Controls/SelectorControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align:center;">
        <h1>
            Generate Reports</h1>
        <br />
        <br />
        <selectorCtrl:headerCtrl ID="selControls" runat="server" />
        <br />
        <br />
        <table style="margin-left:auto;margin-right:auto;">
            <tr>
                <td align="left">
                    <asp:RadioButtonList ID="rblSelectReport" runat="server" Width="361px">
                        <asp:ListItem Value="1">Group Summary</asp:ListItem>
                        <asp:ListItem Value="2">Group Detail</asp:ListItem>
                        <asp:ListItem Value="3">Group Comment Details</asp:ListItem>
                        <asp:ListItem Value="4">Group Season Comparison</asp:ListItem>
                        <asp:ListItem Value="5">Anonymous Users</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <div align="center">
            <asp:Button ID="btnGenerateReport" runat="server" Text="Run Report" OnClick="btnGenerateReport_Click" />
        </div>
    </div>
</asp:Content>
