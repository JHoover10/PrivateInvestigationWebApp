using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace WebApplication1
{
    public partial class TasksTab : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                               
                //if user logged in:
                if (Session["User"] != null)
                {
                    conn.Open();
                    Guid uuid = (Guid)Session["User"]; 

                    if (!this.IsPostBack)
                    {
                        ddl_clientName.DataSource = GetDataTable("select DISTINCT ClientName from CaseIntake");
                        ddl_clientName.DataTextField = "ClientName";
                        ddl_clientName.DataValueField = "ClientName";
                        ddl_clientName.DataBind();             

                        SqlCommand com = new SqlCommand("select Type from ACCOUNT where ID = '" + uuid + "'", conn);
                        bool admin = Convert.ToBoolean(com.ExecuteScalar().ToString());

                        com = new SqlCommand("select Email from ACCOUNT where ID = '" + uuid + "'", conn);
                        string email = com.ExecuteScalar().ToString().TrimEnd(' ');

                        // If logged in user is an admin, load all tasks
                        if (admin)
                        {
                            int i = 0;
                            GridView1.DataSource = GetDataTable("select * from TASKS");
                            GridView1.DataBind(); // bind data

                            DataTable stats = GetDataTable("select Status FROM TASKS");
                            foreach (DataRow row in stats.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    string s = item.ToString().TrimEnd(' ');
                                    DropDownList stat = GridView1.Rows[i].Cells[8].FindControl("ddl_status") as DropDownList;
                                    stat.Items.FindByText(s).Selected = true;
                                    
                                }
                                ++i;
                            }
                        }

                        // If not, load tasks only for account currently logged in
                        else
                        {
                            int i = 0;
                            GridView1.DataSource = GetDataTable("select * from TASKS WHERE Email = '" + email + "'");
                            GridView1.DataBind(); // bind data
                            
                            DataTable stats = GetDataTable("select Status FROM TASKS WHERE Email = '" + email + "'");
                            foreach (DataRow row in stats.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    string s = item.ToString().TrimEnd(' ');
                                    DropDownList stat = GridView1.Rows[i].Cells[8].FindControl("ddl_status") as DropDownList;
                                    stat.Items.FindByText(s).Selected = true;
                                }
                                ++i;
                            }
                            
                        }
                    }
                    conn.Close();
                }

                else
                {
                    conn.Close();
                    Response.Redirect("../Account/Login.aspx");
                }

            }
            //SHOULD bounce user to login page if no session found. SHOULD
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                //Response.Redirect("../Account/Login.aspx");
            }
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
                // when mouse leaves the row, change the bg color to its original value   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");

                string TaskNum = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvNotes = e.Row.FindControl("gvNotes") as GridView;
                gvNotes.DataSource = GetDataTable(string.Format("select * from NOTES where TaskNum='{0}'", TaskNum));
                gvNotes.DataBind();

          //      CheckBox checkBox = e.Row.Cells[7].Controls[0] as CheckBox;
          //      checkBox.Enabled = true;
          //      e.Row.Cells[7].DataBind();

            }
        }


        protected void AssignTask_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("select Type from ACCOUNT where ID = '" + (Guid)Session["User"] + "'", conn);
            bool admin = Convert.ToBoolean(com.ExecuteScalar().ToString());
            if (admin)
                Response.Redirect("AssignTask.aspx");
            else
                Response.Write("<script> alert('You do not have permission to assign a task.')</script>");
            conn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "addNote")
            {
                //On click of "addNote" button, Read index and redirect to addNote Page.
                conn.Open();
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                string taskNum = row.Cells[1].Text;
                Session.Add("Task", taskNum);

                Response.Redirect("/Tasks/AddNote.aspx");
                conn.Close();
            }

            if (e.CommandName == "Reminder")
            {
                try
                {
                    conn.Open();
                    //Display message when not logged in as admin
                    //if "USER_TYPE" != 1, Display message saying "Only Admin Can Send Reminders"
                    SqlCommand com = new SqlCommand("select Type from ACCOUNT where ID = '" + (Guid)Session["User"] + "'", conn);
                    bool admin = Convert.ToBoolean(com.ExecuteScalar().ToString());
                    if (admin)
                    {
                        int index = Convert.ToInt32(e.CommandArgument);

                        // Read get stuff from gridview to be used with email 
                        GridViewRow row = GridView1.Rows[index];
                        string email = row.Cells[4].Text;
                        string task = row.Cells[5].Text;
                        string dateAssigned = Convert.ToString(row.Cells[7].Text);

                        send_reminder(email, task, dateAssigned);
                        Response.Write("<script> alert('Reminder has been sent!')</script>");
                        
                    }
                    else
                        Response.Write("<script> alert('You do not have permission to send a reminder.')</script>");
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        private void send_reminder(string email, string task, string dateAssigned)
        {
            // Variables used to send email.
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            string body = "On <b>" + dateAssigned + "</b>, you were assigned the following task: <br /> <br /><b>" + task + "</b><br /> <br /> Please see to it that you complete this task as soon as possible, Please and Thank You! :) <br /> Your Supreme Overlord, Anthony Baker";
            MailMessage message = new MailMessage(fromEmailAddress, email);
            message.Subject = "Reminder: You have a task that needs your attention!";
            message.IsBodyHtml = true;
            message.Body = body + "<br/> a link to the website can be found below: <br/>http://usfquinnproject-001-site1.ftempurl.com/";

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = true;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }

        private void email_complete(string email, string task, string dateAssigned)
        {
            // Variables used to send email.
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            string body = "On <b>" + dateAssigned + "</b>, the following task has been completed: <br /> <br /><b>" + task + "</b><br /> <br />Thank You! :) <br /> Your Supreme Overlord, Anthony Baker";
            MailMessage message = new MailMessage(fromEmailAddress, email);
            message.Subject = "A task has been completed";
            message.IsBodyHtml = true;
            message.Body = body + "<br/> a link to the website can be found below: <br/>http://usfquinnproject-001-site1.ftempurl.com/";

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = true;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
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
                ddl_caseNum.DataSource = GetDataTable("select DISTINCT CaseNumber FROM CaseIntake WHERE ClientName = '" + ddl_clientName.Text + "'");
                ddl_caseNum.DataTextField = "CaseNumber";
                ddl_caseNum.DataValueField = "CaseNumber";
                ddl_caseNum.DataBind(); // bind data
                                        
            }
        }

        protected void Sort_Click(object sender, EventArgs e)
        {
            if(ddl_clientName.SelectedValue == "All Cases")
            {
                Response.Redirect("TasksTab.aspx");
            }
            else
            {
                GridView1.DataSource = GetDataTable("select * FROM TASKS WHERE ClientName = '" + ddl_clientName.Text + "' AND CaseNum = '" + ddl_caseNum.Text + "'");
                GridView1.DataBind();
            }
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            GridViewRow row = GridView1.Rows[index];
            String taskNum = row.Cells[1].Text;

            conn.Open();

            string delete = "DELETE from TASKS WHERE TaskNum = " + taskNum ;
            SqlCommand com = new SqlCommand(delete, conn);
            com.ExecuteNonQuery();
            Response.Redirect("TasksTab.aspx");

            conn.Close();
        }

        private void ShowMessage(int count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(count.ToString());
            sb.Append(" records deleted.');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(),
                            "script", sb.ToString());
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddl_selected_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            string status = ddl.SelectedValue;
            string taskNum = row.Cells[1].Text;
            conn.Open();

            SqlCommand com = new SqlCommand("select status from TASKS where taskNum = '" + taskNum + "'", conn);
            string currentStat = com.ExecuteScalar().ToString();

            if (status == "Pending" && currentStat != "Completed")
            {
                string update = "UPDATE TASKS SET Status = '" + status + "' WHERE TaskNum = " + taskNum;
                com = new SqlCommand(update, conn);
                com.ExecuteNonQuery();
   
            }

            if (status == "Completed" && currentStat != "Completed")
            {
                string update = "UPDATE TASKS SET Status = '" + status + "', Date_Completed = CURRENT_TIMESTAMP WHERE TaskNum = " + taskNum;
                com = new SqlCommand(update, conn);
                com.ExecuteNonQuery();
                email_complete(row.Cells[4].Text, row.Cells[5].Text, row.Cells[6].Text);
            }
            conn.Close();
            Response.Redirect("TasksTab.aspx");
            
        }

    }
}