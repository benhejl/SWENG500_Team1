<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scrum.aspx.cs" Inherits="ProjectManagerWeb.Scrum.Scrum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>Please select an option: </td>
            <td>
                <asp:DropDownList ID="ddlSelection" runat="server">
                    <asp:ListItem Text=""></asp:ListItem>
                    <asp:ListItem Text="Enter New Scrum Data" Value="EnterScrumData.aspx"></asp:ListItem>
                    <asp:ListItem Text="View My Scrum Data" Value="ViewScrumData.aspx"></asp:ListItem>
                    <asp:ListItem Text="Search Scrum By Date" Value="SearchScrumByDate.aspx"></asp:ListItem>
                    <asp:ListItem Text="View Team Members Scrum Data" Value="ViewScrumTeamMember.aspx"></asp:ListItem>                    
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
