using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class provides all access to the database
    /// </summary>
    class DatabaseConnector
    {
        /// <summary>
        /// Returns a connection to run queries on based on the parameters.
        /// </summary>
        /// <param name="host">Ip of the host</param>
        /// <param name="user">User to login</param>
        /// <param name="pwd">Password</param>
        /// <param name="db">Database to connect too</param>
        /// <returns></returns>
        public static MySqlConnection GetConnection(string host, string user, string pwd, string db)
        {
            string conStr =
            String.Format("server={0};uid={1};pwd={2};database={3}",
            host, user, pwd, db);
            var con = new MySqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            return con;
        }
        /// <summary>
        /// Gets a functioning connecting with the default paramerters. 
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetDefaultConnection()
        {
            return GetConnection("62.107.80.31", "connect", "some_pass", "test");
        }

        //This function is only here to provide an example of how to run a query.
        public static void RunQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader[i]);
                Console.WriteLine();
            }
        }
    }
}
