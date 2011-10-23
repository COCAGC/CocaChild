<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="CopyExistingSurvey.aspx.cs" Inherits="CopyExistingSurvey" %>
<%@ Register TagPrefix="selectorCtrl" TagName="headerCtrl" Src="~/Controls/SelectorControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">    
        <asp:Label ID="lblCopy" runat="server" 
            Text="Copy Existing Survey (A)" Font-Bold="True" Font-Names="Tahoma" 
            Font-Size="20pt" ForeColor="Blue"></asp:Label>    
        <br />
        <br />
        <br />
    </div>
  <selectorCtrl:headerCtrl ID="selControls" runat="server" />
  <br />    
  <br />
  <div align="center">
      <table>
          <tr>
              <td>
                <asp:Button ID="btnExport" runat="server" Text="Export" />  
              </td>
              <td>
               <asp:Button ID="btnCopy" runat="server" Text="Copy" />
              </td>
          </tr>
      </table>
  </div>
</asp:Content>

