using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class AddNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                int taskNum = Convert.ToInt32((string)(Session["Task"])); //Convert taskNum read from previous page to a int

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();

                string insertQuery = "insert into NOTES(TaskNum,Note,Timestamp) values (@taskNum, @note, @timestamp)";
                SqlCommand com = new SqlCommand(insertQuery, con);

                com.Parameters.AddWithValue("@taskNum", taskNum);
                com.Parameters.AddWithValue("@note", TextBox_Note.Text);
                com.Parameters.AddWithValue("@timestamp", DateTime.Now);

                com.ExecuteNonQuery();
                Response.Redirect("TasksTab.aspx");
                Response.Write("Note Added.");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}