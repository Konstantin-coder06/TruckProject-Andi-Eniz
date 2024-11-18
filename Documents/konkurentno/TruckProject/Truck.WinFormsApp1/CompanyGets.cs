using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck.WinFormsApp1
{
    public partial class CompanyGets : Form
    {
        public CompanyGets()
        {
            InitializeComponent();
            // comboBox3.Items.Add("Bulgaria");
        }
        private MainForm mainForm;
        private void Contact_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // comboBox1.Text = "Type of stock";
            //comboBox2.Text = "";
            comboBox3.Text = "Choose country";
            comboBox4.Text = "Choose region";
            comboBox5.Text = "Choose city";
            dateTimePicker1.Text = DateTime.Now.ToString();
            richTextBox1.Clear();
            //richTextBox1.Text=controllervsjovmods.Info();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Close();
            mainForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDriverCompany updateDriverCompany = new UpdateDriverCompany();
            this.Close();
            updateDriverCompany.label1.Text = "Change something\r\nabout your company ";
            updateDriverCompany.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           UpdateDriverCompany updateDriverCompany = new UpdateDriverCompany();
            this.Close();
            updateDriverCompany.label1.Text = "Change something\r\nabout drivers ";
            updateDriverCompany.Show();
        }
    }
}
