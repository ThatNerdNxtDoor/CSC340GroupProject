using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Collections;
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

        public Employee() { }

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
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM ford_kelley_thompson_employee WHERE username=@name AND password=@passd";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

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

        public static ArrayList retrieveEmployeeList() {
            ArrayList eList = new ArrayList();
            //prepare an SQL query to retrieve all of the employees
            DataTable myTable = new DataTable();
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string sql;
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd;
                sql = "SELECT * FROM ford_kelley_thompson_employee ORDER BY name ASC";
                cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable); //Executes the command
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to meetings and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Employee newEmp = new Employee();
                newEmp.username = row["username"].ToString();
                newEmp.password = row["password"].ToString();
                newEmp.name = row["name"].ToString();
                eList.Add(newEmp);
            }
            return eList;
        }

        public static void displayEmployeeList(ListBox listBox, ArrayList eList) {
            listBox.Items.Clear();
            for (int i = 0; i < eList.Count; i++)
            {
                Employee currentEmp = (Employee)eList[i];
                String aString = currentEmp.getName();
                listBox.Items.Add(aString);
            }
        }

        public bool checkEmployeeAvailability(string st, string et, string date)
        {
            //Gets a list of possible conflicting meeting to compare
            ArrayList meetingList = Meeting.retrieveExistingMeetings(date, this);
            foreach (Meeting m in meetingList)
            {
                TimeSpan mStart = TimeSpan.ParseExact(m.getStartTime(), "hh\\:mm\\:ss", null);
                TimeSpan mEnd = TimeSpan.ParseExact(m.getEndTime(), "hh\\:mm\\:ss", null);

                //Compare the times of each meeting to the new one and return false if there is an overlap
                if ((TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null) > mStart && TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null) < mEnd)
                    || (TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null) > mStart && TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null) < mEnd)
                    || (mStart > TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null) && mStart < TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null))
                    || (mEnd > TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null) && mEnd < TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null)))
                {
                    return false;
                }
            }
            //If there was no time conflict, return true
            return true;
        }

    }
}
