using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                LoginLink.Text = "Click Here to Logout.";
            }
            else if ((this.Page.Request.FilePath != "/Account/Login.aspx") && (this.Page.Request.FilePath != "/Account/Registration.aspx"))
            {
                Response.Redirect("/Account/Login.aspx");
            }
            

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //Session["User"] = null;
            Session.Remove("User");
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Session.Remove("User");
            }
            Response.Redirect("~/Account/Login.aspx");
            LoginLink.Text = "Click Here To Login";
        }
    }
}