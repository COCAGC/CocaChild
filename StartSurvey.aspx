<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/StudentSite.master" CodeFile="StartSurvey.aspx.cs" Inherits="StartSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

        <asp:Label ID="Label1" runat="server" Text="Label"><h1>Start Survey Here</h1></asp:Label>    
    <div>
    <div >
    <span class="student_login">
    <fieldset>
        <asp:Label ID="lblARPID" AssociatedControlId="txtARPID" runat="server" Text="Label" CssClass="labelfloat">ARP ID</asp:Label>
        <asp:TextBox ID="txtARPID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblStudentID" AssociatedControlId="txtStudentID" runat="server" Text="Label" CssClass="labelfloat">Student ID</asp:Label>
        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
        <br />
        <br />
        <span style="padding-left: 30%"><asp:Button ID="btnStartSurvey" runat="server" 
            Text="Start Survey" onclick="btnStartSurvey_Click" /></span>

    </fieldset>
    </span>
    </div>
    </div>    
</asp:Content>