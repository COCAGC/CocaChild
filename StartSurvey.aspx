<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/StudentSite.master" CodeFile="StartSurvey.aspx.cs" Inherits="StartSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

        <asp:Label ID="Label1" runat="server" Text="Label"><h1>Start Survey Here</h1></asp:Label>    
    <div>
    <div >
    <fieldset>
        <legend>Survey Login</legend>

        <asp:Label ID="lblARPID" AssociatedControlId="txtARPID" runat="server" Text="Label">ARP ID</asp:Label>
        <asp:TextBox ID="txtARPID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblStudentID" AssociatedControlId="txtStudentID" runat="server" Text="Label">Student ID</asp:Label>
        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnStartSurvey" runat="server" Text="Start Survey" />

    </fieldset>
    </div>
    </div>    
</asp:Content>