<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="ProjectManagerWeb.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
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
           

            Calendar Name: <asp:TextBox ID="calendarName" runat="server" ></asp:TextBox>

            
            <br />
                        Registered Users:<asp:ListBox ID="RegisteredUsers" runat="server"></asp:ListBox>
                        <br />
                        Project:<asp:DropDownList ID="ProjectsDropDown" runat="server">
                        </asp:DropDownList>
                        <br />
            <asp:Button ID="SaveCalendar" runat="server" Text="Save" onclick="SaveNewCalendar"/>
                        &nbsp;&nbsp;
                        <asp:Button ID="CancelNewCalendar" runat="server" ForeColor="Red" 
                            onclick="CancelCalendar" Text="Cancel" />
        </asp:Panel>

          <asp:Panel ID="EditPanel" runat="server" Height="442px" Width="555px">
                        <br />
            <br />
           
                        Choose a calendar:
           
                        <asp:DropDownList ID="CalendarDropDown" runat="server">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="New Calendar Name:"></asp:Label>

                         <asp:TextBox ID="EditNameTextBox" runat="server"></asp:TextBox>
           
                        <br />
                        <asp:Button ID="SaveEdit" runat="server" onclick="SaveEdit_Click" Text="Save"/>
                        <asp:Button ID="CancelEdit" runat="server" ForeColor="Red" Text="Cancel"/>

                        <br />
                        <br />

                        
           
        </asp:Panel>

        <asp:Panel ID="DeleteCalendarPanel" runat="server" Height="442px" Width="555px">
            <br />
            <br />
            Choose a calendar:
           
                        <asp:DropDownList ID="DeleteDropDown" runat="server">
                        </asp:DropDownList>
                        <br />
                    
                        <asp:Button ID="Button1" runat="server" onclick="DeleteButton_Click" Text="Delete"/>
                        <asp:Button ID="Button2" runat="server" ForeColor="Red" Text="Cancel"/>

                        <br />
                        <br />
        </asp:Panel>
    </div>
    </div>
</asp:Content>

