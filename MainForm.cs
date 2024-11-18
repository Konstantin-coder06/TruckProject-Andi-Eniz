using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Truck.WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static int Option { get; set; }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SignUp logIn = new SignUp();
            logIn.label5.Text = "First and last name";
            logIn.label4.Visible = true;
            logIn.textBox6.Visible = true;
            logIn.textBox1.Visible = false;
            logIn.textBox2.Visible = false;
            logIn.label1.Visible = false;
            logIn.label2.Visible = false;
            Option = 1;
            logIn.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SignUp logIn = new SignUp();
            logIn.label5.Text = "Name of company";
            logIn.textBox1.Visible = true;
            logIn.label1.Visible = true;
            logIn.textBox2.Visible = true;
            logIn.label2.Visible = false;
            logIn.label4.Visible = false;
            logIn.textBox6.Visible = true;
            Option = 2;
            logIn.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SignUp logIn = new SignUp();
            logIn.label5.Text = "Name of company";
            logIn.textBox1.Visible = true;
            logIn.label1.Visible = true;
            logIn.textBox2.Visible = true;
            logIn.label4.Visible = false;
            logIn.textBox6.Visible = false;
            logIn.label2.Visible = true;
            Option = 3;
            logIn.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/profile.php?id=100014814067180",
                UseShellExecute = true
            });
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/k_k_1on/",
                UseShellExecute = true
            });
        }
    }
}

