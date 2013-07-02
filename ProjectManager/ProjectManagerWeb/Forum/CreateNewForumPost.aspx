<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewForumPost.aspx.cs" Inherits="ProjectManagerWeb.Forum.CreateNewForumPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="text-align:left;">
                Subject
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtBoxSubject" runat="server" TextMode="SingleLine" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;">
                Post
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtBoxPost" runat="server" TextMode="MultiLine" Width="800px" Height="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="btnSubmit" Text="Submit" runat="server" Width="79px" 
                    onclick="btnSubmit_Click"/>  &nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" Width="79px" onclick="btnCancel_Click" 
                    />
            </td>
        </tr>
    </table>
</asp:Content>
