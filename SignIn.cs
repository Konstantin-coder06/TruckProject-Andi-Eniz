using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck.WinFormsApp1
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Regex.IsMatch(textBox1.Text, @"^[^@]+@admin\.org$"))
            {
                Admin admin = new Admin();
                admin.Show();
            }
            else
            {
                Driver driver = new Driver();
                driver.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
