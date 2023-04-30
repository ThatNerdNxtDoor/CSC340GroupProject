using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSC340GroupProject
{
    internal class Employee
    {
        string name;
        string username;
        string password;

        public Employee(string n, string u, string p)
        {
            name = n;
            username = u;
            password = p;
        }

        public string getName()
        {
            return name;
        }

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public static bool validateIdentification(string username, string password)
        {
            //retrieve data from database
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM thompsonisaiahhemployee WHERE username=@name AND password=@passd"; ////////////CHANGE THIS TO ACCOMODATE FOR EVERYONE
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@passd", password);

                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    Meeting.currentEmployee = new Employee(myReader.GetString(0), myReader.GetString(1), myReader.GetString(2));
                    myReader.Close();
                }
                else
                {
                    myReader.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            //If data exists, return true
            conn.Close();
            Console.WriteLine("Done.");
            return true;
        }
    }
}
