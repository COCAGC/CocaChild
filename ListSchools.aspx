<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/COCAsite.master"  CodeFile="ListSchools.aspx.cs" Inherits="ListSchools" %>

    <div>
    
<%--        <asp:GridView ID="gvSchoolList" runat="server" EnableModelValidation="True" 
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="Name" HeaderText="School Name" 
                    SortExpression="Name" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="State" HeaderText="State" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" />
            </Columns>
        </asp:GridView>--%>
            <asp:GridView ID="gvSchoolList" runat="server" EnableModelValidation="True" 
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="SchoolName" HeaderText="School Name" 
                    SortExpression="SchoolName" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="StateName" HeaderText="StateName" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" />
            </Columns>
        </asp:GridView>
    </div>
 
