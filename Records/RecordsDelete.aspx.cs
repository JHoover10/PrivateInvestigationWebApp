using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class RecordsDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [CaseNumber], [RecordRequested], [RecordSubCat], [RecordInfo], [RecordRelationship], [RecordStatus], [RecordNotes], [LinkToRecord], [ReceiptStatus], [ReceiptNotes], [id] FROM [RecordLog] WHERE [CaseNumber] = '" + Session["Num"].ToString() + "'";
        }
    }
}