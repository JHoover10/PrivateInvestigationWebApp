using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WitnessDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [WitnessList] WHERE [CaseNumber] = '" + Session["Num"].ToString() + "'";
        }

        protected void DownloadFiles(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            GlobalVariables.idNumber = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            Response.Redirect("~/Witness/WitnessDownloadSelected.aspx");
        }
    }
}