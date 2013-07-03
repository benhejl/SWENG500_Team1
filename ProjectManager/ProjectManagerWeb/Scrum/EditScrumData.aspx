<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditScrumData.aspx.cs" Inherits="ProjectManagerWeb.Scrum.EditScrumData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div><asp:Label ID="Message" runat="server" ForeColor="Red" Font-Size="Larger"></asp:Label></div>
    <div>
        <table>
            <tr style="padding:10px">
                <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr style="padding:10px">
                <td><asp:TextBox ID="txtBoxAnswer1" runat="server" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr style="padding:10px">
                <td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtBoxAnswer2" runat="server" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr style="padding:10px">
                <td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtBoxAnswer3" runat="server" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Button ID="submit" runat="server" onclick="submit_Click" Text="Submit"/> &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="cancel" runat="server" Text="Cancel" onclick="cancel_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
