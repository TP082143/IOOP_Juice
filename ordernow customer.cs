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
using System.Xml.Linq;

namespace Assignment
{
    public partial class ordernow_customer : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;";

        public ordernow_customer()
        {
            InitializeComponent();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            main_menu_customer newForm = new main_menu_customer();
            newForm.Show();
            this.Hide();
        }

        private void ordernow_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            using (SqlConnection menu = new SqlConnection(connection))
            {
                menu.Open();
                string querymenu = "Select Concat(FoodID, ',', FName, ',', FPrice) as menu From menu";
                using (SqlCommand cmd = new SqlCommand(querymenu, menu))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listMenu.Items.Add(reader["menu"]);
                        }
                    }

                }

            }

        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {
            feedback_customer newForm = new feedback_customer();
            newForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            vieworder_customer newForm = new vieworder_customer();
            newForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int total = int.Parse(label5.Text);
            label5.Text = (total + 1).ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            int total = int.Parse(label5.Text);
            if (total > 1)
            {
                label5.Text = (total - 1).ToString();
            }

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection order = new SqlConnection(connection))
            {
                order.Open();
                string query = "Insert into order(OrderID, FoodID, Food_Name, Price, Quantity, Order_status, Total_Prices) Values(@orderid, @foodid, @foodname, @price, @quantity, @orderstatus)";
                using (SqlCommand cmd = new SqlCommand(query, order))
                {
                    cmd.Parameters.AddWithValue("@orderid", listMenu.SelectedItem.ToString().Split(',')[0]);
                    cmd.Parameters.AddWithValue("@foodid", listMenu.SelectedItem.ToString().Split(',')[1]);
                    cmd.Parameters.AddWithValue("@foodname", listMenu.SelectedItem.ToString().Split(',')[2]);
                    cmd.Parameters.AddWithValue("@price", listMenu.SelectedItem.ToString().Split(',')[3]);
                    cmd.Parameters.AddWithValue("@amount", label5.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void listMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

