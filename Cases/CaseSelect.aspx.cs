using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.IO;
using Ionic.Zip;

namespace WebApplication1
{
    public partial class CaseSelect : System.Web.UI.Page
    {
        public string[] files = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string caseNum = Session["Num"].ToString();

                CaseNumber.Text = caseNum;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                {                   

                    SqlCommand com = new SqlCommand("SELECT * FROM [CaseIntake] WHERE [CaseNumber]='" + caseNum + "'", con);


                    try
                    {
                        con.Open();

                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                byte[] img = (byte[])dr["ClientImage"];
                                int stateFL = (int)dr["StateOfFloridaDD"];
                                int US = (int)dr["UnitedStatesDD"];
                                bool checkFL = (bool)dr["CheckBoxState"];
                                bool checkUS = (bool)dr["CheckBoxUS"];
                                bool phaseOne = (bool)dr["PhaseOneCB"];
                                bool phaseTwo = (bool)dr["PhaseTwoCB"];

                                if (img != null)
                                {
                                    string base64String = Convert.ToBase64String(img, 0, img.Length);
                                    Image1.ImageUrl = "data:image/png;base64," + base64String;
                                }

                                ClientName.Text = dr["ClientName"].ToString();
                                ClientDOB.Text = dr["ClientDOB"].ToString();
                                LeadCounsel.Text = dr["LeadCounsel"].ToString();
                                SecondChairCounsel.Text = dr["SecondChairCounsel"].ToString();
                                Charges.Text = dr["Charges"].ToString();
                                FacilityName.Text = dr["FacilityName"].ToString();
                                BookingNumber.Text = dr["BookingNumber"].ToString();
                                CellLocation.Text = dr["CellLocation"].ToString();
                                FacilityPhone.Text = dr["FacilityPhone"].ToString();
                                MailingAddress.Text = dr["MailingAddress"].ToString();
                                PhysicalAddress.Text = dr["PhysicalAddress"].ToString();
                                VisitingPolicy.Text = dr["VisitationPolicy"].ToString();
                                JudgeName.Text = dr["JudgeName"].ToString();
                                CourtHouse.Text = dr["CourtHouse"].ToString();
                                JudgePhone.Text = dr["JudgePhone"].ToString();
                                JAEmail.Text = dr["JAEmail"].ToString();
                                JudgeAddress.Text = dr["JudgeAddress"].ToString();
                                StateAttorney1Name.Text = dr["StateAttorney1Name"].ToString();
                                StateAttorney1Phone.Text = dr["StateAttorney1Phone"].ToString();
                                StateAttorney1Email.Text = dr["StateAttorney1Email"].ToString();
                                StateAttorney1LawOffice.Text = dr["StateAttorney1LawOffice"].ToString();
                                StateParalegalName.Text = dr["StateParalegalName"].ToString();
                                StateParalegalPhone.Text = dr["StateParalegalPhone"].ToString();
                                StateParalegalEmail.Text = dr["StateParalegalEmail"].ToString();
                                StateParalegalLawOffice.Text = dr["StateParalegalLawOffice"].ToString();
                                StateAttorney2Name.Text = dr["StateAttorney2Name"].ToString();
                                StateAttorney2Phone.Text = dr["StateAttorney2Phone"].ToString();
                                StateAttorney2Email.Text = dr["StateAttorney2Email"].ToString();
                                StateAttorney2LawOffice.Text = dr["StateAttorney2LawOffice"].ToString();
                                DefenseLeadCounselName.Text = dr["DefenseLeadCounselName"].ToString();
                                DefenseLeadCounselPhone.Text = dr["DefenseLeadCounselPhone"].ToString();
                                DefenseLeadCounselEmail.Text = dr["DefenseLeadCounselEmail"].ToString();
                                DefenseLeadCounselLawOffice.Text = dr["DefenseLeadCounselLawOffice"].ToString();
                                DefenseParalegalName.Text = dr["DefenseParalegalName"].ToString();
                                DefenseParalegalPhone.Text = dr["DefenseParalegalPhone"].ToString();
                                DefenseParalegalEmail.Text = dr["DefenseParalegalEmail"].ToString();
                                DefenseParalegalLawOffice.Text = dr["DefenseParalegalLawOffice"].ToString();
                                DefenseSecondChairName.Text = dr["DefenseSecondChairName"].ToString();
                                DefenseSecondChairPhone.Text = dr["DefenseSecondChairPhone"].ToString();
                                DefenseSecondChairEmail.Text = dr["DefenseSecondChairEmail"].ToString();
                                DefenseSecondChairLawOffice.Text = dr["DefenseSecondChairLawOffice"].ToString();
                                Circuit.SelectedIndex = stateFL;
                                District.SelectedIndex = US;
                                StateOfFlorida.Checked = checkFL;
                                USbox.Checked = checkUS;
                                PhaseI.Checked = phaseOne;
                                Phase2.Checked = phaseTwo;
                                Summary.Text = dr["Summary"].ToString();
                            }
                        }
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                string fileName = "";
                string path = Server.MapPath(@".\Cases Library\" + CaseNumber.Text + " - " + ClientName.Text);
                DirectoryInfo dInfo = new DirectoryInfo(path);
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    var splitName = file.Split('\\');
                    fileName = splitName[splitName.Length - 1];
                    CheckBoxList3.Items.Add(fileName);
                }
            }
        }

        protected void Click_CaseInfoSave(object sender, EventArgs e)
        {
            Response.Redirect("~/Cases/CasePage.aspx");
        }

        protected void getFiles(object sender, EventArgs e)
        {
            // DOWNLOAD FILES AS ZIP
            //string tempPath = "";
            Response.Clear();
            Response.BufferOutput = false;  // for large files
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "filename=" + CaseNumber.Text + " - " + ClientName.Text + ".zip");

            string path = Server.MapPath(@".\Cases Library\" + CaseNumber.Text + " - " + ClientName.Text);
            DirectoryInfo dInfo = new DirectoryInfo(path);
            files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            using (ZipFile zip = new ZipFile())
            {
                for (int i = 0; i < CheckBoxList3.Items.Count; ++i)
                {
                    if (CheckBoxList3.Items[i].Selected || CheckBox5.Checked)
                    {
                        zip.AddFile(files[i], CaseNumber.Text + " - " + ClientName.Text);
                    }
                }
                zip.Save(Response.OutputStream);
            }
        }

        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}