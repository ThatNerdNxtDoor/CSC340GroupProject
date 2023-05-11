namespace CSC340GroupProject
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            monthCalendar1 = new MonthCalendar();
            panel1 = new Panel();
            button9 = new Button();
            button8 = new Button();
            label2 = new Label();
            button6 = new Button();
            label3 = new Label();
            listBox2 = new ListBox();
            panel3 = new Panel();
            button12 = new Button();
            button13 = new Button();
            label5 = new Label();
            panel2 = new Panel();
            textBox6 = new TextBox();
            label10 = new Label();
            textBox5 = new TextBox();
            label9 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(18, 192);
            button1.Name = "button1";
            button1.Size = new Size(224, 62);
            button1.TabIndex = 0;
            button1.Text = "Create Meeting";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Maroon;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(18, 328);
            button2.Name = "button2";
            button2.Size = new Size(224, 62);
            button2.TabIndex = 1;
            button2.Text = "Employee Times";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Maroon;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(18, 396);
            button3.Name = "button3";
            button3.Size = new Size(224, 62);
            button3.TabIndex = 2;
            button3.Text = "Room Times";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Maroon;
            button4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(612, 12);
            button4.Name = "button4";
            button4.Size = new Size(161, 66);
            button4.TabIndex = 3;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(18, 18);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 9;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(609, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(161, 161);
            panel1.TabIndex = 10;
            panel1.Visible = false;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button9.Location = new Point(86, 110);
            button9.Name = "button9";
            button9.Size = new Size(72, 48);
            button9.TabIndex = 2;
            button9.Text = "No";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Maroon;
            button8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button8.ForeColor = SystemColors.Control;
            button8.Location = new Point(3, 110);
            button8.Name = "button8";
            button8.Size = new Size(72, 48);
            button8.TabIndex = 1;
            button8.Text = "Yes";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 0);
            label2.Name = "label2";
            label2.Size = new Size(126, 90);
            label2.TabIndex = 0;
            label2.Text = "Are you sure you want to log out?";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // button6
            // 
            button6.BackColor = Color.Maroon;
            button6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(18, 260);
            button6.Name = "button6";
            button6.Size = new Size(224, 62);
            button6.TabIndex = 6;
            button6.Text = "Cancel Meeting";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(248, 29);
            label3.Name = "label3";
            label3.Size = new Size(220, 82);
            label3.TabIndex = 12;
            label3.Text = "Your Meetings";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBox2
            // 
            listBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Location = new Point(248, 114);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(220, 354);
            listBox2.TabIndex = 11;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(button12);
            panel3.Controls.Add(button13);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(248, 307);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 161);
            panel3.TabIndex = 12;
            panel3.Visible = false;
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button12.Location = new Point(145, 110);
            button12.Name = "button12";
            button12.Size = new Size(72, 48);
            button12.TabIndex = 2;
            button12.Text = "No";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.BackColor = Color.Maroon;
            button13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button13.ForeColor = SystemColors.Control;
            button13.Location = new Point(3, 110);
            button13.Name = "button13";
            button13.Size = new Size(72, 48);
            button13.TabIndex = 1;
            button13.Text = "Yes";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(24, 0);
            label5.Name = "label5";
            label5.Size = new Size(164, 107);
            label5.TabIndex = 0;
            label5.Text = "Are you sure you want to cancel the selected meeting?";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(474, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(299, 354);
            panel2.TabIndex = 13;
            panel2.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(3, 290);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(293, 43);
            textBox6.TabIndex = 12;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(3, 257);
            label10.Name = "label10";
            label10.Size = new Size(210, 30);
            label10.TabIndex = 11;
            label10.Text = "Description";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(107, 53);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(176, 23);
            textBox5.TabIndex = 10;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(3, 49);
            label9.Name = "label9";
            label9.Size = new Size(98, 30);
            label9.TabIndex = 9;
            label9.Text = "Date";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(3, 211);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(293, 43);
            textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(107, 141);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(176, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(107, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(176, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(107, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 23);
            textBox1.TabIndex = 5;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(3, 178);
            label8.Name = "label8";
            label8.Size = new Size(210, 30);
            label8.TabIndex = 4;
            label8.Text = "Attending Employees";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(3, 138);
            label7.Name = "label7";
            label7.Size = new Size(98, 30);
            label7.TabIndex = 3;
            label7.Text = "Room #";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 108);
            label6.Name = "label6";
            label6.Size = new Size(98, 30);
            label6.TabIndex = 2;
            label6.Text = "End Time";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 78);
            label4.Name = "label4";
            label4.Size = new Size(98, 30);
            label4.TabIndex = 1;
            label4.Text = "Start Time";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(296, 30);
            label1.TabIndex = 0;
            label1.Text = "MeetingTitle";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 486);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(listBox2);
            Controls.Add(monthCalendar1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private MonthCalendar monthCalendar1;
        private Panel panel1;
        private Button button9;
        private Button button8;
        private Label label2;
        private Button button6;
        private Label label3;
        private ListBox listBox2;
        private Panel panel3;
        private Button button12;
        private Button button13;
        private Label label5;
        private Panel panel2;
        private Label label1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private TextBox textBox5;
        private Label label9;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox6;
        private Label label10;
    }
}