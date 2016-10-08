using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Cases
{
    public partial class CaseAddEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox_Name.Text = Session["Name"].ToString();
            TextBox_Num.Text = Session["Num"].ToString();
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            string insertQuery = "insert into CaseStory(ClientName,CaseNumber,Event,Description,Date) values (@ClientName, @CaseNum, @Event, @Description, @Date)";
            SqlCommand com = new SqlCommand(insertQuery, con);

            com.Parameters.AddWithValue("@ClientName", TextBox_Name.Text);
            com.Parameters.AddWithValue("@CaseNum", TextBox_Num.Text);
            com.Parameters.AddWithValue("@Event", TextBox_Event.Text);
            com.Parameters.AddWithValue("@Description", TextBox_Description.Text);
            com.Parameters.AddWithValue("@Date", TextBox_Date.Text);

            com.ExecuteNonQuery();
            Response.Redirect("CaseInfo.aspx");

            con.Close();
        }
    }
}