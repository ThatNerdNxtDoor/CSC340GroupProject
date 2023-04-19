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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            listBox2.Items.Add("Group Project");
            listBox2.Items.Add("Meet With Dr. Chang");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label1.Text = "Group Project";
            textBox5.Text = "3/8/2023";
            textBox1.Text = "3:30 PM";
            textBox2.Text = "4:30 PM";
            textBox3.Text = "2";
            textBox4.Text= "Emily Ford, John Kelley";
        }
    }
}
