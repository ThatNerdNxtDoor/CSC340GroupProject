using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities.Collections;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace CSC340GroupProject
{
    internal class Meeting
    {
        int id;
        string host; //Username of host of meeting
        string title;
        TimeSpan startTime; //These two should only be the time
        TimeSpan endTime;
        DateTime date; //should only be the date
        string location;
        string description;

        public static Employee currentEmployee;

        //Constructor
        public Meeting(int ID, String t, TimeSpan st, TimeSpan et, DateTime d, String l, String ds) {
            id = ID;
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

        //Retrieves meetings
        //Used for displaying on the main page
        //Meant for group Database
        public static ArrayList retrieveExistingMeetings(string dateString)
        {
            ArrayList meetingList = new ArrayList();  //a list to save the meetings
            //prepare an SQL query to retrieve all the meetings on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string sql;
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd;
                sql = "SELECT * FROM ford_kelley_thompson_meeting INNER JOIN ford_kelley_thompson_attending ON ford_kelley_thompson_meeting.id = ford_kelley_thompson_attending.meetingID WHERE ford_kelley_thompson_meeting.date=@myDate AND ford_kelley_thompson_attending.employeeID=@emp ORDER BY startTime ASC";
                cmd = new MySqlCommand(sql, conn);
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
                newMeeting.id = int.Parse(row["id"].ToString());
                newMeeting.host = row["host"].ToString();
                newMeeting.title = row["meetingTitle"].ToString();
                newMeeting.date = DateTime.Parse(row["meetingDate"].ToString());
                newMeeting.startTime = TimeSpan.ParseExact(row["startTime"].ToString(), "hh\\:mm\\:ss", null);
                newMeeting.endTime = TimeSpan.ParseExact(row["endTime"].ToString(), "hh\\:mm\\:ss", null);
                newMeeting.description = row["meetingDescription"].ToString();
                newMeeting.location = row["room"].ToString();
                meetingList.Add(newMeeting);
            }
            return meetingList;  //return the meeting list
        }
        
        //Overload version to apply for any employee
        //Used for checking time availibility, so it directly checks every event in the individual databases.
        public static ArrayList retrieveExistingMeetings(string dateString, Employee employee)
        {
            ArrayList meetingList = new ArrayList();  //a list to save the meetings
            //prepare an SQL query to retrieve all the meetings on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string sql;
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd;
                //Switch statement determines which employee is being checked and accessing their individual database
                switch (employee.getName()) {
                    case "Isaiah Thompson":
                        sql = "SELECT * FROM thompsonisaiahevent WHERE date=@myDate AND employeeID=@emp ORDER BY startTime ASC";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@myDate", dateString);
                        cmd.Parameters.AddWithValue("@emp", 1);
                        break;
                    case "John Kelley": //John will put his respective SQL statement here.
                        sql = "SELECT * FROM kelleyevents WHERE event_day=@myDate AND employee_ID=@emp ORDER BY start_time ASC";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@myDate", dateString);
                        cmd.Parameters.AddWithValue("@emp", 2);
                        break;
                    case "Emily Ford":
                        sql = "SELECT * FROM fordevent WHERE eventDay=@myDate AND employeeID=@emp ORDER BY startTime ASC";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@myDate", dateString);
                        cmd.Parameters.AddWithValue("@emp", 3);
                        break;
                    default: //Default
                        sql = "";
                        cmd = new MySqlCommand(sql, conn);
                        break;
                }
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
                switch (employee.getName())
                {
                    case "Isaiah Thompson":
                        newMeeting.title = row["title"].ToString();
                        newMeeting.date = DateTime.Parse(row["date"].ToString());
                        newMeeting.startTime = TimeSpan.ParseExact(row["startTime"].ToString(), "hh\\:mm\\:ss", null);
                        newMeeting.endTime = TimeSpan.ParseExact(row["endTime"].ToString(), "hh\\:mm\\:ss", null);
                        newMeeting.description = row["description"].ToString();
                        newMeeting.location = row["location"].ToString();
                        break;
                    case "John Kelley":
                        newMeeting.title = row["event_name"].ToString();
                        newMeeting.date = DateTime.Parse(row["event_day"].ToString());
                        newMeeting.startTime = TimeSpan.ParseExact(row["start_time"].ToString(), "hh\\:mm\\:ss", null);
                        newMeeting.endTime = TimeSpan.ParseExact(row["end_time"].ToString(), "hh\\:mm\\:ss", null);
                        newMeeting.description = row["description"].ToString();
                        newMeeting.location = row["location"].ToString();
                        break;
                    case "Emily Ford":
                        newMeeting.title = row["eventName"].ToString();
                        newMeeting.date = DateTime.Parse(row["eventDay"].ToString());
                        newMeeting.startTime = TimeSpan.ParseExact(row["startTime"].ToString(), "hh\\:mm\\:ss", null);
                        newMeeting.endTime = TimeSpan.ParseExact(row["endTime"].ToString(), "hh\\:mm\\:ss", null);
                        newMeeting.description = row["description"].ToString();
                        newMeeting.location = row["location"].ToString();
                        break;

                    default:
                        break;
                }
                
                meetingList.Add(newMeeting);
            }
            return meetingList;  //return the meeting list
        }

        //Overload version to retrieve events based on the room it is in
        //Used for checking time availibility of rooms
        public static ArrayList retrieveExistingMeetings(string dateString, int roomNum)
        {
            ArrayList meetingList = new ArrayList();  //a list to save the meetings
            //prepare an SQL query to retrieve all the meetings on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string sql;
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd;
                sql = "SELECT * FROM ford_kelley_thompson_meeting WHERE meetingDate=@myDate AND room=@rm ORDER BY startTime ASC";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", dateString);
                cmd.Parameters.AddWithValue("@rm", roomNum); //Room's ID
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
                newMeeting.title = row["meetingTitle"].ToString();
                newMeeting.date = DateTime.Parse(row["meetingDate"].ToString());
                newMeeting.startTime = TimeSpan.ParseExact(row["startTime"].ToString(), "hh\\:mm\\:ss", null);
                newMeeting.endTime = TimeSpan.ParseExact(row["endTime"].ToString(), "hh\\:mm\\:ss", null);
                newMeeting.description = row["meetingDescription"].ToString();
                newMeeting.location = row["room"].ToString();
                meetingList.Add(newMeeting);
            }
            return meetingList;  //return the meeting list
        }

        //Create a new meeting in the database
        //returns bool to see if the creation was successful
        public static bool createMeeting(string t, string st, string et, string d, string l, string ds, string emp)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            //Get list of attending members.
            //  Get string list of all the names, then use [string name].Split(",")
            //Then use the list of names to determine the attending members
            //Then put the meeting into each attending member's indivual database.

            string[] attending = emp.Split(",");
           
            
            try //This puts the meeting in the group database
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                ////////////////Todo: Redo SQL statement
                string sql = "INSERT INTO ford_kelley_thompson_meeting (host, room, startTime, endTime, meetingDate, meetingTitle, meetingDescription) VALUES (@emp, @l, @st, @et, @d, @t, @ds)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@st", TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null));
                cmd.Parameters.AddWithValue("@et", TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null));
                cmd.Parameters.AddWithValue("@d", DateTime.Parse(d));
                cmd.Parameters.AddWithValue("@l", Int32.Parse(l));
                cmd.Parameters.AddWithValue("@ds", ds);
                Debug.WriteLine(cmd.Parameters.ToString());
                Debug.WriteLine("First");
                if (cmd.ExecuteNonQuery() > 0) //Executes the command
                {
                    Console.WriteLine("INSERT statement successful");
                }
                else
                {
                    Console.WriteLine("INSERT statement failed");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            conn.Close();
            //Get ID of last inserted meeting
            int meetingID;
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT LAST_INSERT_ID() FROM ford_kelley_thompson_meeting";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Console.WriteLine("Second");
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    meetingID = myReader.GetInt16(0);
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
            conn.Close();
            //Fill attending table
            for (int i = 0; i < attending.Length; i++)
            {
                string sql;
                MySqlCommand cmd;
                switch (attending[i])
                {
                    case "Isaiah Thompson":
                        sql = "INSERT INTO ford_kelley_thompson_attending (employeeID, meetingID) VALUES (@emp, @m)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@emp", "isaiah_thompson6");
                        cmd.Parameters.AddWithValue("@m", meetingID);
                        break;
                    case "John Kelley":
                        sql = "INSERT INTO ford_kelley_thompson_attending (employeeID, meetingID) VALUES (@emp, @m)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@emp", "john_kelley66");
                        cmd.Parameters.AddWithValue("@m", meetingID);
                        break;
                    case "Emily Ford":
                        sql = "INSERT INTO ford_kelley_thompson_attending (employeeID, meetingID) VALUES (@emp, @m)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@emp", "emi_ford01");
                        cmd.Parameters.AddWithValue("@m", meetingID);
                        break;
                    default:
                        cmd = new MySqlCommand();
                        break;
                }
                if (cmd.ExecuteNonQuery() > 0) //Executes the command
                {
                    Console.WriteLine("INSERT statement successful");
                }
                else
                {
                    Console.WriteLine("INSERT statement failed");
                    return false;
                }
            }
            //Add event to individual tables
            for (int i = 0; i < attending.Length; i++)
            {
                string sql;
                MySqlCommand cmd;
                switch (attending[i])
                {
                    case "Isaiah Thompson":
                        sql = "INSERT INTO thompsonisaiahevent (employeeID, title, startTime, endTime, date, location, description) VALUES (@emp, @t, @st, @et, @d, @l, @ds)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                        cmd.Parameters.AddWithValue("@t", t);
                        cmd.Parameters.AddWithValue("@st", TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null));
                        cmd.Parameters.AddWithValue("@et", TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null));
                        cmd.Parameters.AddWithValue("@d", DateTime.Parse(d));
                        cmd.Parameters.AddWithValue("@l", l);
                        cmd.Parameters.AddWithValue("@ds", ds);
                        break;
                    case "John Kelley":
                        sql = "INSERT INTO kelleyevent(event_name, start_time, end_time, location, description, event_day, employee_ID) VALUES(@t, @st, @et, @l, @ds, @d)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@t", t);
                        cmd.Parameters.AddWithValue("@st", TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null));
                        cmd.Parameters.AddWithValue("@et", TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null));
                        cmd.Parameters.AddWithValue("@l", l);
                        cmd.Parameters.AddWithValue("@ds", ds);
                        cmd.Parameters.AddWithValue("@d", DateTime.Parse(d));
                        cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                        break;
                    case "Emily Ford":
                        sql = "INSERT INTO fordevents(eventName, startTime, endTime, location, description, eventDay, empUsername) VALUES (@t, @st, @et, @l, @ds, @d)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@t", t);
                        cmd.Parameters.AddWithValue("@st", TimeSpan.ParseExact(st, "hh\\:mm\\:ss", null));
                        cmd.Parameters.AddWithValue("@et", TimeSpan.ParseExact(et, "hh\\:mm\\:ss", null));
                        cmd.Parameters.AddWithValue("@l", l);
                        cmd.Parameters.AddWithValue("@ds", ds);
                        cmd.Parameters.AddWithValue("@d", DateTime.Parse(d));
                        cmd.Parameters.AddWithValue("@emp", currentEmployee.getUsername());
                        break;
                    default:
                        cmd = new MySqlCommand();
                        break;
                }
                if (cmd.ExecuteNonQuery() > 0) //Executes the command
                {
                    Console.WriteLine("INSERT statement successful");
                }
                else
                {
                    Console.WriteLine("INSERT statement failed");
                    return false;
                }
            }
            //After adding the new meeting, it refreshes the meeting list
            retrieveExistingMeetings(d);
            return true;
        }

        //Todo: Delete the meeting from every attending member's database
        //Determine if current employee is the host of the meeting. If so, go forward with deletion, if not, stop
        public bool deleteMeeting()
        {
            string sql;
            if (this.host == currentEmployee.getUsername())
            {
                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                MySqlConnection conn = new MySqlConnection(connStr);
                //-------Delete from each attending individual's database-------
                ArrayList attendants = new ArrayList();
                DataTable myTable = new DataTable();
                try
                {
                    
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    MySqlCommand cmd;
                    sql = "SELECT employeeID FROM ford_kelley_thompson_attending WHERE meetingID=@m ORDER BY startTime ASC";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@m", this.id);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                    myAdapter.Fill(myTable); //Executes the command
                    Console.WriteLine("Table is ready.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    conn.Close();
                    return false;
                }
                conn.Close();
                foreach (DataRow row in myTable.Rows)
                {
                    string employee = row["employeeID"].ToString();
                    attendants.Add(employee);
                }
                foreach (string emp in attendants)
                {
                    try
                    {
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();
                        
                        MySqlCommand cmd = new MySqlCommand();
                        switch (emp) {
                            case "isaiahthompson02": //Isaiah
                              sql = "DELETE FROM thompsonisaiahevent WHERE employeeID=@emp AND date=@myDate AND title=@t LIMIT 1";
                                cmd = new MySqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@emp", 1);
                                cmd.Parameters.AddWithValue("@myDate", DateTime.Parse(this.getDate()));
                                cmd.Parameters.AddWithValue("@t", this.getTitle());
                                break;
                            case "john_kelley66":
                                sql = "DELETE FROM kelleyevent WHERE employee_ID=@emp AND eventDay=@myDay AND event_name=@t LIMIT 1";//John
                                break;
                            case "emilyford01": //Emily
                                sql = "DELETE FROM fordemilyevent WHERE employeeID=@emp AND eventDay=@myDay AND eventName=@t LIMIT 1";
                                cmd = new MySqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@emp", 2);
                                cmd.Parameters.AddWithValue("@myDay", DateTime.Parse(this.getDate()));
                                cmd.Parameters.AddWithValue("@name", this.getTitle());
                                break;
                            default:
                                break;
                        }
                        if (cmd.ExecuteNonQuery() > 0)
                        { //Executes the command
                            Console.WriteLine("DELETE statement successful");
                        }
                        else
                        {
                            Console.WriteLine("DELETE statement failed");
                            conn.Close();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        conn.Close();
                        return false;
                    }
                    conn.Close();
                }
                //-------Delete all attending instances-------
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    sql = "DELETE FROM ford_kelley_thompson_attending WHERE meetingID=@m";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@m", this.id);
                    if (cmd.ExecuteNonQuery() > 0)
                    { //Executes the command
                        Console.WriteLine("DELETE statement successful");
                    }
                    else
                    {
                        Console.WriteLine("DELETE statement failed");
                        conn.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    conn.Close();
                    return false;
                }
                conn.Close();
                //-------Finally, Delete the meeting itself-------
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    sql = "DELETE FROM ford_kelley_thompson_meeting WHERE host=@emp AND date=@myDate AND title=@t LIMIT 1";
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
                        conn.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    conn.Close();
                    return false;
                }
                conn.Close();
            }
            else {
                return false;
            }
            //After removing the meeting, it refreshes the meeting list
            retrieveExistingMeetings(this.getDate());
            return true;
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
