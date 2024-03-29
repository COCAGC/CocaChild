﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master"
    CodeFile="ReportClassRmDetail.aspx.cs" Inherits="ReportClassRmDetail" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <h1>Classroom Detail</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" Font-Names="Verdana"
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Reports\ClassroomDetail.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SurveySummaryDatasource" Name="SurveySummaryDataset" />
                    <rsweb:ReportDataSource DataSourceId="SurveyStudentSummaryDatasource" Name="SurveyStudentSummaryDataset" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SurveySummaryDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="coca_rpt_SurveySummaryWRollup" 
            SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="SurveyId" QueryStringField="SurveyId" 
                    Type="Int64" DefaultValue="-1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SurveyStudentSummaryDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="coca_rpt_SurveyStudentSummary" 
            SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="SurveyId" QueryStringField="SurveyId" 
                    Type="Int64" DefaultValue="-1" />
                <asp:QueryStringParameter Name="ClassRoom" QueryStringField="Classroom" Type="String"
                    DefaultValue="na" ConvertEmptyStringToNull="True" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
