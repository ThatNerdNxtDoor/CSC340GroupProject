using Google.Protobuf.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC340GroupProject
{
    public partial class Form2 : Form
    {
        ArrayList mList;
        Meeting selectedEvent;
        DateTime selectedDate;
        string thisDate;

        public Form2()
        {
            InitializeComponent();
            selectedDate = DateTime.Today;

            listBox2.Items.Add("Group Project");
            listBox2.Items.Add("Meet With Dr. Chang");
        }

        private void button1_Click(object sender, EventArgs e) //Create new meeting
        {
            new Form3().Show();
            
            
        }

        private void button3_Click(object sender, EventArgs e) //Check room availibility
        {
            new Form5().Show();
        }

        private void button2_Click(object sender, EventArgs e) //Check employee availability
        {
            new Form4().Show();
        }

        private void button4_Click(object sender, EventArgs e) //Log Out
        {
            panel1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e) //Confirm Log Out
        {

        }

        private void button9_Click(object sender, EventArgs e) //Cancel Log Out
        {
            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e) //Cancel Meeting
        {
            panel3.Visible = true;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e) //Cancel Delete
        {
            panel3.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //Select meeting
        {
            selectedEvent = (Meeting)mList[listBox2.SelectedIndex];

            textBox1.Text = selectedEvent.getTitle();
            textBox2.Text = selectedEvent.getStartTime();
            textBox3.Text = selectedEvent.getEndTime();
            textBox4.Text = selectedEvent.getLocation();
            textBox5.Text = selectedEvent.getDescription();
        }

        private void button13_Click(object sender, EventArgs e) //Confirm Delete
        {
            mList = Meeting.retrieveExistingMeetings(thisDate);
            Meeting.displayMeetings(mList, listBox2);
            Meeting delete = new Meeting();
            delete.deleteMeeting();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) //Change Date
        {
            selectedDate = monthCalendar1.SelectionRange.Start;
            thisDate = selectedDate.ToString("yyyy-MM-dd");
            mList = Meeting.retrieveExistingMeetings(thisDate);
            Meeting.displayMeetings(mList, listBox2);
        }
    }
}
