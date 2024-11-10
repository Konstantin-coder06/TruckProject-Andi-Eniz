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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
