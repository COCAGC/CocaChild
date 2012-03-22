<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="ReportCompareSeasons.aspx.cs" Inherits="ReportCompareSeasons" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Comparison Report</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="CompareSeasonReportViewer" Width="100%" runat="server" Font-Names="Verdana"
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="14pt" ZoomMode="PageWidth">
            <LocalReport ReportPath="Reports\ComparisonReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="Survey1SummaryDatasource" Name="Survey1SummaryDataset" />
                    <rsweb:ReportDataSource DataSourceId="Survey2SummaryDatasource" Name="Survey2SummaryDataset" />
                    <rsweb:ReportDataSource DataSourceId="ComparisonDatasource"     Name="ComparisonDataset" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="Survey1SummaryDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="coca_rpt_SurveySummary" 
            SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="SurveyId" QueryStringField="SurveyId" 
                    Type="Int64" DefaultValue="-1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Survey2SummaryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="coca_rpt_SurveySummary" 
            SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="SurveyId" QueryStringField="CompareToSurveyId" 
                    Type="Int64" DefaultValue="-1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="ComparisonDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="coca_rpt_StudentCompareSeasons" 
            SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="Season1SurveyId" QueryStringField="SurveyId" Type="Int64" DefaultValue="-1" />
                <asp:QueryStringParameter Name="Season2SurveyId" QueryStringField="CompareToSurveyId" Type="Int64" DefaultValue="-1" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

