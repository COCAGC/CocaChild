<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master" CodeFile="Survey.aspx.cs" Inherits="Survey" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />

    <div align="center">    
        <asp:Label ID="lblSurvey" runat="server" 
            Text="Create Survey" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
        <br />
        <br />
        <br />
    </div>
    <div align="center">    
    <table style="width: 60%;">
        <tr>
            <td class="style2" align="right">
                Season</td>
            <td align="left">
                <asp:DropDownList ID="ddlSeason" runat="server" Width="139px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Date of Survey</td>
            <td align="left">                
                <asp:TextBox ID="txtDateofSurvey" runat="server" Width="84px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Grade</td>
            <td align="left">                
                <asp:DropDownList ID="ddlGrade" runat="server" Width="58px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Section</td>
            <td align="left">                
                <asp:TextBox ID="txtSection" runat="server" Width="84px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Classroom</td>
            <td align="left">                
                <asp:TextBox ID="txtClassroom" runat="server" Width="84px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Teacher</td>
            <td align="left">                
                <asp:TextBox ID="txtTeacher" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">                
                Classroom ID</td>
            <td class="style1" align="left">                
                <asp:TextBox ID="txtClassroomID" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
                APR ID</td>
            <td class="style1" align="left">
&nbsp;
                <asp:Label ID="lblAprID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
                &nbsp;</td>
            <td class="style1" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="style1" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
</div>    
</asp:Content>