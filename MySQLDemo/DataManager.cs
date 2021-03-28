using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLDemo
{
    class DataManager // Singleton DataManager class
    {
        private static DataManager _instance;
        // MySQL Connection String constants:
        private const String SOURCE_IP = "127.0.0.1"; // Localhost IP
        private const String SOURCE_PORT = "3306"; // MySQL DBMS uses 3306 port
        private const String USERNAME = "root"; // Default username for MySQL databases
        private const String PWD = ""; // Default password for MySQL databases
        private const String DB_NAME = "demobase";
        // Table name constants:
        private const String CUSTOMER_TABLE = "table_customer";
        // Query properties:
        private const short QUERY_TIMEOUT = 60; // Timeout for queries in seconds
        // Connection object
        private MySqlConnection dbConnection;
        
        private DataManager() {
            String conn = $"datasource={SOURCE_IP};port={SOURCE_PORT};username={USERNAME};password={PWD};database={DB_NAME};sslmode=none";
            dbConnection = new MySqlConnection(conn);
        }

        public static DataManager GetInstance() // Singleton class
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }

        public List<Customer> getCustomers()
        {
            List<Customer> customers = null;
            MySqlCommand command = new MySqlCommand($"SELECT * FROM {CUSTOMER_TABLE}", dbConnection); // Executes queries using the MySqlConnection object
            MySqlDataReader dataReader = tryExecute(command);
            if (dataReader.HasRows)
            {
                customers = new List<Customer>();
                while (dataReader.Read())
                {
                    // MySQL BIGINT (used for primary key) is a 64-bit signed integer
                    customers.Add(new Customer(dataReader.GetInt64(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3)));
                }
            }
            // Remember to close connection after you do not need it
            dbConnection.Close();
            return customers;
        } 

        private MySqlDataReader tryExecute(MySqlCommand command)
        {
            MySqlDataReader dataReader = null;
            command.CommandTimeout = QUERY_TIMEOUT;
            try
            {
                dbConnection.Open();
                dataReader = command.ExecuteReader();
                Console.WriteLine("Query ran successfully. Query was: " + command.CommandText);
            } catch (Exception e)
            {
                Console.Error.WriteLine("Failed to execute command: " + e.Message);
                Console.Error.WriteLine("Query was: " + command.CommandText);
            }
            
            return dataReader;
        }
    }
}
