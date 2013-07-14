<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="ProjectManagerWeb.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
        <asp:Panel ID="InitPanel" runat="server" Height="442px" Width="555px">
            <br />
            <br />
            <asp:Button ID="CreateButton" runat="server" Text="Create New Calendar" 
                onclick="CreateNewCalendarClick" Width="219px" />
            <br />
            <br />
            <asp:Button ID="DeleteButton" runat="server" onclick="DeleteCalendarClick" 
                Text="Delete Calendar" Width="219px" />
            <br />
            <br />
            <asp:Button ID="EditButton" runat="server" 
                onclick="EditCalendarInformationClick" Text="Edit Calendar Information" />
            <br />
            <br />
            Choose a Calendar to Delete Events:
            <asp:DropDownList ID="DeleteEventDropDown" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteEventPage" runat="server" onclick="DeleteEventPageClick" 
                Text="Delete Event" Width="106px" />
            <br />
            <br />
            Choose a Calendar to View:  <asp:DropDownList ID="ViewDropDown" runat="server">
                                        </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ViewButton" runat="server" 
                onclick="ViewCalendarClick" Text="View Calendar" />
        </asp:Panel>
         <asp:Panel ID="CreatePanel" runat="server" Height="442px" Width="555px">
                        <br />
            <br />
           

            Calendar Name: <asp:TextBox ID="calendarName" runat="server" ></asp:TextBox>

            
                        <br />

            
            <br />
                        Registered Users:<br /> <asp:CheckBoxList ID="RegisteredUsersList" runat="server"></asp:CheckBoxList>
                        &nbsp;<br /> Project:<asp:DropDownList ID="ProjectsDropDown" runat="server">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button ID="SaveCalendar" runat="server" 
                            onclick="SaveNewCalendar" Text="Save" />
                        &nbsp;&nbsp;
                        <asp:Button ID="CancelNewCalendar" runat="server" ForeColor="Red" 
                            onclick="CancelNewCalendar_Click" Text="Cancel" />
        </asp:Panel>

          <asp:Panel ID="EditPanel" runat="server" Height="442px" Width="555px">
                        <br />
            <br />
           
                        Choose a calendar:
           
                        <asp:DropDownList ID="CalendarDropDown" runat="server">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="New Calendar Name:"></asp:Label>

                         <asp:TextBox ID="EditNameTextBox" runat="server"></asp:TextBox>
           
                        <br />
                        <br />
                        New Registered Users:<br />
                        <asp:CheckBoxList ID="NewRegisteredUsersDropDown" runat="server">
                        </asp:CheckBoxList>
                        <br />
                        New Project:<br />
                        <br />
                        <asp:DropDownList ID="NewProjectDropDown" runat="server">
                        </asp:DropDownList>
                        <br />
           
                        <br />
                        <asp:Button ID="SaveEdit" runat="server" onclick="SaveEdit_Click" Text="Save"/>
                        <asp:Button ID="CancelEdit" runat="server" onclick="CancelEdit_Click" ForeColor="Red" Text="Cancel"/>

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
                        <asp:Button ID="Button2" runat="server" onclick="CancelDelete_Click" ForeColor="Red" Text="Cancel"/>

                        <br />
                        <br />
        </asp:Panel>

        <asp:Panel ID="ViewCalendarPanel" runat="server" Height="442px" Width="555px">
             <asp:Button ID="Back" runat="server" onclick="Back_Click" Text="Back"/>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="AddEventButton" runat="server" onclick="AddEvent_Click" Text="Add Event" />
             <br />
               <br />
               <asp:Calendar ID="PMCalendar" runat="server" Height="306px" Width="555px" 
                onselectionchanged="PMCalendar_SelectionChanged"/>
       


        </asp:Panel>

        <asp:Panel ID="AddEventPanel" runat="server" Height="442px" Width="555px">
            Event Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="NewEventNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Event Start Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Year
            <asp:TextBox ID="StartYear" runat="server" Width="55px"></asp:TextBox>
            &nbsp;&nbsp;Month
            <asp:TextBox ID="StartMonth" runat="server" Width="39px"></asp:TextBox>
            &nbsp;&nbsp;Day
            <asp:TextBox ID="StartDay" runat="server" Width="40px"></asp:TextBox>
            &nbsp;&nbsp;Hour&nbsp;
            <asp:TextBox ID="StartHour" runat="server" Width="38px"></asp:TextBox>
            &nbsp; Minute
            <asp:TextBox ID="StartMinute" runat="server" Width="38px"></asp:TextBox>
            <br />
            <br />
            Event End Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Year
            <asp:TextBox ID="EndYear" runat="server" Width="55px"></asp:TextBox>
            &nbsp;&nbsp;Month
            <asp:TextBox ID="EndMonth" runat="server" Width="39px"></asp:TextBox>
            &nbsp;&nbsp;Day
            <asp:TextBox ID="EndDay" runat="server" Width="40px"></asp:TextBox>
            &nbsp;&nbsp;Hour&nbsp;
            <asp:TextBox ID="EndHour" runat="server" Width="38px"></asp:TextBox>
            &nbsp; Minute
            <asp:TextBox ID="EndMinute" runat="server" Width="38px"></asp:TextBox>
            <br />
            <br />
            Event Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="TypeDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="SaveNewEvent" runat="server" onclick="SaveNewEvent_Click" 
                Text="Save" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CancelNewEvent" runat="server" ForeColor="Red" 
                onclick="CancelNewEvent_Click" Text="Cancel" />

        </asp:Panel>
        <asp:Panel ID="DeleteEventPanel" runat="server" Height="442px" Width="555px">
            <br />
            Choose Events to delete:&nbsp;
            <asp:CheckBoxList ID="DeleteEventCheckBox" runat="server">
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="DeleteEventButton" runat="server" Text="Delete" OnClick="DeleteEvent" />
            &nbsp;
            <asp:Button ID="CancelDeleteEvent" runat="server" Text="Cancel" ForeColor="Red" onclick="CancelDeleteEventClick" />
            <br />
            <br />
            
        </asp:Panel>
    </div>
    </div>
</asp:Content>

