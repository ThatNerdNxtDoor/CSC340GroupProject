using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            listBox1.Items.Add("Isaiah Thompson (You)");
            listBox1.Items.Add("Emily Ford");
            listBox1.Items.Add("John kelley");
            listBox1.Items.Add("Kuang-nan Chang");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
