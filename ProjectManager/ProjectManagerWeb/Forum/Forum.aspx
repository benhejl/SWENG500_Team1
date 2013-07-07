<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="ProjectManagerWeb.Forum.Forum" %>
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
        <table style="width:100%;" class="tablecss">
            <tr>
                <td class="tdsubjectcss">Subject</td>
                <td class="tdcss">User</td>
                <td class="tdcss">Date</td>
            </tr>
            <%
                if(ForumList != null && ForumList.Count > 0)
                {
                    foreach (ProjectManagerLibrary.Models.ForumModel forumModel in ForumList)
                    {  
            %>
            <tr>
                <td class="tdsubjectcss"><a href="<%= this.ResolveUrl("~/Forum/ForumPostDetails.aspx?ForumId=" + forumModel.ForumId) %>"><%=forumModel.Subject %></a></td>
                <td class="tdcss"><%=forumModel.FirstName%> <%=forumModel.LastName%></td>
                <td class="tdcss"><%=forumModel.DateModified%></td>
            </tr>
            <%
                    }
                } 
            %>
            <tr>
                <td colspan="3" style="text-align:center;"><asp:Button ID="btnNewPost" 
                        runat="server" onclick="btnNewPost_Click" Text="New Post"/> </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
