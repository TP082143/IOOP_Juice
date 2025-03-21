using System;
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
    public partial class reservation_customer : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;";

        public reservation_customer()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reservation_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            using (SqlConnection hall= new SqlConnection(connection))
            {
                hall.Open();
                string queryHall = "Select Concat(HallID, ',', Capacity, ',', PartyType) as Hall From Hall";
                using (SqlCommand cmd = new SqlCommand(queryHall, hall))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstHall.Items.Add(reader["Hall"]);
                        }
                    }

                }

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            main_menu_customer newForm = new main_menu_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            feedback_customer newForm = new feedback_customer();
            newForm.Show();
            this.Hide();
        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {
            feedback_customer newForm = new feedback_customer();
            newForm.Show();
            this.Hide();
        }

        private void lblUsername_Click(object sender, EventArgs e)
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

        private void lblOrder_Click(object sender, EventArgs e)
        {
            ordernow_customer newForm = new ordernow_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            vieworder_customer newForm = new vieworder_customer();
            newForm.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection reservation = new SqlConnection(connection))
            {
                reservation.Open();
                string query = "Insert into reservation(CusUsername, Contact, HallID, Capacity, NumPeople, PartyType, Date, TimeStart, TimeEnd, Status) Values(@name,@cn, @hall, @capacity, @num, @party, @date, @timestart ,@timeend, @status)";
                using (SqlCommand cmd = new SqlCommand(query, reservation))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@cn", txtContact.Text);
                    cmd.Parameters.AddWithValue("@hall", lstHall.SelectedItem.ToString().Split(',')[0]);
                    cmd.Parameters.AddWithValue("@num", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@party", lstHall.SelectedItem.ToString().Split(',')[2]);
                    cmd.Parameters.AddWithValue("@date", DtpDate.Text);
                    cmd.Parameters.AddWithValue("@capacity", lstHall.SelectedItem.ToString().Split(',')[1]);
                    cmd.Parameters.AddWithValue("@timestart", CmbStart.Text);
                    cmd.Parameters.AddWithValue("@timeend", CmbEnd.Text);
                    cmd.Parameters.AddWithValue("@status", "pending");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vieworder_customer newForm = new vieworder_customer();
            newForm.Show();
            this.Hide();
        }
    }
}



