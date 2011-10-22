<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master"  CodeFile="ListSchools.aspx.cs" Inherits="ListSchools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
    <title>List Schools</title>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    
            <asp:GridView ID="gvSchoolList" runat="server" EnableModelValidation="True" 
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="Name" HeaderText="School Name" 
                    SortExpression="Name" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="StateName" HeaderText="StateName" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
 