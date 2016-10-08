using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication1
{
    public partial class CaseInfo : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ClientName.Text = Session["Name"].ToString();//read["ClientName"].ToString();
            ClientNumber.Text = Session["Num"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM [CaseIntake] WHERE [CaseNumber]='" + Session["Num"].ToString() + "'", con);

                    try
                    {
                        con.Open();
                        
                        using (SqlDataReader read = com.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                byte[] img = (byte[])read["ClientImage"];
                                if (img != null)
                                {
                                    string base64String = Convert.ToBase64String(img, 0, img.Length);
                                    ClientPicture.ImageUrl = "data:image/png;base64," + base64String;
                                }

                                Summary.Text = read["Summary"].ToString();

                                
                            }
                        }
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}