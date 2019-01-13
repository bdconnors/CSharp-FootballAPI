using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FootballAPI.DataLayer.Util
{

    public class Database
    {
        //String used to connect to MySQL Database
        private string connString;
        //Connection object
        private static MySqlConnection conn = null;
        //Transaction object
        private static MySqlTransaction trans = null;
        public Database(string fileName)
        {
            this.connString = LoadConnString(fileName);

        }
        public Database()
        {
            this.connString = LoadConnString("connString.txt");

        }
        /// <summary>
        /// Opens connection to MySQL database via connection object
        /// </summary>
        /// <returns>True if connection is successful or false if connection fails</returns>        
        public bool Connect()
        {
            bool status = false;
            try
            {
                if (conn == null || trans == null)
                {
                    conn = new MySqlConnection(connString);
                    conn.Open();
                }
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                throw new Exception(e.StackTrace);
            }
            return status;
        }
        /// <summary>
        /// Closes connection MySQL database via connection object
        /// </summary>
        /// <returns>True if connection closes or false if connection close fails</returns>
        public bool Close()
        {
            bool status = false;
            try
            {
                if (conn != null && trans == null)
                {
                    MySqlConnection.ClearPool(conn);
                    conn.Close();
                    conn.Dispose();
                    conn = null;             
                }
                status = true;
            }catch (MySqlException e)
            {
                status = false;
                throw new Exception(e.Message, e);
            }
            return status;
        }
        /// <summary>
        /// Begins transaction 
        /// </summary>
        public void StartTransaction()
        {
            try
            {    
                Connect();
                if (conn != null && trans == null)
                {
                    trans = conn.BeginTransaction();
                }

            }catch(MySqlException e)
            {
                throw new Exception(e.Message, e);
            }
        }
        /// <summary>
        /// Ends transaction
        /// </summary>
        public void EndTransaction()
        {
            try
            {
                if (conn != null && trans != null)
                {
                    trans.Commit();
                    trans.Dispose();
                    trans = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

        }
        /// <summary>
        /// Rollback transaction
        /// </summary>
        public void RollbackTransaction()
        {
            trans.Rollback();
            trans.Dispose();
            trans = null;
        }
        /// <summary>
        /// Gets data from the database with a SQL query statement
        /// </summary>
        /// <param name="sql">contains SQL query statement</param>
        /// <param name="values">contains bind values for SQL query statement</param>
        /// <returns>List<String[]> containing rows of data from the database</returns>
        public List<string[]> SelectStmt(string sql,Dictionary<string,string> values)
        {
            List<string[]> data = new List<string[]>();
            try
            {
                Connect();
                MySqlCommand stmt = Prepare(sql, values);
                MySqlDataReader rdr = stmt.ExecuteReader();
                while (rdr.Read())
                {
                    string[] row = new string[rdr.FieldCount];
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        row[i] = rdr.GetValue(i).ToString();
                    }
                    data.Add(row);
                }
                Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return data;
        }
        /// <summary>
        /// Sets data in the database with a INSERT,UPDATE or DELETE statement
        /// </summary>
        /// <param name="sql">contains non-query SQL Statement</param>
        /// <param name="values">contains bind values for non-query SQL statement</param>
        /// <returns></returns>
        public int UpdateStmt(string sql,Dictionary<string,string> values)
        {
            int effected = 0;
            try
            {
                Connect();      
                effected = ExecuteStmt(sql, values);
                Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
        /// <summary>
        /// Creates a prepared statement
        /// </summary>
        /// <param name="sql">contains SQL statement</param>
        /// <param name="values">contains bind values for SQL statement</param>
        /// <returns>MySqlCommand containing the prepared statement</returns>
        public MySqlCommand Prepare(string sql,Dictionary<string,string> values)
        {
            MySqlCommand stmt = null;
            try
            {
                stmt = new MySqlCommand(sql, conn);
                if (values != null)
                {
                    MySqlParameter param = null;
                    foreach (KeyValuePair<string, string> value in values)
                    {
                        param = new MySqlParameter(value.Key, value.Value);
                        stmt.Parameters.Add(param);
                    }
                    stmt.Prepare();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return stmt;
        }
        /// <summary>
        /// Creates and executes a Non-Query SQL statement
        /// </summary>
        /// <param name="sql">contains non-query SQL statement</param>
        /// <param name="values">contains bind values for non-query SQL statement</param>
        /// <returns>Number of rows effected in the database</returns>
        public int ExecuteStmt(string sql, Dictionary<string, string> values)
        {
            MySqlCommand stmt = null;
            int effected = 0;
            try
            {
                stmt = Prepare(sql, values);
                effected = stmt.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
        public List<string[]>SelectProc(string procName,Dictionary<string,string> inParams)
        {
            List<string[]> result = new List<string[]>();
            try
            {
                Connect();
                MySqlCommand cmd = new MySqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (inParams != null)
                {
                    PrepareParams(cmd, inParams);
                }
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] row = new string[rdr.FieldCount];
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        row[i] = rdr.GetValue(i).ToString();
                    }
                    result.Add(row);
                }
                Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return result;     
        }
        public int UpdateProc(string procName,Dictionary<string,string> inParams)
        {        
            int effected = 0;
            try
            {
                Connect();
                MySqlCommand cmd = new MySqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (inParams != null)
                {
                    PrepareParams(cmd, inParams);
                }
                effected = cmd.ExecuteNonQuery();
                Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
        public MySqlCommand PrepareParams(MySqlCommand cmd,Dictionary<string, string> cmdParams)
        {
            foreach (KeyValuePair<string, string> param in cmdParams)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }
            return cmd;
        }
        /// <summary>
        /// Reads Connection String from .txt file and returns it as a string
        /// </summary>
        /// <param name="file">The Location path of the .txt file</param>
        public string LoadConnString(string fileName)
        {
            string cString = null;
            string path = HttpRuntime.AppDomainAppPath + @"DataLayer\Resources\"+fileName;
            try
            {             
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream))
                {
                    cString = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return cString;
        }

    }
}
