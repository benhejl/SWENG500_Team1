<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ProjectManagerWeb.WebForm1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
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
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Report</asp:TableCell>
                <asp:TableCell runat="server">Open vs. Resolved</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
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
        <asp:Chart ID="ProjectChart" runat="server" Width="600px" />
        <asp:Table ID="Table2" runat="server" Width="600px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Start Date</asp:TableCell>
                <asp:TableCell runat="server">End Date</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</p>
    <p>
        &nbsp;</p>
</asp:Content>
