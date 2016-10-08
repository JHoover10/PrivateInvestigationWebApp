using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                // Query reads table and counts the number of times the email and password typed in by User.
                // If user provided info not found, inform user.
                string checkLogin = "select count(*) from ACCOUNT where Email = '" + login_email.Text + "' and Password = '" + login_pwd.Text + "'";
                SqlCommand com = new SqlCommand(checkLogin, conn);

                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

                if (temp == 1)
                {
                    //Use unique ID create session and identify specific users
                    com = new SqlCommand("select ID from ACCOUNT where Email = '" + login_email.Text + "'", conn);
                    Guid uuid = (Guid)com.ExecuteScalar();
                    Session.Add("User", uuid);
                    //  Response.Write("Login Successful.");
                    conn.Close();
                    Response.Redirect("~/Dashboard.aspx");
                }

                else
                    Response.Write("<script> alert('Email or Password was incorrect') </script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> Console.log('" + ex.ToString() + "') </script>");
            }
        }

        protected void Button_Reg_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Registration.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}