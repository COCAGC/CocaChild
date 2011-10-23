<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="SurveySetup.aspx.cs" Inherits="SurveySetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div align="center">
    <table>
        <tr>
            <td align="left">
                <ul class="navigation">
                    <li><b><span style="color: #0000ff;">Survey Setup</span></b></li>
                    <li>-&nbsp;&nbsp;<a href="NewSurvey.aspx">Create Survey</a></li>                      
                    <li>-&nbsp;&nbsp;<a href="CopyExistingSurvey.aspx">Copy Exising Survey</a></li>                                                                                                                
                </ul>  
            </td>
        </tr>
    </table>    
    </div>
</asp:Content>