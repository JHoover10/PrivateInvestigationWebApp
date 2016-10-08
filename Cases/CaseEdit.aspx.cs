using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class CaseEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditCase(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            Session.Add("Num", row.Cells[0].Text);
            GlobalVariables.fromCasePage = true;
            Response.Redirect("~/Cases/CaseEditSelected.aspx");
        }
    }
}