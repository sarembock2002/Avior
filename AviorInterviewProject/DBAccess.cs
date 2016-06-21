using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviorInterviewProject
{
    public static class DBAccess
    {

        public static string ConnectionString
        {
            get
            {
                string server = "avior-mssql-1.cgfvn3vetizv.eu-west-1.rds.amazonaws.com"; // Note connects over port 1433 so you may need to add a firewall exception on this port
                string database = "Interviewee";
                string userId = "Mark";
                string password = "M@rk";
                return string.Format("Server={0};Database={1};User ID={2};Password={3}", server, database, userId, password);
            }
        }

        public static string TableName
        {
            get
            {
                return "Mark";
            }
        }


        //Clear DB
        public static void ClearDBTable(string connection, string table)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    String commandText = String.Format("delete from {0}", table);
                    SqlCommand cmd = new SqlCommand(commandText,con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error trying to clear table '" + table + "': " + ex.Message, ex);
            }
        }

        public static void BulkInsert(string connection, string table, DataTable dt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable))
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tr))
                        {
                            bulkCopy.DestinationTableName = table;
                            bulkCopy.WriteToServer(dt);
                        }
                        tr.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error trying to bulk insert to table '" + table + "': " + ex.Message, ex);
            }
        }

        //Check if Data exists for a given day
        public static bool DataExists (string connection, string table , String date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    String sqlDate = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
                    con.Open();
                    String commandText = String.Format("select * from {0} where TradeDate = '{1}'", table, sqlDate);
                    SqlCommand cmd = new SqlCommand(commandText, con);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows) return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error trying to check if there is data '" + table + "': " + ex.Message, ex);
            }
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in props)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in props)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    if (row[prop.Name].ToString() == string.Empty)
                    {
                        row[prop.Name] = DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
