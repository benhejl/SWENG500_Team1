<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueDetails.aspx.cs" Inherits="ProjectManagerWeb.IssueDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table id="Table1" runat="server">
    <tr>
        <th>Issue Information</th>
        <th>Value</th>
    </tr>
    <tr>
        <td>Issue ID:</td>
        <td><asp:Label ID="lblIssueID" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Project Name</td>
        <td><asp:Label ID="lblProjectName" runat="server" Text="Label"></asp:Label></td>
        
    </tr>
    <tr>
        <td>Subject:</td>
        <td><asp:Label ID="lblSubject" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Issue Priority:</td>
        <td><asp:Label ID="lblIssuePriority" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Issue Status</td>
        <td><asp:Label ID="lblIssueStatus" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Description </td>
        <td><asp:Label ID="lblDescription" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Category</td>
        <td> <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Milestone</td>
        <td><asp:Label ID="lblMilestone" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Assignee</td>
        <td><asp:Label ID="lblAssignee" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Entry Date</td>
        <td><asp:Label ID="lblEntryDate" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lnkEditDetails" Text="Edit Details" runat="server" />
        </td>
    </tr>
</table>


</asp:Content>
