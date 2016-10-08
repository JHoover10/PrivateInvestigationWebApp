using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WitnessDownloadSelected : System.Web.UI.Page
    {
        public string[] filesW = null;
        public string[] filesR = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string fileName = "";
                string path = Server.MapPath(@"~\Cases\Cases Library\" + Session["Num"].ToString() + " - " + Session["Name"].ToString() + @"\WitnessFiles\" + GlobalVariables.idNumber);
                DirectoryInfo dInfo = new DirectoryInfo(path);
                filesW = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                foreach (string file in filesW)
                {
                    var splitName = file.Split('\\');
                    fileName = splitName[splitName.Length - 1];
                    WitnessFilesList.Items.Add(fileName);
                }

                path = Server.MapPath(@"~\Cases\Cases Library\" + Session["Num"].ToString() + " - " + Session["Name"].ToString() + @"\RecordsFiles\" + GlobalVariables.idNumber);
                dInfo = new DirectoryInfo(path);
                filesR = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                foreach (string file in filesR)
                {
                    var splitName = file.Split('\\');
                    fileName = splitName[splitName.Length - 1];
                    RecordsFilesList.Items.Add(fileName);
                }
            }
        }

        protected void Download(object sender, EventArgs e)
        {
            // DOWNLOAD FILES AS ZIP
            //string tempPath = "";
            Response.Clear();
            Response.BufferOutput = false;  // for large files
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "filename=" + Session["Num"].ToString() + " - " + Session["Name"].ToString() + ".zip");

            string wpath = Server.MapPath(@"~\Cases\Cases Library\" + Session["Num"].ToString() + " - " + Session["Name"].ToString() + @"\WitnessFiles\" + GlobalVariables.idNumber);
            string rpath = Server.MapPath(@"~\Cases\Cases Library\" + Session["Num"].ToString() + " - " + Session["Name"].ToString() + @"\RecordsFiles\" + GlobalVariables.idNumber);
            DirectoryInfo dInfoW = new DirectoryInfo(wpath);
            filesW = Directory.GetFiles(wpath, "*.*", SearchOption.AllDirectories);
            DirectoryInfo dInfoR = new DirectoryInfo(rpath);
            filesR = Directory.GetFiles(rpath, "*.*", SearchOption.AllDirectories);

            using (ZipFile zip = new ZipFile())
            {
                for (int i = 0; i < WitnessFilesList.Items.Count; ++i)
                {
                    if (WitnessFilesList.Items[i].Selected || WitnessFilesSA.Checked)
                    {
                        zip.AddFile(filesW[i], Session["Num"].ToString() + " - " + Session["Name"].ToString());
                    }
                }

                for (int i = 0; i < RecordsFilesList.Items.Count; ++i)
                {
                    if (RecordsFilesList.Items[i].Selected || RecordsFilesSA.Checked)
                    {
                        zip.AddFile(filesR[i], Session["Num"].ToString() + " - " + Session["Name"].ToString());
                    }
                }

                zip.Save(Response.OutputStream);
            }
        }
    }
}