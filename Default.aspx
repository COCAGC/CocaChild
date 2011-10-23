<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/COCAsite.master"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
    
    <div align="center">    
        <asp:Label ID="lblAnonSurvey" runat="server" 
            Text="Anonymous Peer Rating Survey" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
    </div>
    <div align="center">
    <table>
        <tr>
            <td align="left">
                <ul class="navigation">
                    <li><a href="SchoolSetup.aspx">School Setup</a></li>
                    <li><a href="CreateSchool.aspx">- Create School</a></li>
                    <li><a href="ListSchools.aspx">- View Schools</a></li>
                    <li><a href="SurveySetup.aspx">Survey Setup</a></li>
                    <li><a href="Survey.aspx">- Create Survey</a></li>
                    <li><a href="NewSurvey.aspx">- Survey Upload</a></li>
                    <li><a href="NewSurvey.aspx">- Copy Exising Survey</a></li>
                    <li><a href="#">Edit Existing Survey</a></li>
                    <li><a href="#">Run Reports</a></li>
                    <li><a href="#">Begin Student Survey</a></li>
                    <li><a href="#">Begin Student Survey - Admin</a></li>
                </ul>  
            </td>
        </tr>
    </table>  

<%--
    x CreateSchool.aspx
    x ListSchools.aspx
    x Survey.aspx  (Create)
     CopyExistingSurvey.aspx
     Reports.aspx
     StartSurvey.aspx

    - NewSurvey.aspx
    - SurveyInfo.aspx
    - EditSurveys.aspx

    Landing pages
      - SchoolSetup.aspx
      - SurveySetup.aspx--%>
        </div>
</asp:Content>