using System;
using System.Collections.Generic;
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
    }
}
