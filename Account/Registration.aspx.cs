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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from ACCOUNT where UserName = '" + TextBoxUser.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

                if (temp > 0)
                    Response.Write("User already exists");

                conn.Close();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection nect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                nect.Open();

                string insertQuery = "insert into ACCOUNT(ID,FirstName,LastName,UserName,Password,Email) values (@ID, @first, @last, @user, @pword, @email)";
                SqlCommand com = new SqlCommand(insertQuery, nect);

                com.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                com.Parameters.AddWithValue("@first", TextBoxFirst.Text);
                com.Parameters.AddWithValue("@last", TextBoxLast.Text);
                com.Parameters.AddWithValue("@user", TextBoxUser.Text);
                com.Parameters.AddWithValue("@pword", TextBoxPWD.Text);
                com.Parameters.AddWithValue("@email", TextBoxEmail.Text);

                com.ExecuteNonQuery();
                Response.Redirect("~/Account/Login.aspx");                    //redirects to Login page if successful
                Response.Write("Registration was successful");

                nect.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString()); // for debug purposes
            }
        }
    }
}