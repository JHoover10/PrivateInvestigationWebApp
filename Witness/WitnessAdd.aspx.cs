using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WitnessAdd : System.Web.UI.Page
    {
        Guid randID = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                SqlCommand com = new SqlCommand("INSERT INTO[WitnessList]([Id], [FirstName], [MiddleName], [LastName], [Relationship], [PhoneNumber], [StreetAddress], [City], [State], [ZipCode], [Email], [Testify], [InterviewLink1], [InterviewLink2], [CQIIntroComplete], [IntroPacketSent], [NotesAndContactAttempts], [CaseNumber]) VALUES(@Id, @FirstName, @MiddleName, @LastName, @Relationship, @PhoneNumber, @StreetAddress, @City, @State, @ZipCode, @Email, @Testify, @InterviewLink1, @InterviewLink2, @CQIIntroComplete, @IntroPacketSent, @NotesAndContactAttempts, @CaseNumber)", con);

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
                    randID = Guid.NewGuid();
                    com.Parameters.AddWithValue("@id", randID);
                }
                finally
                {
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }

            AutoFillFiles();
            Response.Redirect("~/Witness/WitnessList.aspx");
        }

        private void AutoFillFiles()
        {
            string newwitnessPath = Server.MapPath(@"~\Cases\Cases Library\" + Session["Num"].ToString() + " - " + Session["Name"].ToString()) + @"\WitnessFiles\" + randID.ToString();
            string newrecordPath = Server.MapPath(@"~\Cases\Cases Library\" + Session["Num"].ToString() + " - " + Session["Name"].ToString()) + @"\RecordsFiles\" + randID.ToString();
            string templateWitness = Server.MapPath(@"~\Templates\Witness Templates");
            string templateRecords = Server.MapPath(@"~\Templates\Record Request");
            string newFileName = "";
            var splitHolder = FirstName.Text.Split(' ');

            string date = DateTime.Today.ToString();
            string dateFill;
            splitHolder = date.Split(' ');
            date = dateFill = splitHolder[0];
            date = date.Replace("/", "");

            if (!Directory.Exists(newwitnessPath))
                Directory.CreateDirectory(newwitnessPath);
            else
                Response.Write("Error creating folder. That folder already exists");

            if (!Directory.Exists(newrecordPath))
                Directory.CreateDirectory(newrecordPath);
            else
                Response.Write("Error creating folder. That folder already exists");

            string ClientName = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                SqlCommand com = new SqlCommand("SELECT * FROM [CaseIntake] WHERE [CaseNumber]='" + Session["Num"].ToString() + "'", con);
                com.Connection = con;
                com.CommandText = "SELECT * FROM [CaseIntake] WHERE [CaseNumber]='" + Session["Num"].ToString() + "'";

                try
                {
                    con.Open();

                    using (SqlDataReader read = com.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ClientName = read["ClientName"].ToString();
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
            }

            string[] getFiles;

            if (System.IO.Directory.Exists(templateWitness))
            {
                getFiles = System.IO.Directory.GetFiles(templateWitness);

                foreach (string x in getFiles)
                {
                    splitHolder = x.Split('\\');
                    newFileName = splitHolder[splitHolder.Length - 1];
                    newFileName = newFileName.Remove(0, 6);
                    newFileName = newFileName.Remove(newFileName.Length - 12, 12);
                    newFileName = newFileName.Insert(0, LastName.Text + ", " + FirstName.Text[0] + " ");
                    newFileName = newFileName.Insert(newFileName.Length, " " + date.ToString() + ".docx");

                    File.Copy(x, newwitnessPath + @"\" + newFileName);
                }
            }

            if (System.IO.Directory.Exists(templateWitness))
            {
                getFiles = System.IO.Directory.GetFiles(newwitnessPath);

                foreach (string x in getFiles)
                {
                    using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(x, true))
                    {
                        string docText = null;

                        using (StreamReader sr = new StreamReader(wordprocessingDocument.MainDocumentPart.GetStream()))
                            docText = sr.ReadToEnd();

                        Regex regexText = new Regex("@ClientName:");
                        docText = regexText.Replace(docText, "Client Name: " + ClientName);

                        regexText = new Regex("@ClientName");
                        docText = regexText.Replace(docText, ClientName);

                        regexText = new Regex("@CaseNumber");
                        docText = regexText.Replace(docText, Session["Num"].ToString());

                        regexText = new Regex("@Name:");
                        docText = regexText.Replace(docText, "Name: " + FirstName.Text + " " + LastName.Text);

                        regexText = new Regex("@WName");
                        docText = regexText.Replace(docText, FirstName.Text + " " + LastName.Text);

                        regexText = new Regex("@Address:");
                        docText = regexText.Replace(docText, "Address: " + StreetAddress.Text + " " + City.Text + ", " + State.Text + " " + ZipCode.Text);

                        regexText = new Regex("@PhoneNumber:");
                        docText = regexText.Replace(docText, "Phone Number: " + PhoneNumber.Text);

                        regexText = new Regex("@Email:");
                        docText = regexText.Replace(docText, "E-mail: " + Email.Text);

                        regexText = new Regex("@Relationship:");
                        docText = regexText.Replace(docText, "Relationship to Client: " + Relationship.Text);

                        regexText = new Regex("@Date");
                        docText = regexText.Replace(docText, dateFill);

                        regexText = new Regex("@StreetAddress");
                        docText = regexText.Replace(docText, StreetAddress.Text);

                        regexText = new Regex("@CityStateZip");
                        docText = regexText.Replace(docText, City.Text + ", " + State.Text + " " + ZipCode.Text);

                        //newFileName = newFileName.Remove((newFileName.Length - 6), 5);
                        //regexText = new Regex("@DocumentName");
                        //docText = regexText.Replace(docText, newFileName);

                        regexText = new Regex("@Doe");
                        docText = regexText.Replace(docText, ClientName);

                        regexText = new Regex("@Does");
                        docText = regexText.Replace(docText, ClientName + "'s");

                        using (StreamWriter sw = new StreamWriter(wordprocessingDocument.MainDocumentPart.GetStream(FileMode.Create)))
                            sw.Write(docText);
                    }
                }
            }

            if (System.IO.Directory.Exists(templateRecords))
            {
                getFiles = System.IO.Directory.GetFiles(templateRecords);

                foreach (string x in getFiles)
                {
                    splitHolder = x.Split('\\');
                    newFileName = splitHolder[splitHolder.Length - 1];
                    newFileName = newFileName.Remove(0, 6);
                    newFileName = newFileName.Remove(newFileName.Length - 12, 12);
                    newFileName = newFileName.Insert(0, LastName.Text + ", " + FirstName.Text[0] + " ");
                    newFileName = newFileName.Insert(newFileName.Length, " " + date.ToString() + ".docx");

                    File.Copy(x, newrecordPath + @"\" + newFileName);
                }
            }

            if (System.IO.Directory.Exists(templateRecords))
            {
                getFiles = System.IO.Directory.GetFiles(newrecordPath);

                foreach (string x in getFiles)
                {
                    using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(x, true))
                    {
                        string docText = null;

                        using (StreamReader sr = new StreamReader(wordprocessingDocument.MainDocumentPart.GetStream()))
                            docText = sr.ReadToEnd();

                        Regex regexText = new Regex("@ClientName:");
                        docText = regexText.Replace(docText, "Client Name: " + ClientName);

                        regexText = new Regex("@ClientName");
                        docText = regexText.Replace(docText, ClientName);

                        regexText = new Regex("@Name:");
                        docText = regexText.Replace(docText, "Name: " + FirstName.Text + " " + LastName.Text);

                        regexText = new Regex("@WName");
                        docText = regexText.Replace(docText, FirstName.Text + " " + LastName.Text);

                        regexText = new Regex("@CaseNumber");
                        docText = regexText.Replace(docText, Session["Num"].ToString());

                        regexText = new Regex("@Address:");
                        docText = regexText.Replace(docText, "Address: " + StreetAddress.Text + " " + City.Text + ", " + State.Text + " " + ZipCode.Text);

                        regexText = new Regex("@PhoneNumber:");
                        docText = regexText.Replace(docText, "Phone Number: " + PhoneNumber.Text);

                        regexText = new Regex("@Email:");
                        docText = regexText.Replace(docText, "E-mail: " + Email.Text);

                        regexText = new Regex("@Relationship:");
                        docText = regexText.Replace(docText, "Relationship to Client: " + Relationship.Text);

                        regexText = new Regex("@Date");
                        docText = regexText.Replace(docText, dateFill);

                        regexText = new Regex("@StreetAddress");
                        docText = regexText.Replace(docText, StreetAddress.Text);

                        regexText = new Regex("@CityStateZip");
                        docText = regexText.Replace(docText, City.Text + ", " + State.Text + " " + ZipCode.Text);

                        //newFileName = newFileName.Remove((newFileName.Length - 6), 5);
                        //regexText = new Regex("@DocumentName");
                        //docText = regexText.Replace(docText, newFileName);

                        regexText = new Regex("@Doe");
                        docText = regexText.Replace(docText, ClientName);

                        regexText = new Regex("@Does");
                        docText = regexText.Replace(docText, ClientName + "'s");

                        using (StreamWriter sw = new StreamWriter(wordprocessingDocument.MainDocumentPart.GetStream(FileMode.Create)))
                            sw.Write(docText);
                    }
                }
            }
        }
    }
}