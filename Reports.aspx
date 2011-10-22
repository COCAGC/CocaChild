<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" %>
<%@ Register TagPrefix="selectorCtrl" TagName="headerCtrl" Src="~/Controls/SelectorControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">
        <selectorCtrl:headerCtrl ID="selControls" runat="server" />
        <br />
        <br />
        <asp:RadioButtonList ID="rblSelectReport" runat="server" Width="361px">
            <asp:ListItem Value="1">Group Summary</asp:ListItem>
            <asp:ListItem Value="2">Group Detail</asp:ListItem>
            <asp:ListItem Value="3">Group Comment Details</asp:ListItem>
            <asp:ListItem Value="4">Group Season Comparison</asp:ListItem>
            <asp:ListItem Value="5">Opt Out Comments Detail</asp:ListItem>
        </asp:RadioButtonList>
    
        <br />
        <div align="right">
            <asp:Button ID="btnGenerateReport" runat="server" Text="Run Report" />
        </div>
    </div>

</asp:Content>

