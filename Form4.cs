using Microsoft.VisualBasic;
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
using System.Windows.Forms.Design;

namespace CSC340GroupProject
{
    public partial class Form4 : Form
    {
        string dateString;
        ArrayList empList;
        Employee selectedEmployee;

        public Form4()
        {
            InitializeComponent();
            dateString = DateTime.Now.ToString("yyyy-MM-dd");
            empList = Employee.retrieveEmployeeList();
            Employee.displayEmployeeList(listBox1, empList);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            selectedEmployee = (Employee)empList[listBox1.SelectedIndex];
            TimeSpan st = new TimeSpan(9, 0, 0);
            TimeSpan et = new TimeSpan(9, 15, 0);
            for (int i = 0; i < 33; i++)
            {
                Label p = new Label();
                //Edit cell depending on if there's a conflict or not.
                //To do: Determine what the sql issue is here.
                if (selectedEmployee.checkEmployeeAvailability(st.ToString(), et.ToString(), dateString))
                {
                    p.Text = "Available";
                    p.ForeColor = Color.DarkGreen;
                }
                else
                {
                    p.Text = "Unavailable";
                    p.ForeColor = Color.Red;
                }
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, i));
                tableLayoutPanel1.Controls.Add(new Label() { Text = st.ToString() }, 0, i);
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, i));
                tableLayoutPanel1.Controls.Add(p, 1, i);
                st = st.Add(new TimeSpan(0, 15, 0));
                et = et.Add(new TimeSpan(0, 15, 0));
            }
            panel1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            panel1.Visible = false;
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;
            dateString = selectedDate.ToString("yyyy-MM-dd");
            if (selectedEmployee != null)
            {
                TimeSpan st = new TimeSpan(9, 0, 0);
                TimeSpan et = new TimeSpan(9, 15, 0);
                for (int i = 0; i < 33; i++)
                {
                    Label p = new Label();
                    //Edit cell depending on if there's a conflict or not.
                    //To do: Determine what the sql issue is here.
                    if (selectedEmployee.checkEmployeeAvailability(st.ToString(), et.ToString(), dateString))
                    {
                        p.Text = "Available";
                        p.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        p.Text = "Unavailable";
                        p.ForeColor = Color.Red;
                    }
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, i));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = st.ToString() }, 0, i);
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, i));
                    tableLayoutPanel1.Controls.Add(p, 1, i);
                    st = st.Add(new TimeSpan(0, 15, 0));
                    et = et.Add(new TimeSpan(0, 15, 0));
                }
                panel1.Visible = true;
            }
        }
    }
}
