<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectManagerWeb.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                    Welcome To (Our Project Name)
                </h1>
            </div>
            
            <div class="clear hideSkiplink">
<div class="menu" id="NavigationMenu">
	<ul class="level1">
	</ul>
</div><a id="NavigationMenu_SkipLink"></a>
            </div>
            <table>
                <tr>
                    <td>
                        <div style="width: 199px; height: 446px; background-color:#bdbdbd;">
                        </div>
                    </td>
                    <td>
                        <div class="main" >

                Username: <asp:TextBox ID="txtusername" runat="server" Width="150" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Username is required." ControlToValidate="txtusername" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                Password: <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" Width="150"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="Password is required." ControlToValidate="txtpassword" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                
                            <br /><br />
                            <asp:CheckBox ID="chbxRememberMe" runat="server" Text="Remember Me" />
                
                <br />
                            <asp:Label ID="errLable" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="75px" 
                                onclick="btnLogin_Click" />

                        </div>
                    </td>
                </tr>
            </table>
            
        </div>

        
        <div class="clear">
        </div>
    </div>
    <div class="footer">
        
    </div>
 </form>   
</body>
</html>
