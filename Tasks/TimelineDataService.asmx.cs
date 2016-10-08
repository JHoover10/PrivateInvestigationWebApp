using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Services
{
    /// <summary>
    /// Summary description for TimelineDataService
    /// </summary>
    ///  [WebService(Namespace = "http://tempuri.org/")]
    /// [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    /// [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TimelineDataService : System.Web.Services.WebService
    {
        public class TaskNode
        {
            public string Task { get; set; }   // Task Description
            public string email { get; set; }  // email 
            public double Date_Completed { get; set; } // Date task is completed
            //public double Hours { get; set; }
        }

        public class EventNode
        {
            public string Header { get; set; } 
            public string Description { get; set; }  
            public double Event_Date { get; set; } // Date of event
            //public double Hours { get; set; }
        }

        [WebMethod]
        public List<TaskNode> FetchTask(List<string> tlData)
        {
            List<TaskNode> tasks = new List<TaskNode>();

            //DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Task, Email, Date_Completed from TASKS where CaseNum = @num and ClientName = @name" ;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@num", tlData[1]);
                cmd.Parameters.AddWithValue("@name", tlData[0]);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string task = dr["Task"].ToString();
                        string email = dr["Email"].ToString();
                        DateTime completed = Convert.ToDateTime(dr["Date_Completed"].ToString());

                        tasks.Add(new TaskNode
                        {
                            Task = task,
                            email = email,
                            Date_Completed = completed.ToUniversalTime().Subtract(new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc)).TotalMilliseconds
                        });
      
                    }
                }
            }

            return tasks;
        }

        [WebMethod]
        public List<EventNode> FetchStory(List<string> tlData)
        {
            List<EventNode> events = new List<EventNode>();

            //DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Event, Description, Date from CaseStory where CaseNumber = @num and ClientName = @name";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@num", tlData[1]);
                cmd.Parameters.AddWithValue("@name", tlData[0]);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string header = dr["Event"].ToString();
                        string description = dr["Description"].ToString();
                        DateTime event_date = Convert.ToDateTime(dr["Date"].ToString());
                        
                        events.Add(new EventNode
                        {
                            Header = header,
                            Description = description,
                            Event_Date = event_date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds
                        });

                    }
                }
            }
            return events;
        }
    }
}
