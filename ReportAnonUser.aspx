<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true"
    CodeFile="ReportAnonUser.aspx.cs" Inherits="ReportAnonUser" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <h1>Anonymous Users</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="AnonymousLoginsReportViewer" Width="100%" runat="server" Font-Names="Verdana"
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="14pt" ZoomMode="PageWidth">
            <LocalReport ReportPath="Reports\AnonUserDetail.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SurveySummaryDatasource" Name="SurveySummaryDataset" />
                    <rsweb:ReportDataSource DataSourceId="AnonymousIdsDatasource" Name="AnonymousUsersDataset" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="AnonymousIdsDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="coca_rpt_AnonymousIds" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="SurveyId" QueryStringField="SurveyId" Type="Int64"
                    DefaultValue="0" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SurveySummaryDatasource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="coca_rpt_SurveySummary" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="-1" Name="SurveyId" 
                    QueryStringField="SurveyId" Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
