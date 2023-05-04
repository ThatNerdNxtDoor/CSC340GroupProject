using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;

namespace CSC340GroupProject
{

    internal class Room
    {
        int id;

        public Room(int i) {
            this.id = i;
        }

        public Room() { }

        public int getId() { return id; }

        public static ArrayList retrieveRoomList() {
            ArrayList rmList = new ArrayList();
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
                sql = "SELECT * FROM ford_kelley_thompson_room ORDER BY roomID ASC";
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
                Room newRm = new Room();
                newRm.id = int.Parse(row["roomID"].ToString());
                rmList.Add(newRm);
            }
            return rmList;
        }

        public static void displayRoomList(ListBox listBox, ArrayList rmList)
        {
            listBox.Items.Clear();
            for (int i = 0; i < rmList.Count; i++)
            {
                Room currentRm = (Room)rmList[i];
                String aString = "Room " + currentRm.getId();
                listBox.Items.Add(aString);
            }
        }

        public bool checkRoomAvailability(string st, string et, string date)
        {
            //Gets a list of possible conflicting meeting to compare
            ArrayList meetingList = Meeting.retrieveExistingMeetings(date, this.id);
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
