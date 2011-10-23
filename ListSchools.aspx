<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master"  CodeFile="ListSchools.aspx.cs" Inherits="ListSchools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">        
    <title>List Schools</title>
    <link type="text/css" href="CocaChild.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <div align="center">    
             <h1>School Listing</h1>               
    </div>
    <br />
    <br />
    <div align="center">    
            <asp:GridView ID="gvSchoolList" runat="server" EnableModelValidation="True" 
            AutoGenerateColumns="False" >
            <Columns>            
                <asp:BoundField DataField="Name" HeaderText="School Name" />
                <asp:BoundField DataField="Address1" HeaderText="Address1" />
                <asp:BoundField DataField="Address2" HeaderText="Address2" />
                <asp:BoundField DataField="Address3" HeaderText="Address3" />
                <asp:BoundField DataField="City" HeaderText="City" />                
                <asp:BoundField DataField="StateName" HeaderText="StateName" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
 