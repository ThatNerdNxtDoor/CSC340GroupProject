﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSC340GroupProject
{
    public partial class Form3 : Form
    {
        string selectedDate;
        String attendingMembers;


        public Form3()
        {
            InitializeComponent();
            selectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            attendingMembers = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e) //Confirm Creation
        {
            Meeting.createMeeting(textBox1.Text, textBox2.Text, textBox3.Text, selectedDate, textBox5.Text, textBox6.Text, textBox4.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //Cancel Delete
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
        }
    }
}
