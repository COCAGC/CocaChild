<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true"
    CodeFile="ReportsPrepSeason2.aspx.cs" Inherits="ReportsPrepSeason2" %>

<%@ Register TagPrefix="selectorCtrl" TagName="headerCtrl" Src="~/Controls/SelectorControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align: center;">
        <h1>
            Enter Comparison Season</h1>
        <br />
        <br />
        <selectorCtrl:headerCtrl ID="selControls" runat="server" LockSchool="true" OnSurveyIDChanged="selControl_SurveyIdChanged" />
        <br />
        The following is a list of children that do not appear in both reports (if any).<br />
        If appropriate, please match each child on the left with the corresponding child
        on the right.<br />
        <br />
        <table style="margin-left: auto; margin-right: auto; border-collapse: collapse;">
            <thead>
                <tr>
                    <th style="width: 250px; border: 1px solid black;">
                        Survey 1
                    </th>
                    <th style="width: 250px; border: 1px solid black;">
                        Survey 2
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="UnmatchStudentsRepeater" OnItemDataBound="UnmatchedRepeater_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td style="border: 1px solid black;">
                                <asp:HiddenField ID="StudentIdField" runat="server" Value='<%# Eval("Id") %>' />
                                <asp:Label ID="StudentNameLabel" runat="server" Text='<%# Eval("Name") %>' />
                            </td>
                            <td style="border: 1px solid black;">
                                <asp:DropDownList ID="SurveyUnmatchedList" runat="server" AppendDataBoundItems="true"
                                    AutoPostBack="true" OnSelectedIndexChanged="ModifyMatchList">
                                    <asp:ListItem Text="[No Match]" Value="0" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <br />
        <br />
        <div align="center">
            <asp:Button ID="btnGenerateReport" runat="server" Text="Run Report" OnClick="btnGenerateReport_Click" />
        </div>
    </div>
</asp:Content>
