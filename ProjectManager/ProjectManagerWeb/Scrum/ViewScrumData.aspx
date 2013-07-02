<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewScrumData.aspx.cs" Inherits="ProjectManagerWeb.Scrum.ViewScrumData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css" media="screen">

    .tablecss{
    border-collapse:collapse;
    border:1px solid #ccc;
    }

    .tdcss{
    border:1px solid #ccc;
    padding:5px;
    }
        .style1
        {
            border: 1px solid #ccc;
            padding: 5px;
            width: 780px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="pnlMain" ScrollBars="Vertical" runat="server">
        <table class="tablecss">
            <tr>
                <td class="tdcss">Date</td>
                <%--<td class="tdcss">User</td>--%>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[0]).Question%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[1]).Question%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[2]).Question%></td>
            </tr>
            <% 
                string previousDate = DateTime.Now.ToShortDateString();
                int previousUserId = 0;
            %>
            <%
                for(int x = 0; x < ScrumList.Count; x=x+3)
                {
                    ProjectManagerLibrary.Models.ScrumData scrumData = (ProjectManagerLibrary.Models.ScrumData)ScrumList[x];
                  
            %>
            <tr>
            <%--<% if (!previousDate.Equals(scrumData.DateEntered.ToShortDateString()))
                   {%>--%>
                <td class="tdcss">
                    <a href="<%= this.ResolveUrl("~/Scrum/EditScrumData.aspx?Sequence=" + scrumData.AnswerKey) %>"><%=scrumData.DateEntered.ToShortDateString()%></a>
                </td>
               <%-- <% }
                   else
                   {%>
                <td class="tdcss">
                </td>
                <%} %>
                <% if (!previousUserId.Equals(scrumData.UserId))
                   {%>
                <td class="tdcss">
                    <%=scrumData.FirstName%> <%=scrumData.LastName%> 
                </td>
                <% }
                   else
                   {%>
                <td class="tdcss">
                </td>
                <%} %>--%>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[x]).Answer%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[x + 1]).Answer%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[x + 2]).Answer%></td>

            <%
                   //previousDate = scrumData.DateEntered.ToShortDateString();
                   //previousUserId = scrumData.UserId;
                } 
            %>
            </tr>
        </table>
        </asp:Panel>
    </div>
</asp:Content>
