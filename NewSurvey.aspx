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
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque vel pharetra justo. Aenean quis dolor tellus, pretium laoreet est. Mauris lectus justo, ornare vel malesuada at, tempus sed ipsum. Morbi egestas euismod pellentesque. Ut eget ultricies justo. Phasellus eu ligula lacus. Suspendisse porta ultricies varius. Suspendisse potenti. Pellentesque elit tellus, blandit nec consequat non, volutpat in felis. Suspendisse volutpat vestibulum ullamcorper. Ut libero turpis, cursus ac pretium sit amet, placerat non metus. Maecenas viverra dolor vel purus cursus in congue elit mollis. In vestibulum semper velit, nec pulvinar dolor rutrum quis. Curabitur tincidunt pulvinar elit eget viverra.

Sed volutpat dictum eros, eu posuere quam ornare ac. Donec sagittis quam sed justo pellentesque consectetur. Nunc vitae hendrerit magna. Vivamus laoreet, mi et interdum hendrerit, metus nisl varius velit, sed laoreet lectus mauris sed turpis. Morbi tellus magna, semper quis tincidunt eu, vehicula et odio. Pellentesque nunc quam, ullamcorper quis pretium a, malesuada at risus. Duis et diam at est placerat tincidunt. Quisque nec nisl a velit convallis fermentum in sed eros. Sed mi lacus, vestibulum sed posuere interdum, feugiat at nunc. Aliquam quam quam, tristique ut tincidunt eget, condimentum ut massa. Nunc ut nulla sed leo sodales sollicitudin. Mauris sit amet dapibus orci. Integer malesuada nibh in sem accumsan mollis.
    <asp:DropDownList ID="SeasonSelector" runat="server" />
    <asp:DropDownList ID="GradeSelector" runat="server" />
    <asp:DropDownList ID="SchoolYearSelector" runat="server" />
    <asp:DropDownList ID="SchoolSelector" runat="server" />
    
    <asp:TextBox ID="GroupName" ToolTip="GroupName" runat="server" />
    <asp:FileUpload ID="File" runat="server" ToolTip="Upload files" />
    <asp:Button ID="Upload" runat="server" OnClick="OnUploadClick" Text="Upload" />
    <asp:Label Visible="false" ID="ErrorText" runat="server"/>
</div>
</asp:Content>