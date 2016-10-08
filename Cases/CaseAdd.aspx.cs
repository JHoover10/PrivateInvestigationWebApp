using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;

namespace WebApplication1
{
    public partial class CaseAdd : System.Web.UI.Page
    {
        public string imgPath = "";
        public string targetPath = "";
        byte[] img = null;
        int stateFL = 0;
        bool checkBoxStateFL, checkBoxUnited, phaseOne, phaseTwo, mit, invest;
        string rename, lastName;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Click_CaseInfoSave(object sender, EventArgs e)
        {
            imgPath = UploadImage.FileName;

            // Map to the specified folder path
            targetPath = Server.MapPath(@".\Cases Library") + @"\" + CaseNumber.Text + " - " + ClientName.Text;
            // HAVE QUINN SET THE TARGET PATH???

            // If folder does not exist then ceate a new one, else error
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            else
            {
                Response.Write("Error creating folder. That folder already exists");
            }

            // Save case info and output to text file
            SqlConnection vid = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                SqlCommand xp = new SqlCommand("INSERT INTO [CaseIntake] ([ClientName], [CaseNumber], [LeadCounsel], [SecondChairCounsel], " +
                    "[Charges], [FacilityName], [BookingNumber], [CellLocation], [FacilityPhone], [MailingAddress], [PhysicalAddress], [VisitationPolicy], " +
                    "[JudgeName], [CourtHouse], [JudgePhone], [JAEmail], [JudgeAddress], [StateAttorney1Name], [StateAttorney1Phone], [StateAttorney1Email], " +
                    "[StateAttorney1LawOffice], [StateParalegalName], [StateParalegalPhone], [StateParalegalEmail], [StateParalegalLawOffice], [StateAttorney2Name], " +
                    "[StateAttorney2Phone], [StateAttorney2Email], [StateAttorney2LawOffice], [DefenseLeadCounselName], [DefenseLeadCounselPhone], [DefenseLeadCounselEmail], " +
                    "[DefenseLeadCounselLawOffice], [DefenseParalegalName], [DefenseParalegalPhone], [DefenseParalegalEmail], [DefenseParalegalLawOffice], [DefenseSecondChairName], " +
                    "[DefenseSecondChairPhone], [DefenseSecondChairEmail], [DefenseSecondChairLawOffice], [ClientImage], [ClientDOB], [StateOfFloridaDD], [UnitedStatesDD], [CheckBoxState],"+
                    "[CheckBoxUS], [PhaseOneCB], [PhaseTwoCB], [Summary]) VALUES (@ClientName, @CaseNumber, @LeadCounsel, " +
                    "@SecondChairCounsel, @Charges, @FacilityName, @BookingNumber, @CellLocation, @FacilityPhone, @MailingAddress, @PhysicalAddress, @VisitationPolicy, @JudgeName, " +
                    "@CourtHouse, @JudgePhone, @JAEmail, @JudgeAddress, @StateAttorney1Name, @StateAttorney1Phone, @StateAttorney1Email, @StateAttorney1LawOffice, @StateParalegalName, " +
                    "@StateParalegalPhone, @StateParalegalEmail, @StateParalegalLawOffice, @StateAttorney2Name, @StateAttorney2Phone, @StateAttorney2Email, @StateAttorney2LawOffice, " +
                    "@DefenseLeadCounselName, @DefenseLeadCounselPhone, @DefenseLeadCounselEmail, @DefenseLeadCounselLawOffice, @DefenseParalegalName, @DefenseParalegalPhone, " +
                    "@DefenseParalegalEmail, @DefenseParalegalLawOffice, @DefenseSecondChairName, @DefenseSecondChairPhone, @DefenseSecondChairEmail, @DefenseSecondChairLawOffice, @ClientImage, @ClientDOB," +
                    "@StateOfFloridaDD, @UnitedStatesDD, @CheckBoxState, @CheckBoxUS, @PhaseOneCB, @PhaseTwoCB, @Summary)", vid);

                xp.Parameters.AddWithValue("@ClientName", ClientName.Text);
                xp.Parameters.AddWithValue("@CaseNumber", CaseNumber.Text);
                xp.Parameters.AddWithValue("@LeadCounsel", LeadCounsel.Text);
                xp.Parameters.AddWithValue("@SecondChairCounsel", SecondChairCounsel.Text);
                xp.Parameters.AddWithValue("@Charges", Charges.Text);
                xp.Parameters.AddWithValue("@FacilityName", FacilityName.Text);
                xp.Parameters.AddWithValue("@BookingNumber", BookingNumber.Text);
                xp.Parameters.AddWithValue("@CellLocation", CellLocation.Text);
                xp.Parameters.AddWithValue("@FacilityPhone", FacilityPhone.Text);
                xp.Parameters.AddWithValue("@MailingAddress", MailingAddress.Text);
                xp.Parameters.AddWithValue("@PhysicalAddress", PhysicalAddress.Text);
                xp.Parameters.AddWithValue("@VisitationPolicy", VisitingPolicy.Text);
                xp.Parameters.AddWithValue("@JudgeName", JudgeName.Text);
                xp.Parameters.AddWithValue("@CourtHouse", CourtHouse.Text);
                xp.Parameters.AddWithValue("@JudgePhone", JudgePhone.Text);
                xp.Parameters.AddWithValue("@JAEmail", JAEmail.Text);
                xp.Parameters.AddWithValue("@JudgeAddress", JudgeAddress.Text);
                xp.Parameters.AddWithValue("@StateAttorney1Name", StateAttorney1Name.Text);
                xp.Parameters.AddWithValue("@StateAttorney1Phone", StateAttorney1Phone.Text);
                xp.Parameters.AddWithValue("@StateAttorney1Email", StateAttorney1Email.Text);
                xp.Parameters.AddWithValue("@StateAttorney1LawOffice", StateAttorney1LawOffice.Text);
                xp.Parameters.AddWithValue("@StateParalegalName", StateParalegalName.Text);
                xp.Parameters.AddWithValue("@StateParalegalPhone", StateParalegalPhone.Text);
                xp.Parameters.AddWithValue("@StateParalegalEmail", StateParalegalEmail.Text);
                xp.Parameters.AddWithValue("@StateParalegalLawOffice", StateParalegalLawOffice.Text);
                xp.Parameters.AddWithValue("@StateAttorney2Name", StateAttorney2Name.Text);
                xp.Parameters.AddWithValue("@StateAttorney2Phone", StateAttorney2Phone.Text);
                xp.Parameters.AddWithValue("@StateAttorney2Email", StateAttorney2Email.Text);
                xp.Parameters.AddWithValue("@StateAttorney2LawOffice", StateAttorney2LawOffice.Text);
                xp.Parameters.AddWithValue("@DefenseLeadCounselName", DefenseLeadCounselName.Text);
                xp.Parameters.AddWithValue("@DefenseLeadCounselPhone", DefenseLeadCounselPhone.Text);
                xp.Parameters.AddWithValue("@DefenseLeadCounselEmail", DefenseLeadCounselEmail.Text);
                xp.Parameters.AddWithValue("@DefenseLeadCounselLawOffice", DefenseLeadCounselLawOffice.Text);
                xp.Parameters.AddWithValue("@DefenseParalegalName", DefenseParalegalName.Text);
                xp.Parameters.AddWithValue("@DefenseParalegalPhone", DefenseParalegalPhone.Text);
                xp.Parameters.AddWithValue("@DefenseParalegalEmail", DefenseParalegalEmail.Text);
                xp.Parameters.AddWithValue("@DefenseParalegalLawOffice", DefenseParalegalLawOffice.Text);
                xp.Parameters.AddWithValue("@DefenseSecondChairName", DefenseSecondChairName.Text);
                xp.Parameters.AddWithValue("@DefenseSecondChairPhone", DefenseSecondChairPhone.Text);
                xp.Parameters.AddWithValue("@DefenseSecondChairEmail", DefenseSecondChairEmail.Text);
                xp.Parameters.AddWithValue("@DefenseSecondChairLawOffice", DefenseSecondChairLawOffice.Text);
                xp.Parameters.AddWithValue("@StateOfFloridaDD", Circuit.SelectedIndex);
                xp.Parameters.AddWithValue("@UnitedStatesDD", District.SelectedIndex);
                xp.Parameters.AddWithValue("@CheckBoxState", StateOfFlorida.Checked);
                xp.Parameters.AddWithValue("@CheckBoxUS", US.Checked);
                xp.Parameters.AddWithValue("@PhaseOneCB", PhaseI.Checked);
                xp.Parameters.AddWithValue("@PhaseTwoCB", Phase2.Checked);
                xp.Parameters.AddWithValue("@ClientDOB", ClientDOB.Text);
                xp.Parameters.AddWithValue("@Summary", Summary.Text);

                if (imgPath != "")
                {
                    string saveLocation = targetPath + @"\" + imgPath;
                    UploadImage.PostedFile.SaveAs(saveLocation);
                    FileStream fs = new FileStream(saveLocation, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    img = new byte[fs.Length];
                    fs.Read(img, 0, Convert.ToInt32(fs.Length));
                }
                else
                {
                    string defaultImg = Server.MapPath("../UploadMedia") + "\\DefaultImage.png";
                    FileStream fs = new FileStream(defaultImg, FileMode.Open, FileAccess.Read);
                    img = new byte[fs.Length];
                    fs.Read(img, 0, Convert.ToInt32(fs.Length));
                }

                xp.Parameters.AddWithValue("@ClientImage", img);

                vid.Open();
                xp.ExecuteNonQuery();
                vid.Close();
            }

            CopyFiles();

            Response.Redirect("~/Cases/CasePage.aspx");
        }

