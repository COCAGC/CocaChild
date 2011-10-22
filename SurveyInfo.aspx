<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/StudentSite.master"
    CodeFile="SurveyInfo.aspx.cs" Inherits="SurveyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
    <style type="text/css">
    .yui {width:100%;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table id="tableOne" class="yui">
        <asp:ListView ID="lvStudentBullyList" runat="server" Visible="true">
            <LayoutTemplate>
                <tr class="header">
                    <th style="text-align: left">
                        <asp:Label runat="server" ID="FirstName">First Name</asp:Label>
                    </th>
                    <th style="text-align: left">
                        <asp:Label runat="server" ID="LastName">Last Name</asp:Label>
                    </th>
                    <th style="text-align: left">
                        <asp:Label runat="server" ID="BullyOthersCount">Number of times you have seen this student bully another student</asp:Label>
                    </th>
                    <th style="text-align: left">
                        <asp:Label runat="server" ID="BulliedByOthersCount">Number of times you have seen this student be a target of bullying</asp:Label>
                    </th>
                    <th style="text-align: left">
                        <asp:Label runat="server" ID="Comments">Comments</asp:Label>
                    </th>
                    <th style="text-align: left">
                    </th>
                </tr>
                <tr runat="server" id="itemPlaceholder" />
            </LayoutTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="lblEditFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblEditLastName" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBullyOthersCountID" runat="server" DataTextField="BullyOthersCount"
                            DataValueField="BullyOthersCount">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBulliedByOthersCount" runat="server" DataTextField="BulliedByOthersCount"
                            DataValueField="BulliedByOthersCount">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtComments" runat="server" Text='<%# Eval("Comments") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
    <asp:Button Text="Finished" runat="server" ID="FinishedId" OnClick="FinishedId_Click" />
</asp:Content>
