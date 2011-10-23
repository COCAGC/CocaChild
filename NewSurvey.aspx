<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master" CodeFile="NewSurvey.aspx.cs" Inherits="NewSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function() {
		    $(".date").datepicker();
	    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="clear">
    <div align="center">
        <h1>Create Survey</h1>  
    </div>
        <br />
        <br />
        <br />
    <asp:Label ID="lblSeasonSelector" AssociatedControlId="SeasonSelector" runat="server" Text="Label" CssClass="labelfloat">Season Selector</asp:Label>
    <asp:DropDownList ID="SeasonSelector" runat="server" />
    <br />
    <asp:Label ID="lblGradeSelector" AssociatedControlId="GradeSelector" runat="server" Text="Label" CssClass="labelfloat">Grade</asp:Label>
    <asp:DropDownList ID="GradeSelector" runat="server" />
    <br />
    <asp:Label ID="lblSchoolYearSelector" AssociatedControlId="SchoolYearSelector" runat="server" Text="Label" CssClass="labelfloat">School Year</asp:Label>
    <asp:DropDownList ID="SchoolYearSelector" runat="server" />
    <br />
    <asp:Label ID="lblSchoolSelector" AssociatedControlId="SchoolSelector" runat="server" Text="Label" CssClass="labelfloat">School</asp:Label>
    <asp:DropDownList ID="SchoolSelector" runat="server" />
    <br />
    <asp:Label ID="lblSurveyDate" AssociatedControlId="SurveyDate" runat="server" Text="Label" CssClass="labelfloat">Survey Date</asp:Label>
    <asp:TextBox ID="SurveyDate" CssClass="date" runat="server" />
    <br />
    <asp:Label ID="lblGroupName" AssociatedControlId="GroupName" runat="server" Text="Label" CssClass="labelfloat">Group Name</asp:Label>
    <asp:TextBox ID="GroupName" ToolTip="GroupName" runat="server" />
    <br />
    <asp:Label ID="lblFile" AssociatedControlId="File" runat="server" Text="Label" CssClass="labelfloat">Browse for student file</asp:Label>
     <asp:FileUpload ID="File" runat="server" ToolTip="Upload files" />
    &nbsp;<asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
        Text="Upload" />
    <br />
    <asp:Label Visible="false" ID="ErrorText" runat="server"/>
    <asp:Label CssClass="display_message" Visible="false" ID="MsgText" runat="server"/>
</div>
</asp:Content>