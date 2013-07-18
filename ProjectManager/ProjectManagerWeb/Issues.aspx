<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Issues.aspx.cs" Inherits="ProjectManagerWeb.Issues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

<asp:HyperLink ID="lnkAddNewIssue" NavigateUrl="~/AddIssue.aspx" Text="Add New Issue" runat="server" />
<br /><br />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

Filter: <asp:DropDownList ID="ddlFilterBy" runat="server" 
        AutoPostBack="True" onselectedindexchanged="ddlFilterBy_SelectedIndexChanged">
<asp:ListItem Text="Select Filter" Value="" />
<asp:ListItem Text="Filter by Status" Value="status" />
<asp:ListItem Text="Filter by Owner" Value="owner" />
</asp:DropDownList>&nbsp;&nbsp;
<asp:DropDownList ID="ddlFiltered" runat="server" AutoPostBack="True" onselectedindexchanged="ddlFiltered_SelectedIndexChanged">
<asp:ListItem Text="---------------" Value="" />
</asp:DropDownList>
<br /><br />


<table id="Table1" class="customtable" runat="server">
    <tr>
        <th>Issue ID</th>
        <th>Project Name</th>
        <th>Issue Subject</th>
        <th>Assignee</th>
        <th>Priority</th>
        <th>Status</th>
    </tr>
</table>

</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlFilterBy" />
        <asp:AsyncPostBackTrigger ControlID="ddlFiltered" />
    </Triggers> 
</asp:UpdatePanel>

</asp:Content>
