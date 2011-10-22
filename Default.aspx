<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/COCAsite.master"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <title>COCA</title>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
    
    <div align="center">    
        <asp:Label ID="lblAnonSurvey" runat="server" 
            Text="Anonymous Peer Rating Survey" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
    </div>
    <div align="center">
    <ul class="navigation">
        <li><a href="CreateSchool.aspx">Create School</a></li>
        <li><a href="ListSchools.aspx">View Schools</a></li>
        <li><a href="NewSurvey.aspx">Begin New Survey</a></li>
        <li><a href="#">Edit Existing Survey</a></li>
        <li><a href="#">Run Reports</a></li>
        <li><a href="#">Begin Student Survey</a></li>
        <li><a href="#">Begin Student Survey - Admin</a></li>
    </ul>    
        </div>
</asp:Content>