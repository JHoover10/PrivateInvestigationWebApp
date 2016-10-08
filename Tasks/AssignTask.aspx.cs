using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Data;

namespace WebApplication1
{
    public partial class AssignTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ddl_name.DataSource = GetDataTable("select DISTINCT ClientName from CaseIntake");
                ddl_name.DataTextField = "ClientName";
                ddl_name.DataValueField = "ClientName";
                ddl_name.DataBind();

                ddl_caseNum.Items.Clear();
                ddl_caseNum.DataSource = GetDataTable("select DISTINCT CaseNumber FROM CaseIntake WHERE ClientName = '" + ddl_name.Text + "'");
                ddl_caseNum.DataTextField = "CaseNumber";
                ddl_caseNum.DataValueField = "CaseNumber";
                ddl_caseNum.DataBind(); // bind data
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection nect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                nect.Open();

                string insertQuery = "insert into TASKS(ClientName,CaseNum,Email,Task,Date_Assigned) values (@ClientName, @caseNum, @email, @task, @date)";
                SqlCommand com = new SqlCommand(insertQuery, nect);

                com.Parameters.AddWithValue("@ClientName", ddl_name.SelectedValue);
                com.Parameters.AddWithValue("@caseNum", ddl_caseNum.SelectedValue);
                com.Parameters.AddWithValue("@email", DropDownList1.SelectedValue);
                com.Parameters.AddWithValue("@task", TextBox_Task.Text);
                com.Parameters.AddWithValue("@date", DateTime.Now);

                com.ExecuteNonQuery();
                sendEmail(DropDownList1.Text, TextBox_Task.Text);
                Response.Redirect("TasksTab.aspx");
                Response.Write("New Task Assigned.");

                nect.Close();


            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }

        }

        private void sendEmail(string email, string task)
        {

            // Variables used to send email.
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            string body = "A new task is available for you to complete! The task description is can be found below: <br /> <br />" + task + "<br /> <br /> Please complete this task as soon as possible! <br /> Your Supreme Overlord will be pleased :)";
            MailMessage message = new MailMessage(fromEmailAddress, email);
            message.Subject = "You have just been assigned a task!";
            message.IsBodyHtml = true;
            message.Body = body + "<br/> a link to the website can be found below: <br/>http://usfquinnproject-001-site1.ftempurl.com/";

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = true;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
            client.UseDefaultCredentials = false;
        }

        protected void ddl_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_caseNum.Items.Clear();
            ddl_caseNum.DataSource = GetDataTable("select DISTINCT CaseNumber FROM CaseIntake WHERE ClientName = '" + ddl_name.Text + "'");
            ddl_caseNum.DataTextField = "CaseNumber";
            ddl_caseNum.DataValueField = "CaseNumber";
            ddl_caseNum.DataBind(); // bind data

        }

        private static DataTable GetDataTable(string query)
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