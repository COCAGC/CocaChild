<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>COCA</title>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">    
        <asp:Label ID="lblAnonSurvey" runat="server" 
            Text="Anonymous Peer Rating Survey" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
    </div>
    <div align="center">
    <ul>
    <li><a href="CreateSchool.aspx">Create School</a></li>
    <li><a href="NewSurvey.aspx">Begin New Survey</a></li>
    <li><a href="#">Edit Existing Survey</a></li>
    <li><a href="#">Run Reports</a></li>
    <li><a href="#">Begin Student Survey</a></li>
    <li><a href="#">Begin Student Survey - Admin</a></li>
    </ul>
    
        </div>
    </form>
</body>
</html>
