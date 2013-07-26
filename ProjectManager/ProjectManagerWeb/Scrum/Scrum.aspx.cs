using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagerWeb.Scrum
{
    public partial class Scrum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlSelection.SelectedIndex != 0)
            {
                Response.Redirect(ddlSelection.SelectedValue);
            }
        }
    }
}