        private void CopyFiles()
        {
            string mitPath = Server.MapPath(@"~\MITIGATION TEMPLATES");
            string investPath = Server.MapPath(@"~\INVESTIGATION TEMPLATES");
            string privateInvestPath = Server.MapPath(@"~\PRIVATE INVESTIGATION TEMPLATES");
            string oldName = "";
            string newName = "";
            string firstName = "";
            //string lastName = "";
            string date = "";
            string[] getFiles;
            string fileName, destFile;
            string tempPath, previousPath, previousTargetPath, returnTargetPath, saveDirectory;

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

                    targetPath = targetPath + @"\MITIGATION FILES";
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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
                        else if (newName.Contains(".xlsx"))
                        {
                            AutoFillExcel(newName, targetPath);
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

        private void AutoFillExcel(string fileName, string targetPath)
        {
            /*
            string curSheet = ;
            string date = DateTime.Today.ToString();
            var splitName = date.Split(' ');
            date = splitName[0];

            Excel.Application myExcelApp = new Excel.Application();
            Excel.Workbooks myExcelWBs;
            Excel.Workbook myExcelWB = myExcelApp.Workbooks.Open(targetPath);/*, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);*/
            /*
            Excel.Worksheets myExcelWSs;
            Excel.Sheets excelSheets = myExcelWB.Worksheets;
            
            Excel.Worksheet myExcelWS = new Excel.Worksheet();
            curSheet = myExcelWS.Name;
            myExcelWS = (Excel.Worksheet)myExcel.get_Item(curSheet);
            

            myExcelApp.Workbooks.Open(targetPath);

            Excel.Range excelCell = (Excel.Range)myExcelWS.get_Range("A1", "A1");
            */

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        //private void SaveCaseInfo()
        //{
        //    Response.Redirect("~/Cases/CasePage.aspx");
        //}

        //protected void Circuit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    stateFL = Circuit.SelectedIndex;
        //}

        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    US = DropDownList2.SelectedIndex;
        //}

        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    checkBoxStateFL = CheckBox1.Checked;
        //}

        //protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    checkBoxUnited = CheckBox2.Checked;
        //}

        //protected void Charges_TextChanged(object sender, EventArgs e)
        //{

        //}

        //protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    phaseOne = CheckBox3.Checked;
        //}

        //protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        //{
        //    phaseTwo = CheckBox4.Checked;
        //}
    }
}