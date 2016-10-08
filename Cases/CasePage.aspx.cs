using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            //globalvariables.caseNumber = row.Cells[0].Text;
            //globalvariables.clientName = row.Cells[1].Text;
            Session.Add("Name", row.Cells[1].Text);
            Session.Add("Num", row.Cells[0].Text);
            Response.Redirect("~/Cases/CaseInfo.aspx");
        }
    }
}