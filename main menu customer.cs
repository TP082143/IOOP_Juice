using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class main_menu_customer : Form
    {
        public main_menu_customer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ordernow_customer newForm = new ordernow_customer();
            newForm.Show();
            this.Hide();
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            username_customer newForm = new username_customer();
            newForm.Show();
            this.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void main_menu_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {
            feedback_customer newForm = new feedback_customer(); 
            newForm.Show(); 
            this.Hide(); 
        }

        private void lblViewOrder_Click(object sender, EventArgs e)
        {
            vieworder_customer newForm = new vieworder_customer();
            newForm.Show();
            this.Hide();
        }

        private void lblReservation_Click(object sender, EventArgs e)
        {
            reservation_customer newForm = new reservation_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            username_customer newForm = new username_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            reservation_customer newForm = new reservation_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            feedback_customer newForm = new feedback_customer();
            newForm.Show();
            this.Hide();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ordernow_customer newForm = new ordernow_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            vieworder_customer newForm = new vieworder_customer();
            newForm.Show();
            this.Hide();
        }
    }
    }

