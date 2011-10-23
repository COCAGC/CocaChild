<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="ReportAnonUser.aspx.cs" Inherits="ReportAnonUser" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div align="center">  
<h1>Classroom Deatil</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" 
        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Reports\AnonUserDetail.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="AnonUserds" />
            </DataSources>
        </LocalReport>
       
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:sql2008r2_847344_surveysConnectionString %>" 
        SelectCommand="coca_rpt_AnonymousIds" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="StudentGroupSeasonId" 
                QueryStringField="StudentGroupSeasonId" Type="Int64" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>  
</asp:Content>

