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
    public partial class CompanyDeliver : Form
    {
        public CompanyDeliver()
        {
            InitializeComponent();
        }
        private MainForm mainForm;
        private void Contact_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }
        private void CompanyDeliver_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Close();
            mainForm.Show();
        }
    }
}
