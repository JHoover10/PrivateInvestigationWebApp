using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using System.Data;

namespace WebApplication1
{
    public partial class CaseEditSelected : System.Web.UI.Page
    {
        public string imgPath = "";
        public string sqlConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string folderPath = "";
        public string targetPath = "";
        public string lastName = "", rename = "";
        string caseNum = "";
        byte[] img = null;
        int stateFL = 0;
        int tempUS = 0;
        bool checkFL, checkUS, phaseOne, PhaseTwo;

        protected void Click_CaseInfoSave(object sender, EventArgs e)
        {
            imgPath = UploadImage.FileName;

            SqlConnection con = new SqlConnection(sqlConnect);
            {
                SqlCommand com = new SqlCommand("UPDATE [CaseIntake] SET [ClientName] = @ClientName, [LeadCounsel] = @LeadCounsel, [SecondChairCounsel] = @SecondChairCounsel, [ClientDOB] = @ClientDOB, " +
                    "[Charges] = @Charges, [FacilityName] = @FacilityName, [BookingNumber] = @BookingNumber, [CellLocation] = @CellLocation, [FacilityPhone] = @FacilityPhone, " +
                    "[MailingAddress] = @MailingAddress, [PhysicalAddress] = @PhysicalAddress, [VisitationPolicy] = @VisitationPolicy, [JudgeName] = @JudgeName, [CourtHouse] = " +
                    "@CourtHouse, [JudgePhone] = @JudgePhone, [JAEmail] = @JAEmail, [JudgeAddress] = @JudgeAddress, [StateAttorney1Name] = @StateAttorney1Name, [StateAttorney1Phone] " +
                    "= @StateAttorney1Phone, [StateAttorney1Email] = @StateAttorney1Email, [StateAttorney1LawOffice] = @StateAttorney1LawOffice, [StateParalegalName] = @StateParalegalName, " +
                    "[StateParalegalPhone] = @StateParalegalPhone, [StateParalegalEmail] = @StateParalegalEmail, [StateParalegalLawOffice] = @StateParalegalLawOffice, [StateAttorney2Name] = " +
                    "@StateAttorney2Name, [StateAttorney2Phone] = @StateAttorney2Phone, [StateAttorney2Email] = @StateAttorney2Email, [StateAttorney2LawOffice] = @StateAttorney2LawOffice, " +
                    "[DefenseLeadCounselName] = @DefenseLeadCounselName, [DefenseLeadCounselPhone] = @DefenseLeadCounselPhone, [DefenseLeadCounselEmail] = @DefenseLeadCounselEmail, " +
                    "[DefenseLeadCounselLawOffice] = @DefenseLeadCounselLawOffice, [DefenseParalegalName] = @DefenseParalegalName, [DefenseParalegalPhone] = @DefenseParalegalPhone, " +
                    "[DefenseParalegalEmail] = @DefenseParalegalEmail, [DefenseParalegalLawOffice] = @DefenseParalegalLawOffice, [DefenseSecondChairName] = @DefenseSecondChairName, " +
                    "[DefenseSecondChairPhone] = @DefenseSecondChairPhone, [DefenseSecondChairEmail] = @DefenseSecondChairEmail, [DefenseSecondChairLawOffice] = @DefenseSecondChairLawOffice, " +
                    "[StateOfFloridaDD] = @StateOfFloridaDD, [UnitedStatesDD] = @UnitedStatesDD, [CheckBoxState] = @CheckBoxState, [CheckBoxUS] = @CheckBoxUS, [PhaseOneCB] = @PhaseOneCB, [PhaseTwoCB] = @PhaseTwoCB, " +
                    "[Summary] = @Summary WHERE [CaseNumber] = @CaseNumber", con);

                com.Parameters.AddWithValue("@ClientName", ClientName.Text);
                com.Parameters.AddWithValue("@CaseNumber", CaseNumber.Text);
                com.Parameters.AddWithValue("@LeadCounsel", LeadCounsel.Text);
                com.Parameters.AddWithValue("@SecondChairCounsel", SecondChairCounsel.Text);
                com.Parameters.AddWithValue("@Charges", Charges.Text);
                com.Parameters.AddWithValue("@FacilityName", FacilityName.Text);
                com.Parameters.AddWithValue("@BookingNumber", BookingNumber.Text);
                com.Parameters.AddWithValue("@CellLocation", CellLocation.Text);
                com.Parameters.AddWithValue("@FacilityPhone", FacilityPhone.Text);
                com.Parameters.AddWithValue("@MailingAddress", MailingAddress.Text);
                com.Parameters.AddWithValue("@PhysicalAddress", PhysicalAddress.Text);
                com.Parameters.AddWithValue("@VisitationPolicy", VisitingPolicy.Text);
                com.Parameters.AddWithValue("@JudgeName", JudgeName.Text);
                com.Parameters.AddWithValue("@CourtHouse", CourtHouse.Text);
                com.Parameters.AddWithValue("@JudgePhone", JudgePhone.Text);
                com.Parameters.AddWithValue("@JAEmail", JAEmail.Text);
                com.Parameters.AddWithValue("@JudgeAddress", JudgeAddress.Text);
                com.Parameters.AddWithValue("@StateAttorney1Name", StateAttorney1Name.Text);
                com.Parameters.AddWithValue("@StateAttorney1Phone", StateAttorney1Phone.Text);
                com.Parameters.AddWithValue("@StateAttorney1Email", StateAttorney1Email.Text);
                com.Parameters.AddWithValue("@StateAttorney1LawOffice", StateAttorney1LawOffice.Text);
                com.Parameters.AddWithValue("@StateParalegalName", StateParalegalName.Text);
                com.Parameters.AddWithValue("@StateParalegalPhone", StateParalegalPhone.Text);
                com.Parameters.AddWithValue("@StateParalegalEmail", StateParalegalEmail.Text);
                com.Parameters.AddWithValue("@StateParalegalLawOffice", StateParalegalLawOffice.Text);
                com.Parameters.AddWithValue("@StateAttorney2Name", StateAttorney2Name.Text);
                com.Parameters.AddWithValue("@StateAttorney2Phone", StateAttorney2Phone.Text);
                com.Parameters.AddWithValue("@StateAttorney2Email", StateAttorney2Email.Text);
                com.Parameters.AddWithValue("@StateAttorney2LawOffice", StateAttorney2LawOffice.Text);
                com.Parameters.AddWithValue("@DefenseLeadCounselName", DefenseLeadCounselName.Text);
                com.Parameters.AddWithValue("@DefenseLeadCounselPhone", DefenseLeadCounselPhone.Text);
                com.Parameters.AddWithValue("@DefenseLeadCounselEmail", DefenseLeadCounselEmail.Text);
                com.Parameters.AddWithValue("@DefenseLeadCounselLawOffice", DefenseLeadCounselLawOffice.Text);
                com.Parameters.AddWithValue("@DefenseParalegalName", DefenseParalegalName.Text);
                com.Parameters.AddWithValue("@DefenseParalegalPhone", DefenseParalegalPhone.Text);
                com.Parameters.AddWithValue("@DefenseParalegalEmail", DefenseParalegalEmail.Text);
                com.Parameters.AddWithValue("@DefenseParalegalLawOffice", DefenseParalegalLawOffice.Text);
                com.Parameters.AddWithValue("@DefenseSecondChairName", DefenseSecondChairName.Text);
                com.Parameters.AddWithValue("@DefenseSecondChairPhone", DefenseSecondChairPhone.Text);
                com.Parameters.AddWithValue("@DefenseSecondChairEmail", DefenseSecondChairEmail.Text);
                com.Parameters.AddWithValue("@DefenseSecondChairLawOffice", DefenseSecondChairLawOffice.Text);
                com.Parameters.AddWithValue("@StateOfFloridaDD", Circuit.SelectedIndex);
                com.Parameters.AddWithValue("@UnitedStatesDD", District.SelectedIndex);
                com.Parameters.AddWithValue("@CheckBoxState", StateOfFlorida.Checked);
                com.Parameters.AddWithValue("@CheckBoxUS", US.Checked);
                com.Parameters.AddWithValue("@PhaseOneCB", PhaseI.Checked);
                com.Parameters.AddWithValue("@PhaseTwoCB", Phase2.Checked);
                com.Parameters.AddWithValue("@ClientDOB", ClientDOB.Text);
                com.Parameters.AddWithValue("@Summary", Summary.Text);

                string folderCheck = Server.MapPath("Cases Library") + "\\" + CaseNumber.Text + " - " + ClientName.Text;

                // Check to see if client name changed if so, then rename the folder
                if (folderPath != folderCheck)
                {
                    Directory.Move(folderPath, folderCheck);
                    folderPath = folderCheck;
                }

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            if (imgPath != "")
            {
                UpdateImage();
            }

            CopyFiles();
            SaveCaseInfo();
        }

        private void AutoUpdateTemplates()
        {

        }

        private void UpdateImage()
        {
            SqlConnection imgConnect = new SqlConnection(sqlConnect);
            {
                SqlCommand imgCommand = new SqlCommand("UPDATE [CaseIntake] SET [ClientImage] = @ClientImage WHERE [CaseNumber] = @CaseNumber", imgConnect);

                imgCommand.Parameters.AddWithValue("@CaseNumber", CaseNumber.Text);

                string saveLocation = folderPath + @"\" + imgPath;
                UploadImage.PostedFile.SaveAs(saveLocation);
                FileStream fs = new FileStream(saveLocation, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                img = new byte[fs.Length];
                fs.Read(img, 0, Convert.ToInt32(fs.Length));

                imgCommand.Parameters.AddWithValue("@ClientImage", img);

                imgConnect.Open();
                imgCommand.ExecuteNonQuery();
                imgConnect.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                caseNum = Session["Num"].ToString();
                CaseNumber.Text = caseNum;
                DataSet ds = new DataSet();

                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                {
                    SqlCommand com2 = new SqlCommand("SELECT * FROM [CaseIntake] WHERE [CaseNumber]='" + caseNum + "'", con2);
                    com2.Connection = con2;
                    com2.CommandText = "SELECT * FROM [CaseIntake] WHERE [CaseNumber]='" + caseNum + "'";

                    try
                    {
                        con2.Open();

                        using (SqlDataReader read1 = com2.ExecuteReader())
                        {
                            while (read1.Read())
                            {
                                img = (byte[])read1["ClientImage"];
                                stateFL = (int)read1["StateOfFloridaDD"];
                                tempUS = (int)read1["UnitedStatesDD"];
                                checkFL = (bool)read1["CheckBoxState"];
                                checkUS = (bool)read1["CheckBoxUS"];
                                phaseOne = (bool)read1["PhaseOneCB"];
                                PhaseTwo = (bool)read1["PhaseTwoCB"];

                                //if (img != null)
                                //{
                                //    string base64String = Convert.ToBase64String(img, 0, img.Length);
                                //    ClientPicture.ImageUrl = "data:image/png;base64," + base64String;
                                //}

                                ClientName.Text = read1["ClientName"].ToString();
                                LeadCounsel.Text = read1["LeadCounsel"].ToString();
                                SecondChairCounsel.Text = read1["SecondChairCounsel"].ToString();
                                Charges.Text = read1["Charges"].ToString();
                                FacilityName.Text = read1["FacilityName"].ToString();
                                BookingNumber.Text = read1["BookingNumber"].ToString();
                                CellLocation.Text = read1["CellLocation"].ToString();
                                FacilityPhone.Text = read1["FacilityPhone"].ToString();
                                MailingAddress.Text = read1["MailingAddress"].ToString();
                                PhysicalAddress.Text = read1["PhysicalAddress"].ToString();
                                VisitingPolicy.Text = read1["VisitationPolicy"].ToString();
                                JudgeName.Text = read1["JudgeName"].ToString();
                                CourtHouse.Text = read1["CourtHouse"].ToString();
                                JudgePhone.Text = read1["JudgePhone"].ToString();
                                JAEmail.Text = read1["JAEmail"].ToString();
                                JudgeAddress.Text = read1["JudgeAddress"].ToString();
                                StateAttorney1Name.Text = read1["StateAttorney1Name"].ToString();
                                StateAttorney1Phone.Text = read1["StateAttorney1Phone"].ToString();
                                StateAttorney1Email.Text = read1["StateAttorney1Email"].ToString();
                                StateAttorney1LawOffice.Text = read1["StateAttorney1LawOffice"].ToString();
                                StateParalegalName.Text = read1["StateParalegalName"].ToString();
                                StateParalegalPhone.Text = read1["StateParalegalPhone"].ToString();
                                StateParalegalEmail.Text = read1["StateParalegalEmail"].ToString();
                                StateParalegalLawOffice.Text = read1["StateParalegalLawOffice"].ToString();
                                StateAttorney2Name.Text = read1["StateAttorney2Name"].ToString();
                                StateAttorney2Phone.Text = read1["StateAttorney2Phone"].ToString();
                                StateAttorney2Email.Text = read1["StateAttorney2Email"].ToString();
                                StateAttorney2LawOffice.Text = read1["StateAttorney2LawOffice"].ToString();
                                DefenseLeadCounselName.Text = read1["DefenseLeadCounselName"].ToString();
                                DefenseLeadCounselPhone.Text = read1["DefenseLeadCounselPhone"].ToString();
                                DefenseLeadCounselEmail.Text = read1["DefenseLeadCounselEmail"].ToString();
                                DefenseLeadCounselLawOffice.Text = read1["DefenseLeadCounselLawOffice"].ToString();
                                DefenseParalegalName.Text = read1["DefenseParalegalName"].ToString();
                                DefenseParalegalPhone.Text = read1["DefenseParalegalPhone"].ToString();
                                DefenseParalegalEmail.Text = read1["DefenseParalegalEmail"].ToString();
                                DefenseParalegalLawOffice.Text = read1["DefenseParalegalLawOffice"].ToString();
                                DefenseSecondChairName.Text = read1["DefenseSecondChairName"].ToString();
                                DefenseSecondChairPhone.Text = read1["DefenseSecondChairPhone"].ToString();
                                DefenseSecondChairEmail.Text = read1["DefenseSecondChairEmail"].ToString();
                                DefenseSecondChairLawOffice.Text = read1["DefenseSecondChairLawOffice"].ToString();
                                Circuit.SelectedIndex = stateFL;
                                District.SelectedIndex = tempUS;
                                StateOfFlorida.Checked = checkFL;
                                US.Checked = checkUS;
                                PhaseI.Checked = phaseOne;
                                Phase2.Checked = PhaseTwo;
                                ClientDOB.Text = read1["ClientDOB"].ToString();
                                Summary.Text = read1["Summary"].ToString();
                            }
                        }
                    }
                    finally
                    {
                        con2.Close();
                    }
                }
            }
            folderPath = Server.MapPath("Cases Library") + "\\" + CaseNumber.Text + " - " + ClientName.Text;
        }

        private void SaveCaseInfo()
        {
            Response.Redirect("~/Cases/CasePage.aspx");
            // This one was used to just refresh the page, but because of the IsPostBack condition the page_load will not run again
            //Response.Redirect(Request.RawUrl);
        }

        private void CopyFiles()
        {
            string mitPath = Server.MapPath(@"~\MITIGATION TEMPLATES");
            string investPath = Server.MapPath(@"~\INVESTIGATION TEMPLATES");
            string privateInvestPath = Server.MapPath(@"~\PRIVATE INVESTIGATION TEMPLATES");
            string oldName = "", newName = "", firstName = "";
            string date = "";
            string[] getFiles;
            string fileName, destFile;
            string tempPath, previousPath, previousTargetPath, returnTargetPath, saveDirectory;
            string folder = Server.MapPath(@".\Cases Library\" + CaseNumber.Text + " - " + ClientName.Text);

            targetPath = folder + @"\";

            if (System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.Delete(folder, true);
                System.IO.Directory.CreateDirectory(folder);
                targetPath = folder + @"\";
            }

            var splitName = ClientName.Text.Split(' ');

            switch (splitName.Length)
            {
                case 1:
                    firstName = splitName[0];
                    break;
                case 2:
                    firstName = splitName[0];
                    lastName = splitName[1];
                    break;
                default:
                    firstName = splitName[0];
                    lastName = splitName[splitName.Length - 1];
                    break;
            }

            saveDirectory = targetPath;

            date = DateTime.Today.ToString();
            splitName = date.Split(' ');
            date = splitName[0];
            date = date.Replace("/", "");

            var nameBuilder = new StringBuilder(firstName);
            nameBuilder.Remove(1, firstName.Length - 1);
            firstName = nameBuilder.ToString();

            rename = lastName + ", " + firstName + ",";

            // If mitigation is checked then create all files for mitigation
            if (Phase2.Checked)
            {
                if (System.IO.Directory.Exists(mitPath))
                {
                    // Get files in MITIGATION TEMPLATES
                    getFiles = System.IO.Directory.GetFiles(mitPath);

                    targetPath = targetPath + @"\MITIGATION";
                    returnTargetPath = targetPath;

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    tempPath = mitPath + @"\EXTERNAL";
                    targetPath = targetPath + @"\EXTERNAL";

                    // Keep track of previous path to return
                    previousPath = tempPath;
                    previousTargetPath = targetPath;

                    // Get files in EXTERNAL TEMPLATES - Mitigation
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TLO"))
                        {
                            changeName.Remove(0, 12);   //Sample TLO - (12)
                        }
                        else if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    tempPath = tempPath + @"\CLIENT INTRO PACKET";
                    targetPath = targetPath + @"\CLIENT INTRO PACKET";

                    // Get files in CLIENT INTRODUCTION PACKET
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    // Return to previous directory for next folder
                    tempPath = previousPath;
                    targetPath = previousTargetPath;

                    tempPath = tempPath + @"\WITNESS INTERVIEW FORMS";
                    targetPath = targetPath + @"\WITNESS INTERVIEW FORMS";

                    // Get files in MITIGATION WITNESS INTERVIEW PREP FORMS
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    // Return to previous directory for next folder
                    tempPath = previousPath;
                    targetPath = previousTargetPath;

                    tempPath = tempPath + @"\MOTIONS";
                    targetPath = targetPath + @"\MOTIONS";

                    // Get files in MOTIONS
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    // Return to previous directory for next folder
                    tempPath = previousPath;
                    targetPath = previousTargetPath;

                    tempPath = tempPath + @"\RECORD REQUEST LETTERS";
                    targetPath = targetPath + @"\RECORD REQUEST LETTERS";

                    // Get files in RECORD REQUEST LETTERS
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    // Return to previous directory for next folder
                    tempPath = previousPath;
                    targetPath = previousTargetPath;

                    tempPath = tempPath + @"\WITNESS INTRO PACKET";
                    targetPath = targetPath + @"\WITNESS INTRO PACKET";

                    // Get files in WITNESS INTRODUCTION PACKET
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    // Return to previous directory for next folder
                    tempPath = mitPath;
                    targetPath = returnTargetPath;

                    tempPath = tempPath + @"\INTERNAL";
                    targetPath = targetPath + @"\INTERNAL";

                    // Keep track of previous path to return
                    previousPath = tempPath;
                    previousTargetPath = targetPath;

                    // Get files in INTERNAL TEMPLATES - Mitigation
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        if (File.Exists(targetPath + @"\" + newName))
                        {
                            int index = newName.IndexOf('.');
                            newName = newName.Insert(index, "(1)");
                        }

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    tempPath = tempPath + @"\PENDING CQ REVIEW";
                    targetPath = targetPath + @"\PENDING CQ REVIEW";

                    // Get files in EXTERNAL TEMPLATES - Mitigation
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }
                }
            }

            // If investigation is checked then add all filed and folders respectively
            if (PhaseI.Checked)
            {
                if (System.IO.Directory.Exists(investPath))
                {
                    // Get files in INVESTIGATION TEMPLATES
                    getFiles = System.IO.Directory.GetFiles(investPath);

                    targetPath = saveDirectory;
                    targetPath = targetPath + @"\INVESTIGATION";
                    returnTargetPath = targetPath;

                    // Get files in INVESTIGATION TEMPLATES
                    getFiles = System.IO.Directory.GetFiles(investPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }

                    //C:\Users\Veteran\Desktop\WebApplication1\WebApplication1\INVESTIGATION TEMPLATES\INTERNAL TEMPLATES - Investigation
                    tempPath = investPath + @"\INTERNAL";
                    targetPath = targetPath + @"\INTERNAL";

                    // Keep track of previous path to return
                    previousPath = tempPath;
                    previousTargetPath = targetPath;

                    // Get files in INVESTIGATION TEMPLATES
                    getFiles = System.IO.Directory.GetFiles(tempPath);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }
                }

                if (System.IO.Directory.Exists(privateInvestPath))
                {
                    // Get files in INVESTIGATION TEMPLATES
                    getFiles = System.IO.Directory.GetFiles(privateInvestPath);

                    targetPath = saveDirectory;
                    targetPath = targetPath + @"\PRIVATE INVESTIGATION FILES";
                    returnTargetPath = targetPath;

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    foreach (string f in getFiles)
                    {
                        splitName = f.Split('\\');
                        fileName = splitName[splitName.Length - 1];
                        oldName = fileName;
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(f, destFile, true);
                        var changeName = new StringBuilder(oldName);
                        if (oldName.Contains("TML - "))
                        {
                            changeName.Remove(0, 5);       //TML - (5)
                        }
                        else if (oldName.Contains("TML- DRAFT"))
                        {
                            changeName.Remove(0, 12);       //TML- DRAFT -  (12)
                        }

                        // Takes care of files without TML name
                        changeName.Insert(0, rename);
                        newName = changeName.ToString();

                        splitName = newName.Split(' ');
                        splitName[splitName.Length - 1] = date;

                        newName = string.Join(" ", splitName);
                        splitName = oldName.Split('.');

                        newName = newName + '.' + splitName[splitName.Length - 1];

                        Directory.Move(targetPath + @"\" + oldName, targetPath + @"\" + newName);

                        if (newName.Contains(".docx"))
                        {
                            AutoFillTemplate(newName, targetPath);
                        }
                    }
                }
            }
        }

        private void AutoFillTemplate(string fileName, string targetPath)
        {
            string date = DateTime.Today.ToString();
            var splitName = date.Split(' ');
            date = splitName[0];
            string docText = "";

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(targetPath + @"\" + fileName, true))
            {
                docText = null;

                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                //Regex regexText = new Regex("");

                if (docText.Contains("@Date@"))
                {
                    Regex regexText = new Regex("@Date@");
                    docText = regexText.Replace(docText, date);
                }

                if ((docText.Contains("@ClientName@")) || (docText.Contains("@ClientName:@")))
                {
                    Regex regexText = new Regex("@ClientName@");
                    docText = regexText.Replace(docText, ClientName.Text);
                    Regex regexText2 = new Regex("@ClientName:@");
                    docText = regexText2.Replace(docText, "Client Name: " + ClientName.Text);
                }

                if (docText.Contains("@Client@"))
                {
                    Regex regexText = new Regex("@Client@");
                    docText = regexText.Replace(docText, ClientName.Text);
                }

                if ((docText.Contains("@Name@")) || (docText.Contains("@Name:@")))
                {
                    Regex regexText = new Regex("@Name@");
                    docText = regexText.Replace(docText, ClientName.Text);
                    Regex regexText2 = new Regex("@Name:@");
                    docText = regexText2.Replace(docText, "Name: " + ClientName.Text);
                }

                if (docText.Contains("@Doe@"))
                {
                    Regex regexText = new Regex("@Doe@");
                    docText = regexText.Replace(docText, lastName);
                }

                if (docText.Contains("@Does@"))
                {
                    Regex regexText = new Regex("@Does@");
                    docText = regexText.Replace(docText, lastName + "'s");
                }

                if (docText.Contains("@CaseNumber@"))
                {
                    Regex regexText = new Regex("@CaseNumber@");
                    docText = regexText.Replace(docText, CaseNumber.Text);
                }

                if (docText.Contains("@CaseNumber:@"))
                {
                    Regex regexText = new Regex("@CaseNumber:@");
                    docText = regexText.Replace(docText, " Case Number: " + CaseNumber.Text);
                }

                if (docText.Contains("@Case:@"))
                {
                    Regex regexText = new Regex("@Case:@");
                    docText = regexText.Replace(docText, "Case: " + ClientName.Text);
                }

                if (docText.Contains("@ClientLastName@"))
                {
                    Regex regexText = new Regex("@ClientLastName@");
                    docText = regexText.Replace(docText, lastName);
                }


                if (BookingNumber.Text != "")
                {
                    if (docText.Contains("@BookingNumber@"))
                    {
                        Regex regexText = new Regex("@BookingNumber@");
                        docText = regexText.Replace(docText, BookingNumber.Text);
                    }
                }

                if (LeadCounsel.Text != "")
                {
                    if ((docText.Contains("@LeadName@")) || (docText.Contains("@LeadCounsel@")) || (docText.Contains("@LeadCounsel:@")))
                    {
                        Regex regexText = new Regex("@LeadName@");
                        docText = regexText.Replace(docText, LeadCounsel.Text);
                        Regex regexText2 = new Regex("@LeadCounsel@");
                        docText = regexText2.Replace(docText, LeadCounsel.Text);
                        Regex regexText3 = new Regex("@LeadCounsel:@");
                        docText = regexText3.Replace(docText, "Lead Counsel: " + LeadCounsel.Text);
                    }
                }

                if (SecondChairCounsel.Text != "")
                {
                    if ((docText.Contains("@SecChairName@")) || (docText.Contains("@SecChairCounsel:@")))
                    {
                        Regex regexText = new Regex("@SecChairName@");
                        docText = regexText.Replace(docText, SecondChairCounsel.Text);
                        Regex regexText2 = new Regex("@SecChairCounsel:@");
                        docText = regexText2.Replace(docText, "Second Chair Counsel: " + SecondChairCounsel.Text);
                    }
                }

                if (docText.Contains("@Doe, J.@"))
                {
                    Regex regexText = new Regex("@Doe, J.@");
                    docText = regexText.Replace(docText, rename);
                }


                if (FacilityName.Text != "")
                {
                    if (docText.Contains("@FacilityName@"))
                    {
                        Regex regexText = new Regex("@FacilityName@");
                        docText = regexText.Replace(docText, FacilityName.Text);
                    }
                }

                if (PhysicalAddress.Text != "")
                {
                    if (docText.Contains("@StreetAddress@"))
                    {
                        Regex regexText = new Regex("@StreetAddress@");
                        docText = regexText.Replace(docText, PhysicalAddress.Text);
                    }
                    if (docText.Contains("@City,ST,Zip@"))
                    {
                        Regex regexText = new Regex("@City,ST,Zip@");
                        docText = regexText.Replace(docText, "");
                    }
                }

                if (JudgeName.Text != "")
                {
                    if (docText.Contains("@JudgeName@"))
                    {
                        Regex regexText = new Regex("@JudgeName@");
                        docText = regexText.Replace(docText, JudgeName.Text);
                    }
                }

                if (StateAttorney2Phone.Text != "")
                {
                    if (docText.Contains("@Attorney2Phone@"))
                    {
                        Regex regexText = new Regex("@Attorney2Phone@");
                        docText = regexText.Replace(docText, StateAttorney2Phone.Text);
                    }
                }

                if (StateAttorney2Email.Text != "")
                {
                    if (docText.Contains("@Attorney2Email@"))
                    {
                        Regex regexText = new Regex("@Attorney2Email@");
                        docText = regexText.Replace(docText, StateAttorney2Email.Text);
                    }
                }

                if (StateAttorney2Name.Text != "")
                {
                    if (docText.Contains("@Attorney2Name@"))
                    {
                        Regex regexText = new Regex("@Attorney2Name@");
                        docText = regexText.Replace(docText, StateAttorney2Name.Text);
                    }
                }

                if (StateAttorney2LawOffice.Text != "")
                {
                    if (docText.Contains("@Attorney2LawOffice@"))
                    {
                        Regex regexText = new Regex("@Attorney2LawOffice@");
                        docText = regexText.Replace(docText, StateAttorney2LawOffice.Text);
                    }
                }

                if (StateAttorney1Name.Text != "")
                {
                    if (docText.Contains("@Attorney1Name@"))
                    {
                        Regex regexText = new Regex("@Attorney2LawOffice@");
                        docText = regexText.Replace(docText, StateAttorney1Name.Text);
                    }
                }

                if (StateAttorney1LawOffice.Text != "")
                {
                    if (docText.Contains("@Attorney1LawOffice@"))
                    {
                        Regex regexText = new Regex("@Attorney1LawOffice@");
                        docText = regexText.Replace(docText, StateAttorney1LawOffice.Text);
                    }
                }

                if (StateAttorney1Phone.Text != "")
                {
                    if (docText.Contains("@Attorney1Phone@"))
                    {
                        Regex regexText = new Regex("@Attorney1Phone@");
                        docText = regexText.Replace(docText, StateAttorney1Phone.Text);
                    }
                }

                if (StateAttorney1Email.Text != "")
                {
                    if (docText.Contains("@Attorney1Email@"))
                    {
                        Regex regexText = new Regex("@Attorney1Email@");
                        docText = regexText.Replace(docText, StateAttorney1Email.Text);
                    }
                }

                if (ClientDOB != null)
                {
                    Regex regexText = new Regex("@00/00/0000@");
                    docText = regexText.Replace(docText, ClientDOB.Text);
                }

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}