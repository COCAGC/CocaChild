<%@ Page Title="" Language="C#" MasterPageFile="~/COCAsite.master" AutoEventWireup="true" CodeFile="CopyExistingSurvey.aspx.cs" Inherits="CopyExistingSurvey" %>
<%@ Register TagPrefix="selectorCtrl" TagName="headerCtrl" Src="~/Controls/SelectorControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">  
        <h1>Copy Existing Survey</h1>
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
      <asp:GridView ID="StudentGrid" runat="server" AutoGenerateColumns="False"
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" CellSpacing="2" DataKeyNames="Id" EnableModelValidation="True"
        OnRowCancelingEdit="StudentGrid_RowCancelingEdit" 
        OnRowEditing="StudentGrid_RowEditing" 
        OnRowUpdating="StudentGrid_RowUpdating" ShowFooter="True" 
        OnRowDeleting="StudentGrid_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label ID="fname" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="fnameEdit" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>                    
                </EditItemTemplate>
                <ControlStyle Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label Id="lname" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="lnameEdit" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>                    
                </EditItemTemplate>
                <ControlStyle Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Classroom">
                <ItemTemplate>
                    <asp:Label ID="classroom" runat="server" Text='<%# Bind("ClassRoom") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="classroomEdit" runat="server" Text='<%# Bind("ClassRoom") %>'></asp:TextBox>                    
                </EditItemTemplate>
                <ControlStyle Width="150px" />
            </asp:TemplateField>
            
<%--             <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                 <EditItemTemplate> 
                       <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                       <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                   </EditItemTemplate> 
                   <FooterTemplate> 
                       <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" 
                           CommandName="Insert" Text="Insert" onclick="lnkAdd_Click"></asp:LinkButton> 
                   </FooterTemplate> 
                   <ItemTemplate> 
                       <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                   </ItemTemplate> 

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
               </asp:TemplateField> 
               <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" /> --%>
            </Columns>
        </asp:GridView>
  </div>
</asp:Content>

