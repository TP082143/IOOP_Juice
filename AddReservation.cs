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
    public partial class AddReservation : Form
    {
        public AddReservation()
        {
            InitializeComponent();
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
        }

        private void AddReservation_Load(object sender, EventArgs e)
        {
            ShowHall();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblStart.Text) >= 1000 && int.Parse(lblStart.Text) < 2200)
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
            if (int.Parse(lblStart.Text) >1000)
            {
                lblStart.Text = (int.Parse(lblStart.Text) - 100).ToString();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblEnd.Text) > int.Parse(lblStart.Text) && int.Parse(lblEnd.Text) < 2300)
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
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            if (txtName.Text =="" || txtNumber.Text =="")
            {
                MessageBox.Show("Please enter all value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.TryParse(txtNumber.Text,out int nb))
            {
                DialogResult result = MessageBox.Show($"Are you sure to add Item:\nHall: {txtHall.Text}\nNumber: {txtNumber.Text}\nDate: {dtpDate}\nTime:{lblStart.Text} to {lblEnd.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (nb <= int.Parse(lstHall.SelectedItem.ToString().Split(',')[1]))
                    {
                        
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
    }
}
