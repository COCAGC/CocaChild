<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/StudentSite.master" CodeFile="NewSurvey.aspx.cs" Inherits="NewSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function() {
		    $( ".date" ).datepicker();
	    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="clear">
    <label>Season</label><asp:DropDownList ID="SeasonSelector" runat="server" />
    <label>Grade</label><asp:DropDownList ID="GradeSelector" runat="server" />
    <label>School Year</label><asp:DropDownList ID="SchoolYearSelector" runat="server" />
    <label>School</label><asp:DropDownList ID="SchoolSelector" runat="server" />
    <label>SurveyDate</label><asp:TextBox ID="SurveyDate" CssClass="date" runat="server" />
    <label>Group Name</label><asp:TextBox ID="GroupName" ToolTip="GroupName" runat="server" />
    <label>Browse For Student File</label><asp:FileUpload ID="File" runat="server" ToolTip="Upload files" />
    <asp:Button ID="Upload" runat="server" OnClick="OnUploadClick" Text="Upload" />
    <asp:Label Visible="false" ID="ErrorText" runat="server"/>
</div>
</asp:Content>
