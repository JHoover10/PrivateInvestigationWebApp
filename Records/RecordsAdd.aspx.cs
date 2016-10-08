using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WebApplication1
{
    public partial class RecordsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RecordRequested.Items.Add("");
                RecordRequested.Items.Add("Arresting Agency");
                RecordRequested.Items.Add("Background Check");
                RecordRequested.Items.Add("Calls for Service");
                RecordRequested.Items.Add("Clerk of the court");
                RecordRequested.Items.Add("Defense attorney");
                RecordRequested.Items.Add("Economic assistence");
                RecordRequested.Items.Add("Education");
                RecordRequested.Items.Add("Employment");
                RecordRequested.Items.Add("Expert Report");
                RecordRequested.Items.Add("Faith/Community");
                RecordRequested.Items.Add("Government Social Service");
                RecordRequested.Items.Add("Immigration/Naturalization Service");
                RecordRequested.Items.Add("Jail/DOC");
                RecordRequested.Items.Add("Media/Social Network");
                RecordRequested.Items.Add("Medical/Physchological/Treatment");
                RecordRequested.Items.Add("Military Service");
                RecordRequested.Items.Add("Probation/Parole");
                RecordRequested.Items.Add("Social Security");
                RecordRequested.Items.Add("State/Federal Prosecution");
                RecordRequested.Items.Add("Youth Development Program");
                RecordRequested.Items.Add("Other (see notes)");

                RecordSubCat.Items.Add("");

                RecordRelationship.Items.Add("");
                RecordRelationship.Items.Add("Biological Brother");
                RecordRelationship.Items.Add("Biological Sister");
                RecordRelationship.Items.Add("Client");
                RecordRelationship.Items.Add("Coach");
                RecordRelationship.Items.Add("Co-defendant");
                RecordRelationship.Items.Add("Confidential Informant");
                RecordRelationship.Items.Add("Counselor");
                RecordRelationship.Items.Add("Defense Attorney");
                RecordRelationship.Items.Add("Detective/Officer");
                RecordRelationship.Items.Add("Expert");
                RecordRelationship.Items.Add("Eye Witness");
                RecordRelationship.Items.Add("Family Friend");
                RecordRelationship.Items.Add("Father");
                RecordRelationship.Items.Add("Informant");
                RecordRelationship.Items.Add("Maternal 1st Cousin");
                RecordRelationship.Items.Add("Maternal 2nd Cousin");
                RecordRelationship.Items.Add("Maternal 3rd Cousin");
                RecordRelationship.Items.Add("Maternal Aunt");
                RecordRelationship.Items.Add("Maternal Cousin");
                RecordRelationship.Items.Add("Maternal Grandaunt");
                RecordRelationship.Items.Add("Maternal Grandfather");
                RecordRelationship.Items.Add("Maternal Grandmother");
                RecordRelationship.Items.Add("Maternal Grandnephew");
                RecordRelationship.Items.Add("Maternal Grandnice");
                RecordRelationship.Items.Add("Maternal Granduncle");
                RecordRelationship.Items.Add("Maternal Half - Brother");
                RecordRelationship.Items.Add("Maternal Half - Sister");
                RecordRelationship.Items.Add("Maternal In-Law - Brother");
                RecordRelationship.Items.Add("Maternal In-Law - Sister");
                RecordRelationship.Items.Add("Maternal Step - Aunt");
                RecordRelationship.Items.Add("Maternal Step - Brother");
                RecordRelationship.Items.Add("Maternal Step - Sister");
                RecordRelationship.Items.Add("Maternal Step - Uncle");
                RecordRelationship.Items.Add("Maternal Uncle");
                RecordRelationship.Items.Add("Mother");
                RecordRelationship.Items.Add("Neighbor");
                RecordRelationship.Items.Add("Partner/Spouse");
                RecordRelationship.Items.Add("Paternal 1st Cousin");
                RecordRelationship.Items.Add("Paternal 2nd Cousin");
                RecordRelationship.Items.Add("Paternal 3rd Cousin");
                RecordRelationship.Items.Add("Paternal Aunt");
                RecordRelationship.Items.Add("Paternal Cousin");
                RecordRelationship.Items.Add("Paternal Grandaunt");
                RecordRelationship.Items.Add("Paternal Grandfather");
                RecordRelationship.Items.Add("Paternal Grandmother");
                RecordRelationship.Items.Add("Paternal Grandnephew");
                RecordRelationship.Items.Add("Paternal Grandnice");
                RecordRelationship.Items.Add("Paternal Granduncle");
                RecordRelationship.Items.Add("Paternal Half - Brother");
                RecordRelationship.Items.Add("Paternal Half - Sister");
                RecordRelationship.Items.Add("Paternal In-Law - Brother");
                RecordRelationship.Items.Add("Paternal In-Law - Sister");
                RecordRelationship.Items.Add("Paternal Step - Aunt");
                RecordRelationship.Items.Add("Paternal Step - Brother");
                RecordRelationship.Items.Add("Paternal Step - Sister");
                RecordRelationship.Items.Add("Paternal Step - Uncle");
                RecordRelationship.Items.Add("Paternal Uncle");
                RecordRelationship.Items.Add("Probation Officer");
                RecordRelationship.Items.Add("State Attorney");
                RecordRelationship.Items.Add("Step - Father");
                RecordRelationship.Items.Add("Step - Mother");
                RecordRelationship.Items.Add("Teacher");
                RecordRelationship.Items.Add("Victim");
                RecordRelationship.Items.Add("Witness");

                RecordStatus.Items.Add("");
                RecordStatus.Items.Add("Destroyed (see notes)");
                RecordStatus.Items.Add("No Records (see notes)");
                RecordStatus.Items.Add("Ordered");
                RecordStatus.Items.Add("Paid");
                RecordStatus.Items.Add("Pending");
                RecordStatus.Items.Add("Received");
                RecordStatus.Items.Add("Uploaded");
                RecordStatus.Items.Add("Other (see notes)");

                ReceiptStatus.Items.Add("");
                ReceiptStatus.Items.Add("No Record Fee");
                ReceiptStatus.Items.Add("Not Received");
                ReceiptStatus.Items.Add("Request Letter Sent");
                ReceiptStatus.Items.Add("Posted to Bill4Time");
                ReceiptStatus.Items.Add("Other (see notes)");
            }
        }

        protected void RecordRequested_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RecordRequested.SelectedValue.ToString() == "Arresting Agency")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("ATF");
                RecordSubCat.Items.Add("Border Patrol");
                RecordSubCat.Items.Add("Certified Judgement and Sentence");
                RecordSubCat.Items.Add("DEA");
                RecordSubCat.Items.Add("FBI");
                RecordSubCat.Items.Add("Highway Patrol");
                RecordSubCat.Items.Add("IRS");
                RecordSubCat.Items.Add("Land & Forest Managment");
                RecordSubCat.Items.Add("Ploice");
                RecordSubCat.Items.Add("Sheriff");
                RecordSubCat.Items.Add("State Law Enforcement");
                RecordSubCat.Items.Add("US Immigration & Customs");
                RecordSubCat.Items.Add("US Marshals");
                RecordSubCat.Items.Add("US Patrol Insepection Service");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Background Check")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Comprehensive");
                RecordSubCat.Items.Add("Criminal");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Calls for Service")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("911");
                RecordSubCat.Items.Add("EMT");
                RecordSubCat.Items.Add("Fire");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Clerk of the court")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Criminal");
                RecordSubCat.Items.Add("Drug Court");
                RecordSubCat.Items.Add("Evictions");
                RecordSubCat.Items.Add("Family Law");
                RecordSubCat.Items.Add("Felonies");
                RecordSubCat.Items.Add("General Civil");
                RecordSubCat.Items.Add("Infractions");
                RecordSubCat.Items.Add("Juvenile");
                RecordSubCat.Items.Add("Misdemeanor");
                RecordSubCat.Items.Add("Probate");
                RecordSubCat.Items.Add("Small Claims");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Defense attorney")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Private Attorneys");
                RecordSubCat.Items.Add("Public Defenders");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Economic assistence")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Assistance Thru Private Funds");
                RecordSubCat.Items.Add("Assistance Thru Public Funds");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Education")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Alternative School");
                RecordSubCat.Items.Add("College/Grad School");
                RecordSubCat.Items.Add("Elementary School");
                RecordSubCat.Items.Add("High School");
                RecordSubCat.Items.Add("Juvenile Justice");
                RecordSubCat.Items.Add("Licensing");
                RecordSubCat.Items.Add("Middle School");
                RecordSubCat.Items.Add("Preschool");
                RecordSubCat.Items.Add("Technical & Trade School");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Employment")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Employment");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Expert Report")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Accident Reconstruction & Safety");
                RecordSubCat.Items.Add("Agriculture & Animals");
                RecordSubCat.Items.Add("Appraisal & Valuation");
                RecordSubCat.Items.Add("Business");
                RecordSubCat.Items.Add("Financial & Marketing");
                RecordSubCat.Items.Add("Computers & Technology");
                RecordSubCat.Items.Add("Construction & Architecture");
                RecordSubCat.Items.Add("Documents & Handwriting");
                RecordSubCat.Items.Add("Employment & Vocational");
                RecordSubCat.Items.Add("Engineering Expert Witness");
                RecordSubCat.Items.Add("Family & Education");
                RecordSubCat.Items.Add("Forensic & Laboratory Testing");
                RecordSubCat.Items.Add("Hospitals & Medical Services");
                RecordSubCat.Items.Add("Hotel, Food & Restaurant");
                RecordSubCat.Items.Add("Insurance Expert Witness");
                RecordSubCat.Items.Add("Law & Legal");
                RecordSubCat.Items.Add("Medical Expert Witnesses");
                RecordSubCat.Items.Add("Police & Penal");
                RecordSubCat.Items.Add("Psychologists & Psychiatrists");
                RecordSubCat.Items.Add("Real Estate Expert Witness");
                RecordSubCat.Items.Add("Security Expert Witness");
                RecordSubCat.Items.Add("Transportation Expert Witness");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Faith/Community")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Church/Spiritual");
                RecordSubCat.Items.Add("Community");
                RecordSubCat.Items.Add("Volunteer");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Government Social Service")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Child Care/Child Support");
                RecordSubCat.Items.Add("Counsel/Counseling");
                RecordSubCat.Items.Add("DCF");
                RecordSubCat.Items.Add("Disaster Relief");
                RecordSubCat.Items.Add("Energy Assistance");
                RecordSubCat.Items.Add("Environmental Sustainability");
                RecordSubCat.Items.Add("Financial Assistance");
                RecordSubCat.Items.Add("Food Assistance");
                RecordSubCat.Items.Add("Foster Care");
                RecordSubCat.Items.Add("Grants/Scholarships");
                RecordSubCat.Items.Add("Healthcare");
                RecordSubCat.Items.Add("Housing");
                RecordSubCat.Items.Add("Insurance");
                RecordSubCat.Items.Add("Living Assistance");
                RecordSubCat.Items.Add("Loans");
                RecordSubCat.Items.Add("Tax Assistance");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Immigration/Naturalization Service")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Immigration");
                RecordSubCat.Items.Add("Naturalization");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Jail/DOC")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("DOC Classification");
                RecordSubCat.Items.Add("DOC Medical");
                RecordSubCat.Items.Add("Federal Classification");
                RecordSubCat.Items.Add("Jail Classification");
                RecordSubCat.Items.Add("Jail Medical");
                RecordSubCat.Items.Add("Juvenile");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Media/Social Network")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Media");
                RecordSubCat.Items.Add("Social Network Sites");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Medical/Physchological/Treatment")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Birth Certificate");
                RecordSubCat.Items.Add("Counseling");
                RecordSubCat.Items.Add("Death Certificate");
                RecordSubCat.Items.Add("Dentist");
                RecordSubCat.Items.Add("Doctors");
                RecordSubCat.Items.Add("Healthcare Clinics");
                RecordSubCat.Items.Add("HIV/AIDS");
                RecordSubCat.Items.Add("Hospital");
                RecordSubCat.Items.Add("Juvenile Dentention Centers");
                RecordSubCat.Items.Add("Lab Work");
                RecordSubCat.Items.Add("Medicare/Medicaid");
                RecordSubCat.Items.Add("Pharmacy");
                RecordSubCat.Items.Add("Prental");
                RecordSubCat.Items.Add("Psychological");
                RecordSubCat.Items.Add("Substance Abuse/Treatment");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Military Service")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Air Force");
                RecordSubCat.Items.Add("Army");
                RecordSubCat.Items.Add("Coast Guard");
                RecordSubCat.Items.Add("Marine Corp");
                RecordSubCat.Items.Add("Navy");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Probation/Parole")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Juvenile");
                RecordSubCat.Items.Add("Probation/Parole");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Social Security")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Disability");
                RecordSubCat.Items.Add("Social Security");
                RecordSubCat.Items.Add("Social Security Card");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "State/Federal Prosecution")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Federal Attorney");
                RecordSubCat.Items.Add("State Attorney");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else if (RecordRequested.SelectedValue.ToString() == "Youth Development Program")
            {
                RecordSubCat.Items.Clear();
                RecordSubCat.Items.Add("Youth Programs");
                RecordSubCat.Items.Add("Other (see notes)");
            }
            else
            {
                RecordSubCat.Items.Clear();
            }
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                SqlCommand com = new SqlCommand("INSERT INTO [RecordLog] ([CaseNumber], [RecordRequested], [RecordSubCat], [RecordInfo], [RecordRelationship], [RecordStatus], [RecordNotes], [LinkToRecord], [ReceiptStatus], [ReceiptNotes], [id]) VALUES (@CaseNumber, @RecordRequested, @RecordSubCat, @RecordInfo, @RecordRelationship, @RecordStatus, @RecordNotes, @LinkToRecord, @ReceiptStatus, @ReceiptNotes, @id)", con);

                try
                {
                    con.Open();

                    com.Parameters.AddWithValue("@CaseNumber", Session["Num"].ToString());
                    com.Parameters.AddWithValue("@RecordRequested", RecordRequested.Text);
                    com.Parameters.AddWithValue("@RecordSubCat", RecordSubCat.Text);
                    com.Parameters.AddWithValue("@RecordInfo", RecordInfo.Text);
                    com.Parameters.AddWithValue("@RecordRelationship", RecordRelationship.Text);
                    com.Parameters.AddWithValue("@RecordStatus", RecordStatus.Text);
                    com.Parameters.AddWithValue("@RecordNotes", RecordNotes.Text);
                    com.Parameters.AddWithValue("@LinkToRecord", LinkToRecord.Text);
                    com.Parameters.AddWithValue("@ReceiptStatus", ReceiptStatus.Text);
                    com.Parameters.AddWithValue("@ReceiptNotes", ReceiptNotes.Text);
                    com.Parameters.AddWithValue("@id", Guid.NewGuid());
                }
                finally
                {
                    com.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("~/Records/RecordsLog.aspx");
                }
            }
        }
    }
}