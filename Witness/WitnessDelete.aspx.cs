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
    public partial class WitnessDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [WitnessList] WHERE [CaseNumber] = '" + Session["Num"].ToString() + "'";
        }

        protected void DeleteCase(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            //GlobalVariables.idNumber = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            string idNumber = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            string caseNumber = " ";
            string caseName = " ";

            //string pathDel = Server.MapPath(@"~\Cases\Cases Library\" + CaseNumber + " - " + ClientName);
            //string CaseNumber = row.Cells[0].Text;
            //string ClientName = row.Cells[1].Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                SqlCommand com = new SqlCommand("SELECT * FROM [WitnessList] WHERE [id] = '" + idNumber + "'", con);

                try
                {
                    con.Open();

                    using (SqlDataReader read = com.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            caseNumber = read["CaseNumber"].ToString();
                        }
                    }
                }
                finally
                {
                    con.Close();

                }

                com = new SqlCommand("DELETE FROM [WitnessList] WHERE [id] = '" + idNumber + "'", con);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                com = new SqlCommand("SELECT * FROM [CaseIntake] WHERE [CaseNumber] = '" + caseNumber + "'", con);

                try
                {
                    con.Open();

                    using (SqlDataReader read = com.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            caseName = read["ClientName"].ToString();
                        }
                    }
                }
                finally
                {
                    con.Close();

                }
            }

            //pathDel = Server.MapPath(@"~\Cases\Cases Library\" + CaseNumber + " - " + ClientName);
            string pathDel = Server.MapPath(@"~\Cases\Cases Library\" + caseNumber + " - " + caseName + @"\RecordsFiles\" + idNumber);
            Directory.Delete(pathDel, true);
            pathDel = Server.MapPath(@"~\Cases\Cases Library\" + caseNumber + " - " + caseName + @"\WitnessFiles\" + idNumber);
            Directory.Delete(pathDel, true);

            Response.Redirect("~/Witness/WitnessDelete.aspx");
        }
    }
}