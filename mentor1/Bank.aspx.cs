using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using mentor1.DataAccess;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.IO;

namespace mentor1
{
    public partial class Bank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int POid = Convert.ToInt32(TextBox1.Text);
            string ProcessDate = string.Format("{0:yyyy-MM-dd}", TextBox2.Text);
            string query= "select * from Details where poid=" + POid + " and " + "ProcessDate='" + ProcessDate + "'";           
            string path = @"D:\Diksha\mentor1\mentor1\SaveData\" + POid + "_" + ProcessDate + ".txt";
            ToGetData toGetData = new ToGetData();
            DataTable dt = toGetData.Getting_Data(query);
            int count=dt.Rows.Count;
            XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("./Xml/Data.xml"));
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!File.Exists(path))
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        StreamWriter sw = new StreamWriter(path, true);
                        string line = doc.Descendants("header").FirstOrDefault().Element("constant").Value + " ";
                        line += toGetData.LJZF(dr["BatchNo"].ToString(), Convert.ToInt32(doc.Descendants("header").FirstOrDefault().Element("batchno").Value)) + " ";
                        line += toGetData.checkDate(dr["ProcessDate"].ToString(), doc.Descendants("header").FirstOrDefault().Element("processData").Value) + " ";
                        line += Environment.NewLine;

                        line += doc.Descendants("detail").FirstOrDefault().Element("constant").Value + " ";
                        line += toGetData.LJZF(dr["AccountNo"].ToString(), Convert.ToInt32(doc.Descendants("AccountNumber").FirstOrDefault().Element("RJZF").Value)) + " ";
                        line += toGetData.decimalconversion(dr["Amount"].ToString(),Convert.ToInt32(doc.Descendants("amount").FirstOrDefault().Element("decimal").Value),Convert.ToInt32(doc.Descendants("amount").FirstOrDefault().Element("RJZF").Value)) + " ";
                        line += Environment.NewLine;

                        line += doc.Descendants("trailer").FirstOrDefault().Element("constant").Value + " ";
                        line += toGetData.LJZF(count.ToString(), Convert.ToInt32(doc.Descendants("trailer").FirstOrDefault().Element("BatchCount").Value)) + " ";
                        sw.WriteLine(line);
                        sw.Close();
                    }
                }
                else
                {
                    StreamWriter sw = new StreamWriter(path);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string line = doc.Descendants("header").FirstOrDefault().Element("constant").Value + " ";
                        line += toGetData.LJZF(dr["BatchNo"].ToString(), Convert.ToInt32(doc.Descendants("header").FirstOrDefault().Element("batchno").Value)) + " ";
                        line += toGetData.checkDate(dr["ProcessDate"].ToString(), doc.Descendants("header").FirstOrDefault().Element("processData").Value) + " ";
                        line += Environment.NewLine;

                        line += doc.Descendants("detail").FirstOrDefault().Element("constant").Value + " ";
                        line += toGetData.LJZF(dr["AccountNo"].ToString(), Convert.ToInt32(doc.Descendants("AccountNumber").FirstOrDefault().Element("RJZF").Value)) + " ";
                        line += toGetData.decimalconversion(dr["Amount"].ToString(), Convert.ToInt32(doc.Descendants("amount").FirstOrDefault().Element("decimal").Value), Convert.ToInt32(doc.Descendants("amount").FirstOrDefault().Element("RJZF").Value)) + " ";
                        line += Environment.NewLine;

                        line += doc.Descendants("trailer").FirstOrDefault().Element("constant").Value + " ";
                        line += toGetData.LJZF(count.ToString(), Convert.ToInt32(doc.Descendants("trailer").FirstOrDefault().Element("BatchCount").Value)) + " ";
                        line += Environment.NewLine;
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
            }
            else
            {
                Response.Write("Please Check the data you have entered");
            }
        }
    }
}

            
          