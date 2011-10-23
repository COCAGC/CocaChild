<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/StudentSite.master" CodeFile="StartSurvey.aspx.cs" Inherits="StartSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div align="center">
        <asp:Label ID="Label1" runat="server" Text="Label"><h1>Start Survey Here</h1></asp:Label>    
    <div>
    <div >    
    <fieldset class="student_login">
        <legend>Survey Login</legend>
         <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblARPID" AssociatedControlId="txtARPID" runat="server" Text="Label">ARP ID</asp:Label>                    
                </td>
                <td>
                    <asp:TextBox ID="txtARPID" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revAPR_ID" runat="server" 
                        ErrorMessage="Enter numeric value" ControlToValidate="txtARPID" 
                        ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
         </table>
         <br />
         <table>              
            <tr>
                <td align="right">
                    <asp:Label ID="lblStudentID" AssociatedControlId="txtStudentID" runat="server" Text="Label">Student ID</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStudentID" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="lblPassword" AssociatedControlId="txtPassword" runat="server" Text="Label">Password</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="btnStartSurvey" runat="server" Text="Start Survey" 
            onclick="btnStartSurvey_Click" />

    </fieldset>    
    </div>
    </div>
 </div>    
</asp:Content>