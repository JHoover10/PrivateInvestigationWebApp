using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WitnessEditSelected : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM [WitnessList] WHERE [Id]='" + Session["idNumberWitness"].ToString() + "'", con);
                    com.Connection = con;
                    com.CommandText = "SELECT * FROM [WitnessList] WHERE [Id]='" + Session["idNumberWitness"].ToString() + "'";

                    try
                    {
                        con.Open();

                        using (SqlDataReader read = com.ExecuteReader())
                        {
                            while(read.Read())
                            {
                                FirstName.Text = read["FirstName"].ToString();
                                MiddleName.Text = read["MiddleName"].ToString();
                                LastName.Text = read["LastName"].ToString();
                                Relationship.Text = read["Relationship"].ToString();
                                PhoneNumber.Text = read["PhoneNumber"].ToString();
                                StreetAddress.Text = read["StreetAddress"].ToString();
                                City.Text = read["City"].ToString();
                                State.Text = read["State"].ToString();
                                ZipCode.Text = read["ZipCode"].ToString();
                                Email.Text = read["Email"].ToString();
                                Testify.Text = read["Testify"].ToString();
                                Link1.Text = read["InterviewLink1"].ToString();
                                Link2.Text = read["InterviewLink2"].ToString();
                                IntroComplete.Text = read["CQIIntroComplete"].ToString();
                                PacketSent.Text = read["IntroPacketSent"].ToString();
                                Notes.Text = read["NotesAndContactAttempts"].ToString();
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

        protected void SaveClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                SqlCommand com = new SqlCommand("UPDATE [WitnessList] SET [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName, " +
                    "[Relationship] = @Relationship, [PhoneNumber] = @PhoneNumber, [StreetAddress] = @StreetAddress, [City] = @City, [State] = @State, " +
                    "[ZipCode] = @ZipCode, [Email] = @Email, [Testify] = @Testify, [InterviewLink1] = @InterviewLink1, [InterviewLink2] = @InterviewLink2, " +
                    "[CQIIntroComplete] = @CQIIntroComplete, [IntroPacketSent] = @IntroPacketSent, [NotesAndContactAttempts] = @NotesAndContactAttempts, " +
                    "[CaseNumber] = @CaseNumber WHERE [Id] = '" + Session["idNumberWitness"].ToString() + "'", con);

                try
                {
                    con.Open();

                    com.Parameters.AddWithValue("@CaseNumber", Session["Num"].ToString());
                    com.Parameters.AddWithValue("@FirstName", FirstName.Text);
                    com.Parameters.AddWithValue("@MiddleName", MiddleName.Text);
                    com.Parameters.AddWithValue("@LastName", LastName.Text);
                    com.Parameters.AddWithValue("@Relationship", Relationship.Text);
                    com.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
                    com.Parameters.AddWithValue("@StreetAddress", StreetAddress.Text);
                    com.Parameters.AddWithValue("@City", City.Text);
                    com.Parameters.AddWithValue("@State", State.Text);
                    com.Parameters.AddWithValue("@ZipCode", ZipCode.Text);
                    com.Parameters.AddWithValue("@Email", Email.Text);
                    com.Parameters.AddWithValue("@Testify", Testify.Text);
                    com.Parameters.AddWithValue("@InterviewLink1", Link1.Text);
                    com.Parameters.AddWithValue("@InterviewLink2", Link2.Text);
                    com.Parameters.AddWithValue("@CQIIntroComplete", IntroComplete.Text);
                    com.Parameters.AddWithValue("@IntroPacketSent", PacketSent.Text);
                    com.Parameters.AddWithValue("@NotesAndContactAttempts", Notes.Text);
                    com.Parameters.AddWithValue("@id", Session["idNumberWitness"].ToString());
                }
                finally
                {
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }

            //AutoFillFiles();
            Response.Redirect("~/Witness/WitnessEdit.aspx");
        }

        private void AutoFillFiles()
        {
            string newPath = Server.MapPath("TestFolder") + @"\" + Session["Num"].ToString();
            string templatePath = Server.MapPath("Templates");

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            else
            {
                Response.Write("Error creating folder. That folder already exists");
            }

            string[] getFiles;
            int number = 0;

            if (System.IO.Directory.Exists(templatePath))
            {
                getFiles = System.IO.Directory.GetFiles(templatePath);

                foreach (string x in getFiles)
                {
                    File.Copy(x, newPath + @"\" + number + ".docx");

                    number++;
                }
            }
        }
    }
}