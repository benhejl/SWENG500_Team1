<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ProjectManagerWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="ProjectNameLabel" runat="server" Text="Project Name: "></asp:Label>
&nbsp;<asp:DropDownList ID="ProjectNames" runat="server" 
            onload="ProjectNames_SelectedIndexChanged" 
            onselectedindexchanged="ProjectNames_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="ErrorLabel" runat="server" 
            Text="No projects exist.  Create a new project before generating reports."></asp:Label>
    </p>
    <p>
        <asp:Table ID="IssuesTable" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Issue Type</asp:TableCell>
                <asp:TableCell runat="server">Count</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Open Issues</asp:TableCell>
                <asp:TableCell ID="OpenIssues" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Resolved Issues</asp:TableCell>
                <asp:TableCell ID="ResolvedIssues" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
