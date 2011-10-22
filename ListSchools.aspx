<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListSchools.aspx.cs" Inherits="ListSchools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Schools</title>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvSchoolList" runat="server" EnableModelValidation="True">
            <Columns>
                <asp:HyperLinkField Text="SchoolName" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
