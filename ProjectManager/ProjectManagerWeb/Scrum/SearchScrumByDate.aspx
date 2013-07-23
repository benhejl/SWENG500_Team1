<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchScrumByDate.aspx.cs" Inherits="ProjectManagerWeb.Scrum.SearchScrumByDate" %>
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
        .style2
        {
            border: 1px solid #ccc;
            padding: 5px;
            width: 451px;
        }
        .style3
        {
            border: 1px solid #ccc;
            padding: 5px;
            width: 367px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>Please enter the date to view all scrum data for the specified date: </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlMonth" runat="server" 
                    onselectedindexchanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDay" runat="server"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList></td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click"/>
            </td>
        </tr>
    </table>
    <br />
    <div id="divData" runat="server" visible="false">
        <asp:Panel ID="pnlMain" ScrollBars="Vertical" runat="server">
        <table class="tablecss">
            <tr>
                <td class="style3">Name</td>
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
                <td class="style3">
                    <%=scrumData.FirstName%> <%=scrumData.LastName%>
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
