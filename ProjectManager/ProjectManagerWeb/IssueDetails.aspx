﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueDetails.aspx.cs" Inherits="ProjectManagerWeb.IssueDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">


    $(document).ready(function () {
        //$('#tabs div').hide(); // Hide all divs
        //$('#tabs div:first').show(); // Show the first div
        //$('#tabs ul li:first').addClass('active'); // Set the class for active state
        $('#tabs ul li a').click(function () { // When link is clicked
            $('#tabs ul li').removeClass('active'); // Remove active class from links
            $(this).parent().addClass('active'); //Set parent of clicked link class to active
            var currentTab = $(this).attr('href'); // Set currentTab to value of href attribute
            $('#tabs div').hide(); // Hide all divs
            $(currentTab).show(); // Show div with id equal to variable currentTab
            return false;
        });

        $("#divAddAttachment").hide();

        $("#btnUpload").click(function () {
            $("#divAddAttachment").hide();
            $('#tab-1').hide();
            $('#tab-2').show();
        });

        $("#btnAddNewAttachment").click(function () {
            $("#divAddAttachment").show();
        });

        $("#btnCancel").click(function () {
            $("#divAddAttachment").hide();
        });

        // if tab 2 is selected - for issue attachment.
        var tabquerystring = getParameterByName('tab');
        if (tabquerystring == 2) {
            $("#divAddAttachment").hide();
            $('#tabs ul li').removeClass('active'); // Remove active class from links
            $('body ul:nth-child(1) li:nth-child(2)').addClass('active'); //Set parent of clicked link class to active
            $('#tab-1').hide();
            $('#tab-2').show();

        }

    });

    // get query string value
    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
        
</script>

<div id="tabs">

<ul>
<li><a href="#tab-1">Issue Details</a></li>
<li><a href="#tab-2">Attachments</a></li>
</ul>

<div id="tab-1">
<h3>Issue Details</h3>

<table id="Table1" class="customtable" runat="server">
    <tr>
        <th>Issue Information</th>
        <th>Value</th>
    </tr>
    <tr>
        <td>Issue ID:</td>
        <td><asp:Label ID="lblIssueID" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Project Name</td>
        <td><asp:Label ID="lblProjectName" runat="server" Text="Label"></asp:Label></td>
        
    </tr>
    <tr>
        <td>Subject:</td>
        <td><asp:Label ID="lblSubject" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Issue Priority:</td>
        <td><asp:Label ID="lblIssuePriority" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Issue Status</td>
        <td><asp:Label ID="lblIssueStatus" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Description </td>
        <td><asp:Label ID="lblDescription" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Category</td>
        <td> <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Milestone</td>
        <td><asp:Label ID="lblMilestone" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Assignee</td>
        <td><asp:Label ID="lblAssignee" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Entry Date</td>
        <td><asp:Label ID="lblEntryDate" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lnkEditDetails" Text="Edit Details" runat="server" />
        </td>
    </tr>
</table>


</div>


<div id="tab-2">


<h3>Attachments</h3>
<button id="btnAddNewAttachment">Add Attachment</button>
<br />
<br />

<div id="divAddAttachment">
    <table id="tblAddAttachment" class="customtable" runat="server">
    <tr>
    <td>Issue Attachment:</td>
    <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
    </tr>
    <tr>
    <td>Description:</td>
    <td><asp:TextBox ID="txtDescription" runat="server" Width="450"></asp:TextBox></td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    <td><asp:Button ID="btnUpload" runat="server" Text="Submit" 
            onclick="btnUpload_Click" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" /></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblErrorMessage" ForeColor="Red" runat="server" /></td>
    </tr>
    </table>
</div>


<table id="tblAttachments" runat="server" class="customtable">
    <tr>
        <th>File Name</th>
        <th>Entry Date</th>
        <th>Mime Type</th>
        <th>Description</th>
    </tr>
    <tr>
        <td><asp:Label ID="lblFileName" runat="server"></asp:Label></td>
        <td><asp:Label ID="lblAttachmentEntryDate" runat="server"></asp:Label></td>
        <td><asp:Label ID="lblMimeType" runat="server"></asp:Label></td>
        <td><asp:Label ID="lblAttachmentDescription" runat="server"></asp:Label></td>
        <td><asp:HyperLink ID="hplAttachment" Text="" runat="server" /></td>
        <td><asp:HyperLink ID="hplDelete" Text="" runat="server" /></td>
    </tr>

</table>

</div>

</div>

</asp:Content>
