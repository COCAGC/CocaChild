<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartSurvey.aspx.cs" Inherits="StartSurvey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Start Survey</title>
<style>
fieldset {
  padding: 1em;  
}
label 
{
  clear:left;
  float:left;
  width:15%;
  margin-right:0.5em;
  padding-top:0.2em;
  text-align:right;
  font-weight:bold;
  }
    </style>
</head>
<body>
        <asp:Label ID="Label1" runat="server" Text="Label"><h1>Start Survey Here</h1></asp:Label>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
