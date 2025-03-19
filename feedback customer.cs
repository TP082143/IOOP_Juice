using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    
    public partial class feedback_customer : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;";
        public feedback_customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtfeedback.Text == "")
            {
                MessageBox.Show($"Kindly ensure that your feedback contains meaningful words. We appreciate your thoughtful input!");
            }
            else
            {
                using (SqlConnection feedback = new SqlConnection(connection))
                {
                    feedback.Open();
                    string query = "Insert into feedback(Username, Feedback) Values(@username,@feedback)";
                    using (SqlCommand cmd = new SqlCommand(query, feedback))
                    {
                        cmd.Parameters.AddWithValue("@username", lblUser.Text);
                        cmd.Parameters.AddWithValue("@feedback", txtfeedback.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Thank you for your valuable feedback! We truly appreciate your time and effort in sharing your thoughts with us");
                }
            }
        }
        

        private void feedback_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void lblOrder_Click(object sender, EventArgs e)
        {
            ordernow_customer newForm = new ordernow_customer();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            reservation_customer newForm = new reservation_customer();
            newForm.Show();
            this.Hide();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            username_customer newForm = new username_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            username_customer newForm = new username_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            main_menu_customer newForm = new main_menu_customer();
            newForm.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            vieworder_customer newForm = new vieworder_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ordernow_customer newForm = new ordernow_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
