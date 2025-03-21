using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class vieworder_customer : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;";
        public vieworder_customer()
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

        private void vieworder_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            using (SqlConnection order = new SqlConnection(connection))
            {
                order.Open();
                string queryorder = "Select (OrderID, FoodID, Food_Name, Price, Quantity) as Vieworder From order";
                using (SqlCommand cmd = new SqlCommand(queryorder, order))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listViewOrder.Items.Add(reader["Vieworder"]);
                        }
                    }

                }

            }
            double Total = 0;
            foreach (var item in listViewOrder.Items)
            {
                string row = item.ToString();
                double price = double.Parse(row.Split(',')[4]);
                Total = Total + price;
            }
            lblTotal.Text = Total.ToString();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Total=double.Parse(lblTotal.Text);
            double Amount = double.Parse(txtAmount.Text);
            if (Amount >= double.Parse(lblTotal.Text))
            {
                double balance = Amount - Total;
                MessageBox.Show($"Balance:RM{balance},Thank You!");
            }
            else
            {
                double underpaid = Total - Amount;
                MessageBox.Show($"You've underpaid by RM{underpaid}, Please try again!");
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
