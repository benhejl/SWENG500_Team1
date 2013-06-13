<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="ProjectManagerWeb.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
    <div _designerregion="0" style="height: 444px">
    <div _designerregion="0" style="height: 444px">
        <asp:Panel ID="InitPanel" runat="server" Height="442px" Width="555px">
            List of Current Calendars here...<br />
            <br />
            <br />
            <asp:Button ID="CreateButton" runat="server" Text="Create New Calendar      " 
                onclick="CreateNewCalendarClick" />
            <br />
            <br />
            <asp:Button ID="DeleteButton" runat="server" onclick="DeleteCalendarClick" 
                Text="Delete Calendar             " />
            <br />
            <br />
            <asp:Button ID="EditButton" runat="server" 
                onclick="EditCalendarInformationClick" Text="Edit Calendar Information" />
        </asp:Panel>
         <asp:Panel ID="CreatePanel" runat="server" Height="442px" Width="555px">
                        <br />
            <br />
            <asp:Label ID="CalendarName" runat="server" Text="Calendar Name" Font-Bold="true"/>
            <asp:TextBox ID="NameTextBox" runat="server" Text="Enter the calendar name" />
            <br />
            <br />
            <asp:Label ID="CalendarUsers" runat="server" Text="Calendar Users" Font-Bold="true"/>
            <asp:CheckBoxList ID="UsersList" runat="server" />
            <br />
            <br />
            <asp:Label ID="CalendarProject" runat="server" Text="Calendar Project" Font-Bold="true"/>
            <asp:CheckBoxList ID="ProjectList" runat="server" />
            <br />
            <br />
            <asp:Button ID="SaveCalendar" runat="server" Text="Save" onclick="SaveNewCalendar"/>
                        &nbsp;&nbsp;
            <asp:Button ID="CancelNewCalendar" runat="server" Text="Cancel" onclick="CancelCalendar" ForeColor="Red"/>
        </asp:Panel>
    </div>
    </div>
</asp:Content>

