using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment
{
    public partial class ManagerViewMenu : Form
    {
        private string username;
        public ManagerViewMenu(string user)
        {
            InitializeComponent();
            username = user;
            label9.Text = username;
        }

        private void DropDown()
        {
            pnlMenu.Visible = false;
            pnlHall.Visible = false;
            pnlReservation.Visible = false;

            lblMenu.Location = new Point(7, 165);
            lblHall.Location = new Point(7, 210);
            lblReservation.Location = new Point(7, 255);

            pnlMenu.Location = new Point(30, lblMenu.Bottom + 10);
            pnlHall.Location = new Point(30, lblHall.Bottom + 10);
            pnlReservation.Location = new Point(30, lblReservation.Bottom + 10);

            lblMenu.Text = "• Menu            ▼";
            lblHall.Text = "• Hall Detail    ▼";
            lblReservation.Text = "• Reservation ▼";
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Visible == true)
            {
                DropDown();
            }
            else
            {
                DropDown();
                lblMenu.Text = "• Menu            ▲";
                pnlMenu.Visible = !pnlMenu.Visible;
                lblHall.Location = new Point(7, pnlMenu.Bottom + 5);
                lblReservation.Location = new Point(7, lblHall.Bottom + 16);
            }
        }

        private void lblHall_Click(object sender, EventArgs e)
        {
            if (pnlHall.Visible == true)
            {
                DropDown();
            }
            else
            {
                DropDown();
                lblHall.Text = "• Hall Detail    ▲";
                pnlHall.Visible = !pnlHall.Visible;
                lblReservation.Location = new Point(7, pnlHall.Bottom + 5);
            }
        }

        private void lblReservation_Click(object sender, EventArgs e)
        {
            if (pnlReservation.Visible == true)
            {
                DropDown();
            }
            else
            {
                DropDown();
                lblReservation.Text = "• Reservation ▲";
                pnlReservation.Visible = !pnlReservation.Visible;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateOwnProfile obj = new UpdateOwnProfile(username);
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateOwnProfile obj = new UpdateOwnProfile(username);
            obj.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMainMenu obj = new ManagerMainMenu(username);
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMainMenu obj = new ManagerMainMenu(username);
            obj.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage obj = new LoginPage();
            obj.Show();
        }


        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerAddMenu obj = new ManagerAddMenu(username);
            obj.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewHall obj = new ManagerViewHall(username);
            obj.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerAddHall obj = new ManagerAddHall(username);
            obj.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerReservationReport obj = new ManagerReservationReport(username);
            obj.Show();
        }

        SQL s1 = new SQL();

        private void ShowOrder()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Huang\Documents\Assignment\Menu.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryFood = "Select Concat(FoodID,',',FName,',',FPrice) as Food from Food";
                string queryDrink = "Select Concat(FoodID,',',DName,',',DPrice) as Drink from Drink";

                using (SqlCommand cmd = new SqlCommand(queryFood, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstFood.Items.Add(reader["Food"]);
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand(queryDrink, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstFood.Items.Add(reader["Drink"]);
                        }
                    }
                }
            }
            txtName.ReadOnly = true;
            txtPrice.ReadOnly = true;
        }
        private void ManagerViewMenu_Load(object sender, EventArgs e)
        {
            ShowOrder();
        }

        private void lstFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblShow.Text = "";
            string item = lstFood.SelectedItem.ToString();
            txtID.Text = item.Split(',')[0];
            txtName.Text = item.Split(',')[1];
            txtPrice.Text = item.Split(',')[2];
            char category = txtID.Text[0];
            if (category.ToString() == "F")
            {
                txtCategory.Text = "Food";
            }
            else if (category.ToString() == "D")
            {
                txtCategory.Text = "Drink";
            }
            txtName.ReadOnly = false;
            txtPrice.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstFood.SelectedItem ==null)
            {
                MessageBox.Show("Please choose one Item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtName.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Please enter all value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (double.TryParse(txtPrice.Text, out double pr))
                {
                    DialogResult result = MessageBox.Show($"Are you sure to edit item {txtID.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lblShow.Text = s1.EditMenu(txtCategory.Text, txtID.Text, txtName.Text, double.Parse(txtPrice.Text));
                        lstFood.Items.Clear();
                        ShowOrder();
                        txtCategory.Clear();
                        txtID.Clear();
                        txtName.Clear();
                        txtPrice.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lstFood.SelectedItem == null)
            {
                MessageBox.Show("Please choose one Item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show($"Are you sure to delete item {txtID.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    s1.DeleteMenu(txtCategory.Text, txtID.Text);
                    lstFood.Items.Clear();
                    ShowOrder();
                    txtCategory.Clear();
                    txtID.Clear();
                    txtName.Clear();
                    txtPrice.Clear();
                }  
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
