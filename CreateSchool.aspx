<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master" CodeFile="CreateSchool.aspx.cs" Inherits="CreateSchool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            width: 208px;
        }
        .style3
        {
            height: 23px;
            width: 208px;
        }
    </style>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        
    <div align="center">       
            <h1>Create School</h1>
        <br />
        <br />
        <br />
    </div>
    <div align="center">    
    <table style="width: 60%;">
        <tr>
            <td class="style2" align="right">
                &nbsp;
                School Name</td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtSchool" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Address Line 1</td>
            <td align="left" colspan="2">                
                <asp:TextBox ID="txtAddress1" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Address Line 2</td>
            <td align="left" colspan="2">                
                <asp:TextBox ID="txtAddress2" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">                
                Address Line 3</td>
            <td align="left" colspan="2">                
                <asp:TextBox ID="txtAddress3" runat="server" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">                
                City</td>
            <td class="style1" align="left" colspan="2">                
                <asp:TextBox ID="txtCity" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
                State
                </td>
            <td class="style1" align="left">                
                 <asp:DropDownList ID="ddlStates" runat="server"></asp:DropDownList>
            </td>
            <td align="left">        
            Zip
                <asp:TextBox ID="txtZip" runat="server" MaxLength="10" Width="50px"></asp:TextBox>
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