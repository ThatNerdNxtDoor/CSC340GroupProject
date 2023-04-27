using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSC340GroupProject
{
    internal class Meeting
    {
        string title;
        TimeSpan startTime; //These two should only be the time
        TimeSpan endTime;
        DateTime date; //should only be the date
        string location;
        string description;

        public static Employee currentEmployee;

        //Constructor
        public Meeting(String t, TimeSpan st, TimeSpan et, DateTime d, String l, String ds) {
            title = t;
            startTime = st;
            endTime = et;
            date = d;
            location = l;
            description = ds;
        }

        public Meeting()
        {

        }

        public String getStartTime()
        {
            return startTime.ToString();
        }

        public String getEndTime()
        {
            return endTime.ToString();
        }

        public String getDate()
        {
            return date.ToString();
        }

        public String getLocation()
        {
            return location;
        }
        public String getTitle()
        {
            return title;
        }

        public String getDescription()
        {
            return description;
        }

        public static ArrayList retrieveExistingMeetings(string dateString)
        {
            ArrayList meetingList = new ArrayList();  //a list to save the meetings
            //prepare an SQL query to retrieve all the meetings on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                ////////////////ToDo: Redo SQL statement
                string sql = "SELECT * FROM thompsonisaiahevent WHERE date=@myDate AND employeeID=@emp ORDER BY startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", dateString);
                cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
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
                Meeting newMeeting = new Meeting();
                newMeeting.title = row["title"].ToString();
                newMeeting.date = DateTime.Parse(row["date"].ToString());
                newMeeting.startTime = TimeSpan.ParseExact(row["startTime"].ToString(), "hh\\:mm\\:ss", null);
                newMeeting.endTime = TimeSpan.ParseExact(row["endTime"].ToString(), "hh\\:mm\\:ss", null);
                newMeeting.description = row["description"].ToString();
                newMeeting.location = row["location"].ToString();
                meetingList.Add(newMeeting);
            }
            return meetingList;  //return the meeting list
        }

        //Create a new meeting in the database
        public static void createMeeting(string t, string st, string et, string d, string l, string ds)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                ////////////////Todo: Redo SQL statement and check for employee and room times
                string sql = "INSERT INTO thompsonisaiahevent (employeeID, title, startTime, endTime, date, location, description) VALUES (@emp, @t, @st, @et, @d, @l, @ds)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@st", TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null));
                cmd.Parameters.AddWithValue("@et", TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null));
                cmd.Parameters.AddWithValue("@d", DateTime.Parse(d));
                cmd.Parameters.AddWithValue("@l", l);
                cmd.Parameters.AddWithValue("@ds", ds);
                if (cmd.ExecuteNonQuery() > 0) //Executes the command
                {
                    Console.WriteLine("INSERT statement successful");
                }
                else
                {
                    Console.WriteLine("INSERT statement failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //After adding the new meetoing, it refreshes the meeting list
            retrieveExistingMeetings(d);
        }

        public void deleteMeeting()
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                ////////////////Todo: Redo SQL statement 
                string sql = "DELETE FROM thompsonisaiahevent WHERE employeeID=@emp AND date=@myDate AND title=@t LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                cmd.Parameters.AddWithValue("@myDate", DateTime.Parse(this.getDate()));
                cmd.Parameters.AddWithValue("@t", this.getTitle());
                if (cmd.ExecuteNonQuery() > 0)
                { //Executes the command
                    Console.WriteLine("DELETE statement successful");
                }
                else
                {
                    Console.WriteLine("DELETE statement failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //After removing the meeting, it refreshes the meeting list
            retrieveExistingMeetings(this.getDate());
        }

        //Changes a specific meeting
        public void saveMeetingEdit(string t, string st, string et, string d, string l, string ds)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                ////////////////Todo: Redo SQL statement
                string sql = "UPDATE thompsonisaiahevent SET title=@t, startTime=@st, endTime=@et, date=@d, location=@l, description=@ds WHERE employeeID=@emp AND date=@oldDate AND title=@ot LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@st", TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null));
                cmd.Parameters.AddWithValue("@et", TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null));
                cmd.Parameters.AddWithValue("@d", DateTime.Parse(d));
                cmd.Parameters.AddWithValue("@l", l);
                cmd.Parameters.AddWithValue("@ds", ds);

                cmd.Parameters.AddWithValue("@ot", this.getTitle());
                cmd.Parameters.AddWithValue("@oldDate", DateTime.Parse(this.getDate()));
                if (cmd.ExecuteNonQuery() > 0) //Executes the command
                {
                    Console.WriteLine("UPDATE statement successful");
                }
                else
                {
                    Console.WriteLine("UPDATE statement failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //After editing the meeting, it refreshes the meeting list
            retrieveExistingMeetings(this.getDate());
        }

        //Put the list of meetings into the specified listBox
        public static void displayMeetings(ArrayList mList, ListBox meetingList)
        {
            meetingList.Items.Clear();
            for (int i = 0; i < mList.Count; i++)
            {
                Meeting currentMeeting = (Meeting)mList[i];
                String aString = currentMeeting.getTitle();
                meetingList.Items.Add(aString);
            }
        }

        public static void logOut()
        {
            currentEmployee = null;
        }
    }
}
