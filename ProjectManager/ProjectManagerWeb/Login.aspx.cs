using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerBLL;
using ProjectManagerLibrary.Models;
using System.Web.Security;


namespace ProjectManagerWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// btnLogin_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var isValidUser = false;
                var rememberme = false;
                if (!string.IsNullOrEmpty(txtusername.Text) && !string.IsNullOrEmpty(txtpassword.Text))
                {
                    var user = new UserBLL();
                    //user.UserName = txtusername.Text;
                    //user.Password = txtpassword.Text;
                    rememberme = (bool)chbxRememberMe.Checked;

                    isValidUser = user.Login(txtusername.Text, txtpassword.Text);

                    if (isValidUser)
                    {
                        FormsAuthentication.SetAuthCookie(txtusername.Text, rememberme);
                        Response.Redirect("~/home.aspx");
                    }
                    else
                    {
                        errLable.Text = "The username and password provided is incorrect.";
                    }

                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}