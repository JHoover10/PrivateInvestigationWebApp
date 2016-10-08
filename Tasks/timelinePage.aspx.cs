using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1.Tasks
{
    public partial class timelinePage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_clientName.DataSource = GetData("select DISTINCT ClientName from CaseIntake");
                ddl_clientName.DataTextField = "ClientName";
                ddl_clientName.DataValueField = "ClientName";
                ddl_clientName.DataBind();

                ddl_caseNum.DataSource = GetData("select DISTINCT CaseNumber FROM CaseIntake WHERE ClientName = '" + ddl_clientName.Text + "'");
                ddl_caseNum.DataTextField = "CaseNumber";
                ddl_caseNum.DataValueField = "CaseNumber";
                ddl_caseNum.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_clientName.SelectedValue == "All Cases")
            {
                ddl_caseNum.Items.Clear();
                ddl_caseNum.Items.Add("All Cases");
            }
            else
            {
                ddl_caseNum.Items.Clear();
                ddl_caseNum.DataSource = GetData("select DISTINCT CaseNumber FROM CaseIntake WHERE ClientName = '" + ddl_clientName.Text + "'");
                ddl_caseNum.DataTextField = "CaseNumber";
                ddl_caseNum.DataValueField = "CaseNumber";
                ddl_caseNum.DataBind(); // bind data

            }
        }

        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

    }
    
}