using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment
{  
    public partial class AddReservation : Form
    {
        private string username;
        public AddReservation(string user)
        {
            InitializeComponent();
            username = user;
            label1.Text = username;
        }

        private void ShowHall()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Huang\Documents\Assignment\Menu.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryHall = "Select Concat(HallID,',',Capacity,',',PartyType) as Hall From Hall";
                using (SqlCommand cmd = new SqlCommand(queryHall, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstHall.Items.Add(reader["Hall"]);
                        }
                    }
                }
                conn.Close();
            }
            txtName.ReadOnly = true;
            txtNumber.ReadOnly = true;
            txtContact.ReadOnly = true;
        }

        private void AddReservation_Load(object sender, EventArgs e)
        {
            ShowHall();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblStart.Text) >= 1200 && int.Parse(lblStart.Text) < 2100)
            {
                lblStart.Text = (int.Parse(lblStart.Text) + 100).ToString();
                if (int.Parse(lblEnd.Text) == int.Parse(lblStart.Text))
                {
                    lblEnd.Text = (int.Parse(lblStart.Text) + 100).ToString();
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblStart.Text) > 1200)
            {
                lblStart.Text = (int.Parse(lblStart.Text) - 100).ToString();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblEnd.Text) > int.Parse(lblStart.Text) && int.Parse(lblEnd.Text) < 2100)
            {
                lblEnd.Text = (int.Parse(lblEnd.Text) + 100).ToString();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblEnd.Text) > int.Parse(lblStart.Text))
            {
                lblEnd.Text = (int.Parse(lblEnd.Text) - 100).ToString();
                if (int.Parse(lblEnd.Text) == int.Parse(lblStart.Text))
                {
                    lblEnd.Text = (int.Parse(lblStart.Text) + 100).ToString();
                }
            }
        }

        private void lstHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHall.Text = lstHall.SelectedItem.ToString();
            txtName.ReadOnly = false;
            txtNumber.ReadOnly = false;
            txtContact.ReadOnly = false;
        }
        SQL S1 = new SQL();
        private void btnParty_Click(object sender, EventArgs e)
        {
            if (txtHall.Text == "" || txtName.Text =="" || txtNumber.Text =="")
            {
                MessageBox.Show("Please enter all value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.TryParse(txtNumber.Text,out int nb) && int.TryParse(txtContact.Text,out int ct))
            {
                DialogResult result = MessageBox.Show($"Are you sure to add Item:\nHall: {txtHall.Text}\nNumber: {txtNumber.Text}\nDate: {dtpDate.Text}\nTime:{lblStart.Text} to {lblEnd.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (nb <= int.Parse(lstHall.SelectedItem.ToString().Split(',')[1]))
                    {
                        string item = lstHall.SelectedItem.ToString();
                        lblShow.Text = S1.AddReservation(txtName.Text, int.Parse(txtContact.Text), item.Split(',')[0], int.Parse(item.Split(',')[1]), item.Split(',')[2], int.Parse(txtNumber.Text), dtpDate.Text, int.Parse(lblStart.Text), int.Parse(lblEnd.Text));
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid number of People", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage obj = new LoginPage();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
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
            ReservationMainMenu obj = new ReservationMainMenu(username);
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            ReservationMainMenu obj = new ReservationMainMenu(username);
            obj.Show();
        }

        private void lblHall_Click(object sender, EventArgs e)
        {
            this.Close();
            EditReservation obj = new EditReservation(username);
            obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            ReservationStatus obj = new ReservationStatus(username);
            obj.Show();
        }
    }
}
