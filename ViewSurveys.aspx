<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="ViewSurveys.aspx.cs" Inherits="ViewSurveys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div align="center">    
        <asp:Label ID="lblExistingSurvey" runat="server" 
            Text="New Survey Copy" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
        <br />
        <br />
        <br />
    </div>
    <div align="center">    
            <asp:GridView ID="gvSurveyList" runat="server" EnableModelValidation="True" 
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="SurveyDate" HeaderText="SurveyDate" />
                <asp:BoundField DataField="StudentGroupName" HeaderText="StudentGroupName" />
                <asp:BoundField DataField="SchoolYear" HeaderText="SchoolYear" />
            </Columns>
        </asp:GridView>
        <div align="center">
      <table>
          <tr>
              <td>
                <asp:Button ID="btnExport" runat="server" Text="Export" />  
              </td>
              <td>
               <asp:Button ID="btnEdit" runat="server" Text="Create Copy" />
              </td>
          </tr>
      </table>
  </div>
        <br />
        <br />

    </div>
</asp:Content>

