<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/COCAsite.master"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
    
    <div align="center">    
             <h1>Anonymous Peer Rating Survey</h1>               
    </div>
    <br />
    <br />
    <div align="center">
    <table>
        <tr>
            <td align="left">
                <ul class="navigation">
                    <li><b><span style="color: #0000ff;">School Setup</span></b></li>
                    <li>-&nbsp;&nbsp;<a href="CreateSchool.aspx">Create School</a></li>
                    <li>-&nbsp;&nbsp;<a href="ListSchools.aspx">View Schools</a></li>
                    <li><b><span style="color: #0000ff;">Survey Setup</span></b></li>
                    <li>-&nbsp;&nbsp;<a href="NewSurvey.aspx">Create Survey</a></li>                    
                    <li>-&nbsp;&nbsp;<a href="CopyExistingSurvey.aspx">Copy Exising Survey</a></li>
                    <li>-&nbsp;&nbsp;<a href="EditSurveys.aspx">Edit Surveys</a></li>                                                                              
                    <li><b><span style="color: #0000ff;"><a href="Reports.aspx">Reports</a></span></b></li>
                    <li><b><span style="color: #0000ff;"><a href="StartSurvey.aspx">Student Survey</a></span></b></li>                    
                </ul>  
            </td>
        </tr>
    </table>  
    </div>
</asp:Content>