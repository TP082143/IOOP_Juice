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
        bool pBig = true, pSmall=true;
        login_user hold;
        
        public Login_Page()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblLoginInstruction.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text != "" && txtBoxPassword.Text != "")
            {
                hold = new login_user(txtBoxUsername.Text, txtBoxPassword.Text);
                string status = hold.login();
                if (status != null)
                {
                    if (status == "found")
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
            else
                MessageBox.Show("The input boxes are empty!", "Wrning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtBoxPassword.PasswordChar = '\0';
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

        private void linkLblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timerBigPanel.Start();
        }

        private void btnForgotFind_Click(object sender, EventArgs e)
        {
            if (txtBoxForgotUsername.Text != "" && txtBoxForgotEmail.Text != "")
            {
                var (status, mess) = login_user.forgotFind(txtBoxForgotUsername.Text, txtBoxForgotEmail.Text);
                if (status)
                {
                    MessageBox.Show("The user has been found!");
                    timerSmallPanel.Start();
                }
                else
                {
                    MessageBox.Show("Something is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("The username or email box is empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timerSmallPanel_Tick(object sender, EventArgs e)
        {
            if (pSmall)
            {
                panelSmall.Width += 10;
                panelSmall.Height += 10;    
                if (panelSmall.Width == panelSmall.MaximumSize.Width && panelSmall.Height == panelSmall.MaximumSize.Height)
                {
                    timerSmallPanel.Stop();
                    pSmall = false;
                }
            }
            else
            {
                panelSmall.Width -= 10;
                panelSmall.Height -= 10;
                if (panelSmall.Width == panelSmall.MinimumSize.Width && panelSmall.Height == panelSmall.MinimumSize.Height)
                {
                    timerSmallPanel.Stop();
                    pSmall = !false;
                }
            }
        }

        private void btnPassSubmit_Click(object sender, EventArgs e)
        {
            if (login_user.updatePass(txtBoxForgotUsername.Text, txtBoxForgotEmail.Text, txtBoxForgotPass.Text))
            {
                txtBoxForgotPass.Text = string.Empty;
                MessageBox.Show("The password has been updated successfully!", "Info", MessageBoxButtons.OK);
                panelSmall.Width = panelSmall.MinimumSize.Width;
                panelSmall.Height = panelSmall.MinimumSize.Height;
                panelBig.Width = panelBig.MinimumSize.Width;
                panelBig.Height = panelBig.MinimumSize.Height;
            }
            else
                MessageBox.Show("Sorry! the update was failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void timerBigPanel_Tick(object sender, EventArgs e)
        {
            if(pBig)
            {
                panelBig.Width += 10;
                panelBig.Height += 10;
                if (panelBig.Width == panelBig.MaximumSize.Width && panelBig.Height == panelBig.MaximumSize.Height)
                {
                    timerBigPanel.Stop();
                    pBig = false;
                }
            }
            else
            {
                panelBig.Width -= 10;
                panelBig.Height -= 10;
                if(panelBig.Width == panelBig.MinimumSize.Width && panelBig.Height == panelBig.MinimumSize.Height)
                {
                    timerBigPanel.Stop();
                    pBig = !false;
                }
            }
        }
    }
}
