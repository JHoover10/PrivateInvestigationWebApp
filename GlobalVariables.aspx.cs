using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class GlobalVariables : System.Web.UI.Page
    {
        public static string caseNumber { get; set; }
        public static string clientName { get; set; }
        public static string witnessName { get; set; }
        public static bool fromCasePage { get; set; }
        public static string idNumber { get; set; }
    }
}