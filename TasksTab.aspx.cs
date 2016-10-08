using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DashboardTab(object sender, EventArgs e)
        {
            Response.Redirect("DashboardTab.aspx");
        }

        protected void CasesTab(object sender, EventArgs e)
        {
            Response.Redirect("CasesTab.aspx");
        }

        protected void TemplatesTab(object sender, EventArgs e)
        {
            Response.Redirect("TemplatesTab.aspx");
        }

        protected void TasksTab(object sender, EventArgs e)
        {
            Response.Redirect("TasksTab.aspx");
        }

        protected void BillingTab(object sender, EventArgs e)
        {
            Response.Redirect("BillingTab.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}