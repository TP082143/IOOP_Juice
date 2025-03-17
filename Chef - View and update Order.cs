using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Assignment
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void View_Order()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minhajul\Downloads\mona\IOOP_Juice\ingredient.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "Select OrderID ,FoodID, Food_Name, Price, Quantity, Order_status, Total_Prices from [Order]";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderInfo = $" {reader["OrderID"]},{reader["FoodID"]}, {reader["Food_Name"]}, " +
                                               $" {reader["Quantity"]},  {reader["Price"]}, " +
                                               $"{reader["Order_status"]}, {reader["Total_Prices"]}";
                            listBoxOrder.Items.Add(orderInfo);


                        }
                    }
                }
            }
        }
        private void Edit_Order(string orderID, string NewStatus)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
            using (SqlConnection Edit_Order = new SqlConnection(connection))
            {
                Edit_Order.Open();
                string query = "Update [Order] set Order_status = @Status where OrderID = @OrderID";

                using ( SqlCommand cmd = new SqlCommand(query, Edit_Order))
                {
                    cmd.Parameters.AddWithValue("@Status", NewStatus.Trim());
                    cmd.Parameters.AddWithValue("@OrderID",orderID.Trim());

                    cmd.ExecuteNonQuery();
                }
                
            }
        }
        private void Order_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            View_Order();
        }


        

        private void listBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkLabelDisplay.Text = "";
            if (listBoxOrder.SelectedItem == null)
            {
                listBoxOrder.SelectedIndex = 0;
            }
            if (listBoxOrder.SelectedItems != null)
            {
                string item = listBoxOrder.SelectedItem.ToString();
                string orderID = item.Split(',')[0];
                string OrderFood = item.Split(',')[1];
                linkLabelOrderUpdate.Text = $"{orderID},{OrderFood}";
            }

            else { linkLabelDisplay.Text = "Please select order"; }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MainMenu obj = new MainMenu();
            obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Ingredient obj = new Ingredient();
            obj.Show();
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
            Profile obj = new Profile();
            obj.Show();
        }

        private void linkLabelOrderUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void radioButtonInProgress_CheckedChanged(object sender, EventArgs e)
        {
            linkLabelDisplay.Text = "";

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (listBoxOrder.SelectedItem != null)
            {
                string item = listBoxOrder.SelectedItem.ToString();
                string orderID = item.Split(',')[0];
                string orderFood = item.Split(',')[1];
                string orderStatus = item.Split(',')[5];


                if (linkLabelOrderUpdate.Text == $"{orderID},{orderFood}")
                    if (radioButtonInProgress.Checked)
                    {
                        orderStatus = "In Progress";
                        linkLabelDisplay.Text = $"Your order{orderID} have updated to " + orderStatus;
                    }
                    else if (radioButtonCompleted.Checked)
                    {
                        orderStatus = "Completed";
                        linkLabelDisplay.Text = $"Your order{orderID} have updated to " + orderStatus;
                    }
                    else
                    {
                        linkLabelDisplay.Text = "Please select status";
                    }
                            
                Edit_Order(orderID,orderStatus);
            }
            else { linkLabelDisplay.Text="Please select an order first"; }

            linkLabelOrderUpdate.Text = "OrderID,FoodID";
            listBoxOrder.Items.Clear();
            View_Order();




            
        }

        private void linkLabelDisplay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void radioButtonCompleted_CheckedChanged(object sender, EventArgs e)
        {
            linkLabelDisplay.Text = "";
        }
    }
}

