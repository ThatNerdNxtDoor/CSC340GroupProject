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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            listBox1.Items.Add("Room 1");
            listBox1.Items.Add("Room 2");
            listBox1.Items.Add("Room 3");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }
}
