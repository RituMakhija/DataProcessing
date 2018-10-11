using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Globalization;

namespace mentor1.DataAccess
{
    public class ToGetData
    {
        public DataTable Getting_Data(string query)
        {
            //string query = "select * from Details where poid=" + poid + " and " + "ProcessDate='" + processDate + "'";
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();           
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            con.Close();
            return dt;                          
        }

        public string RJZF(string str,int totalLength)
        {
            return str.PadRight(totalLength, '0');
        }

        public string LJZF(string str, int totalLength)
        {
           
            return str.PadLeft(totalLength, '0');
        }

        public string decimalconversion(string str,int length,int max_size)
        {
            int totalLength = str.Length + length;
            string result = str.PadRight(totalLength, '0');
            string ans = String.Format("{0:0.00}", Convert.ToDecimal(result) / 100);
            return ans.PadLeft(max_size, '0');
            //string result = str.PadRight(totalLength, '0');
            //return String.Format("{0:0.00}", Convert.ToDecimal(result) /100000 ) ;
            //return str.PadRight(totalLength, '0');
        }

        public string checkDate(string processDate, string xmlDate)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateValue;          
            if(DateTime.TryParseExact(processDate, xmlDate, enUS, DateTimeStyles.None, out dateValue))
            {
                return processDate;
            }
            else
            {
                return "Error:";
            }
            
        }
    }
}