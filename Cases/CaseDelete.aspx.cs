using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;

namespace WebApplication1
{
    public partial class CaseDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeleteCase(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;

            string pathDel = "";
            string CaseNumber = row.Cells[0].Text;
            string ClientName = row.Cells[1].Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
				con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM [CaseIntake] WHERE [CaseNumber] = '" + CaseNumber + "'", con);         
                com.ExecuteNonQuery();
                
                com = new SqlCommand("DELETE FROM [WitnessList] WHERE [CaseNumber] = '" + CaseNumber + "'", con);
                com.ExecuteNonQuery();
                

                com = new SqlCommand("DELETE FROM [RecordLog] WHERE [CaseNumber] = '" + CaseNumber + "'", con);
                com.ExecuteNonQuery();

                // Pull TaskNum from TASKS with casenum
                
                com = new SqlCommand("SELECT TaskNum FROM [TASKS] WHERE [CaseNum] = '" + CaseNumber + "'", con);
                int tasknum = Convert.ToInt32(com.ExecuteScalar());

                // DELETE NOTES with TaskNum
                com = new SqlCommand("DELETE FROM [NOTES] WHERE [TaskNum] = '" + tasknum + "'", con);
                com.ExecuteNonQuery();

                //Delete TASKS with casenum
                com = new SqlCommand("DELETE FROM [TASKS] WHERE [CaseNum] = '" + CaseNumber + "'", con);
                com.ExecuteNonQuery();

                //Delete Casestory with casenum
                com = new SqlCommand("DELETE FROM [CaseStory] WHERE [CaseNumber] = '" + CaseNumber + "'", con);
                com.ExecuteNonQuery();

                con.Close();            
            }

            pathDel = Server.MapPath(@"~\Cases\Cases Library\" + CaseNumber + " - " + ClientName);
            Directory.Delete(pathDel, true);            

            Response.Redirect("~/Cases/CaseDelete.aspx");
        }
    }
}