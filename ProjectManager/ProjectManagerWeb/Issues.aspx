<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Issues.aspx.cs" Inherits="ProjectManagerWeb.Issues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:HyperLink ID="lnkAddNewIssue" NavigateUrl="~/AddIssue.aspx" Text="Add New Issue" runat="server" />
<br /><br />
<table id="Table1" class="customtable" runat="server">
    <tr>
        <th>Issue ID</th>
        <th>Project Name</th>
        <th>Issue Subject</th>
        <th>Assignee</th>
        <th>Priority</th>
    </tr>
</table>

</asp:Content>
