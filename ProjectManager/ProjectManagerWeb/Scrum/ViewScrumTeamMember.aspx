<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewScrumTeamMember.aspx.cs" Inherits="ProjectManagerWeb.Scrum.ViewScrumTeamMember" %>
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
    <table>
        <tr>
            <td>Please select which users scrum data you would like to view:</td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlUserList" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlUserList_SelectedIndexChanged" Width="289px" ><asp:ListItem Text="" Value="" ></asp:ListItem></asp:DropDownList></td>
        </tr>
    </table>
    <br />
    <div id="divData" runat="server" visible="false">
        <asp:Panel ID="pnlMain" ScrollBars="Vertical" runat="server">
        <table class="tablecss">
            <tr>
                <td class="tdcss">Date</td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[0]).Question%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[1]).Question%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[2]).Question%></td>
            </tr>
            <% 
                string previousDate = DateTime.Now.ToShortDateString();
            %>
            <%
                for(int x = 0; x < ScrumList.Count; x=x+3)
                {
                    ProjectManagerLibrary.Models.ScrumData scrumData = (ProjectManagerLibrary.Models.ScrumData)ScrumList[x];
                  
            %>
            <tr>
                <td class="tdcss">
                    <%=scrumData.DateEntered.ToShortDateString()%>
                </td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[x]).Answer%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[x + 1]).Answer%></td>
                <td class="style1"><%=((ProjectManagerLibrary.Models.ScrumData)ScrumList[x + 2]).Answer%></td>

            <%
                } 
            %>
            </tr>
        </table>
        </asp:Panel>
    </div>
    <div id="divNoData" runat="server" visible="false" style="color:Red">
        &nbsp; No Scrum Data available for the selected user.
    </div>
</asp:Content>
