using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AviorInterviewProject
{
    public static class FileProcessor
    {
        public static String Directory = "C:\\Proj\\Example Files\\";

        public static int FilesProcessed = 0;
        public static int FilesToProcess = 0;

        public static bool IsLoaded(String filename)
        {
            return false;
        }

        public static void ProcessFile(String filename)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TradeDate", typeof(DateTime));
            dt.Columns.Add("TradeTime", typeof(TimeSpan)); //DAN TO DO: Check datatype here...
            dt.Columns.Add("Ticker", typeof(string));
            dt.Columns.Add("Expiry", typeof(DateTime));
            dt.Columns.Add("InstrumentType", typeof(string));
            dt.Columns.Add("Strike", typeof(decimal));
            dt.Columns.Add("Volatility", typeof(decimal));
            dt.Columns.Add("Premium", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Status", typeof(string));

            string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", filename);
            
            try
            {
                DataSet data = new DataSet();
                using (System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(connectionString))
                {
                    con.Open();
                    var dtSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    String Sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                    string query = string.Format("SELECT TradeDate,	Contract,	Expiry,	Quantity,	Strike,	CallPut,	Spot,	Price,	Rate,	Origin FROM[{0}]", Sheet1);
                    System.Data.OleDb.OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(data);
                }

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();

                    if (row[0].GetType() == typeof(DateTime))
                    {
                        dr["TradeDate"] = Convert.ToDateTime(row[0]).Date;
                        dr["TradeTime"] = Convert.ToDateTime(row[0]).TimeOfDay;
                        dr["Ticker"] = row[1].ToString();
                        dr["Expiry"] = Convert.ToDateTime(row[2]).Date;
                        dr["InstrumentType"] = row[5].ToString();
                        dr["Strike"] = (row[4] is DBNull) ? 0 : double.Parse(row[4].ToString(),System.Globalization.NumberStyles.Currency);
                        dr["Volatility"] = (row[8] is DBNull) ? 0 : Convert.ToDecimal(row[8]);
                        dr["Premium"] = (row[7] is DBNull) ? 0 : Convert.ToDecimal(row[7]);
                        dr["Quantity"] = (row[3] is DBNull) ? 0 : Convert.ToDecimal(row[3]);
                        dr["Status"] = row[9].ToString();
                        dt.Rows.Add(dr);
                    }
                }

                DBAccess.BulkInsert(DBAccess.ConnectionString, DBAccess.TableName, dt);

                FileProcessor.FilesProcessed++;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }       

        }
    }   
}
