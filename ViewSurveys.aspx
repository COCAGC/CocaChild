<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="ViewSurveys.aspx.cs" Inherits="ViewSurveys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div align="center">
View Surveys
</div>
    <div>
            <asp:GridView ID="gvSurveyList" runat="server" EnableModelValidation="True" 
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="SurveyDate" HeaderText="SurveyDate" />
                <asp:BoundField DataField="StudentGroupName" HeaderText="StudentGroupName" />
                <asp:BoundField DataField="SchoolYear" HeaderText="SchoolYear" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

