namespace CSC340GroupProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Employee.validateIdentification(textBox1.Text.ToString(), textBox2.Text.ToString()))
            {
                //Make login form dissappear
                this.Hide();
                //Make main menu form visible
                new Form2().Show();
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}