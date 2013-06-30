<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumPostDetails.aspx.cs" Inherits="ProjectManagerWeb.Forum.ForumPostDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css" media="screen">

        .tablecss{
        border-collapse:collapse;
        border:1px solid #ccc;
        }

        .tdcss{
        border:1px solid #ccc;
        }
        .tdsubjectcss{
        border:1px solid #ccc;
        width:60%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlForum" runat="server" Width="850" Height="450" ScrollBars="Auto">
    <table style="width:100%; " " class="tablecss">
        <%
            if (ForumModel != null)
            {
        %>
        <tr>
            <td class="tdsubjectcss">Subject: <%=ForumModel.Subject%></td>
            <td class="tdcss">User: <%=ForumModel.FirstName%> <%=ForumModel.LastName%></td>
            <td class="tdcss">Date: <%=ForumModel.DateModified %></td>
        </tr>
        <tr>
            <td class="tdcss" colspan="3" style="height:100px; word-wrap: break-word; vertical-align:top; padding:10px;">
                <asp:Panel ID="pnlPost" runat="server"><%=ForumModel.ForumPost%></asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdcss" colspan="3" style="word-wrap: break-word; vertical-align:top; padding:10px;">
               <b>Replies</b>
            </td>
        </tr>
        <%
                foreach (ProjectManagerLibrary.Models.ReplyModel replyModel in ForumModel.ReplyList)
                {
        %>
        <tr>
            <td style="padding-left:20px;" class="tdsubjectcss"><%=replyModel.ReplyPost%></td>
            <td class="tdcss">User: <%=ForumModel.FirstName%> <%=ForumModel.LastName%></td>
            <td class="tdcss">Date: <%=ForumModel.DateModified %></td>
        </tr>
        <%
                }
        %>
        <%
            } 
        %>
    </table>
    <br />
    <br />
    <table style="width:100%;">
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtBoxReply" runat="server" TextMode="MultiLine" Width="800px" Height="75px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="btnReply" Text="Reply" runat="server" onclick="btnReply_Click" Width="79px"/>
            </td>
        </tr>
    </table>

    </asp:Panel>
</asp:Content>
