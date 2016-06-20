﻿using System;
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
                string server = "ZDT-CE683\\MARK"; // Note connects over port 1433 so you may need to add a firewall exception on this port
                string database = "RECM";
                string userId = "jvanniekerk";
                string password = "P@ssword";
                //return string.Format("Server={0};Database={1};User ID={2};Password={3}", server, database, userId, password); 
                return "Data Source=localhost;" +"Initial Catalog=Avior;" +"Integrated Security=SSPI;";
            }
        }

        public static string TableName
        {
            get
            {
                return "Mark";
            }
        }

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

        /*public static bool DataExists (string connection, string table , Date date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    String commandText = String.Format("select * from {0} where ", table);
                    SqlCommand cmd = new SqlCommand(commandText, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error trying to clear table '" + table + "': " + ex.Message, ex);
            }
        }*/

        /// <summary>
        /// This is used to convert the LINQ to SQL table classes to DataTables. The code is from Mary Hamlin's solution to this question:
        /// http://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable/5805044#5805044
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
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
