<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="SchoolSetup.aspx.cs" Inherits="SchoolSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div align="center">        
            <table>
                <tr>
                    <td align="left">
                        <ul class="navigation">
                            <li><b><span style="color: #0000ff;">School Setup</span></b></li>
                            <li>-&nbsp;&nbsp;<a href="CreateSchool.aspx">Create School</a></li>
                            <li>-&nbsp;&nbsp;<a href="ListSchools.aspx">View Schools</a></li>                    
                        </ul>  
                    </td>
                </tr>
            </table>          
    </div>

</asp:Content>
