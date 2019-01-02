using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAPI.Util
{

    class Database
    {
        //String used to connect to MySQL Database
        private string connString;
        //Connection object
        private static MySqlConnection conn = null;
        //Transaction object
        private static MySqlTransaction trans = null;
        public Database(string file)
        {
            connString = LoadConnString(file);
        }
        public Database()
        {
            this.connString = LoadConnString("connString.txt");

        }
        /// <summary>
        /// Opens connection to MySQL database via connection object
        /// </summary>
        /// <returns>True if connection is successful or false if connection fails</returns>        
        public Boolean Connect()
        {
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Closes connection MySQL database via connection object
        /// </summary>
        /// <returns>True if connection closes or false if connection close fails</returns>
        public Boolean Close()
        {
            try
            { 
                conn.Close();
                return true;
            }catch (MySqlException e)
            {
                Console.Write(e.ToString());
                return false;
            }
        }
        /// <summary>
        /// Begins transaction 
        /// </summary>
        public void StartTransaction()
        {
            try
            {    
                Connect();
                trans = conn.BeginTransaction();

            }catch(MySqlException e)
            {
                Console.Write(e.ToString());
            }
        }
        /// <summary>
        /// Ends transaction
        /// </summary>
        public void EndTransaction()
        {
            try
            {
                trans.Commit();
            }
            catch (MySqlException e)
            {
                Console.Write(e.ToString());
            }

        }
        /// <summary>
        /// Rollback transaction
        /// </summary>
        public void RollbackTransaction()
        {
            trans.Rollback();    
        }
        /// <summary>
        /// Gets data from the database with a SQL query statement
        /// </summary>
        /// <param name="sql">contains SQL query statement</param>
        /// <param name="values">contains bind values for SQL query statement</param>
        /// <returns>List<String[]> containing rows of data from the database</returns>
        public List<string[]> GetData(string sql,Dictionary<string,string> values)
        {
            List<string[]> data = new List<string[]>();
            Connect();
            MySqlCommand stmt = Prepare(sql, values);
            MySqlDataReader rdr = stmt.ExecuteReader();
            while(rdr.Read())
            {
                string[] row = new string[rdr.FieldCount];
                for(int i =0; i<rdr.FieldCount; i++)
                {
                    row[i] = rdr.GetValue(i).ToString();
                }
                data.Add(row);
            }
            Close();
            return data;
        }
        /// <summary>
        /// Sets data in the database with a INSERT,UPDATE or DELETE statement
        /// </summary>
        /// <param name="sql">contains non-query SQL Statement</param>
        /// <param name="values">contains bind values for non-query SQL statement</param>
        /// <returns></returns>
        public int SetData(string sql,Dictionary<string,string> values)
        {
            Connect();
            int effected = 0;
            effected = ExecuteStmt(sql, values);
            Close();
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
            MySqlCommand stmt = new MySqlCommand(sql, conn);
            if(values != null)
            {
                MySqlParameter param = null;
                foreach(KeyValuePair<string,string> value in values)
                {
                    param = new MySqlParameter(value.Key, value.Value);
                    stmt.Parameters.Add(param);
                }
                stmt.Prepare();
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
            stmt = Prepare(sql, values);
            effected = stmt.ExecuteNonQuery();
            return effected;
        }
        /// <summary>
        /// Reads Connection String from .txt file and returns it as a string
        /// </summary>
        /// <param name="file">The Location path of the .txt file</param>
        public string LoadConnString(string file)
        {
            string conn = null;
            try
            {             
                var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream))
                {
                    conn = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return conn;
        }

    }
}
