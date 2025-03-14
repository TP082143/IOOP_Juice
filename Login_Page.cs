using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment
{
    public partial class Login_Page : Form
    {
        login_user hold;
        public Login_Page()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            hold = new login_user(txtBoxUsername.Text, txtBoxPassword.Text);
            string status = hold.login();
            if (status != null)
            {
                if(status == "found")
                {
                    this.Close();
                }
                else
                    MessageBox.Show(status);
            }
            txtBoxUsername.Text = string.Empty;
            txtBoxPassword.Text = string.Empty;
            txtBoxUsername.Focus();
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text != "Enter your password")
            {
                txtBoxPassword.ForeColor = Color.Black;
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if(txtBoxUsername.Text != "Enter your username or email")
            {
                txtBoxUsername.ForeColor = Color.Black;
                txtBoxUsername.Focus();
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblLoginInstruction_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxUsername_Enter(object sender, EventArgs e)
        {
            if(txtBoxUsername.Text == "Enter your username or email")
            {
                txtBoxUsername.Text = "";
                txtBoxUsername.ForeColor = Color.LightGray;
            }
        }

        private void txtBoxUsername_Leave(object sender, EventArgs e)
        {
            if( txtBoxUsername.Text == "")
            {
                txtBoxUsername.Text = "Enter your username or email";
                txtBoxUsername.ForeColor = Color.LightGray;
            }
        }

        private void txtBoxPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text == "Enter your password")
            {
                txtBoxPassword.Text = "";
                txtBoxPassword.ForeColor = Color.LightGray;
            }
        }

        private void txtBoxPassword_Leave(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text == "")
            {
                txtBoxPassword.Text = "Enter your password";
                txtBoxPassword.ForeColor = Color.LightGray;
            }
        }
    }
}
