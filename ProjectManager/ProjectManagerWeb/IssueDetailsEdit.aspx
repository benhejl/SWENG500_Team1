<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueDetailsEdit.aspx.cs" Inherits="ProjectManagerWeb.IssueDetailsEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table id="Table1" runat="server" align="left" class="customtable">
    <tr>
        <th>&nbsp;</th>
        <th><center>Edit Issue Details</center></th>
    </tr>
    <tr>
        <td>Project Name</td>
        <td><asp:DropDownList ID="ddlProjects" runat="server" /></td>
    </tr>
    <tr>
        <td>Subject:</td>
        <td><asp:TextBox ID="txtSubject" Width="500" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSubject" runat="server" ErrorMessage="Subject is required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Issue Priority:</td>
        <td><asp:DropDownList ID="ddlIssuePriority" runat="server" >
            <asp:ListItem Text="High" Value="High" Selected="True" />
            <asp:ListItem Text="Medium" Value="Medium" />
            <asp:ListItem Text="Low" Value="Low" />
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td>Issue Status</td>
        <td><asp:DropDownList ID="ddlIssueStatus" runat="server" >
            <asp:ListItem Text="Unresolved" Value="Unresolved" Selected="True" />
            <asp:ListItem Text="Resolved" Value="Resolved" />
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td>Description</td>
        <td><asp:TextBox ID="txtDescription" Width="500" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Description is required." ForeColor="Red"></asp:RequiredFieldValidator>        
        </td>
    </tr>
    <tr>
        <td>Category</td>
        <td><asp:TextBox ID="txtCategory" Width="500" runat="server" /></td>
    </tr>
    <tr>
        <td>Milestone</td>
        <td><asp:TextBox ID="txtMilestone" Width="500" runat="server" /></td>
    </tr>
    <tr>
        <td>Assignee</td>
        <td><asp:DropDownList ID="ddlAssignee" runat="server" />
            <asp:CompareValidator ID="CompareValidator2" Type="String" Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlAssignee" runat="server" ErrorMessage="Assignee is required." ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>Entry Date</td>
        <td><asp:TextBox ID="txtEntryDate" runat="server"></asp:TextBox> 

            <asp:CompareValidator ID="CompareValidator1" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtEntryDate" runat="server" ErrorMessage="Incorrect Date format" ForeColor="Red"></asp:CompareValidator>
         </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" 
                onclick="btnSubmit_Click" />
        </td>
    </tr>
</table>

</asp:Content>
