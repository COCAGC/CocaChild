<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="CopyExistingSurvey.aspx.cs" Inherits="CopyExistingSurvey" %>
<%@ Register TagPrefix="selectorCtrl" TagName="headerCtrl" Src="~/Controls/SelectorControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">  
        <h1>Copy Existing Survey</h1>          
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
                <asp:Button ID="btnExport" runat="server" OnClick="OnbtnExportClick" Text="Export" />  
              </td>
              <td>
               <asp:Button ID="btnCopy" runat="server" OnClick="OnbtnCopyClick" Text="Copy" />
              </td>
          </tr>
      </table>
      <asp:Label Visible="false" runat="server" ID="ErrorText" />
  </div>
</asp:Content>

