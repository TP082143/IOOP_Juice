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
    public partial class ManagerViewHall : Form
    {
        public ManagerViewHall()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateOwnProfile obj = new UpdateOwnProfile();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdateOwnProfile obj = new UpdateOwnProfile();
            obj.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMainMenu obj = new ManagerMainMenu();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMainMenu obj = new ManagerMainMenu();
            obj.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewMenu obj = new ManagerViewMenu();
            obj.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerAddMenu obj = new ManagerAddMenu();
            obj.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerAddHall obj = new ManagerAddHall();
            obj.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerReservationReport obj = new ManagerReservationReport();
            obj.Show();
        }
        private void lblLogOut_Click(object sender, EventArgs e)
        {
            LoginPage obj = new LoginPage();
            obj.Show();
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
            txtCapacity.ReadOnly = true;
            txtParty.ReadOnly = true;
        }

        private void RefreshHall()
        {
            lstHall.Items.Clear();
            ShowHall();
            txtID.Clear();
            txtCapacity.Clear();
            txtParty.Clear();
        }

        private void ManagerViewHall_Load(object sender, EventArgs e)
        {
            ShowHall();
        }

        private void lstHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblShow.Text = "";
            string item = lstHall.SelectedItem.ToString();
            txtID.Text = item.Split(',')[0];
            txtCapacity.Text = item.Split(',')[1];
            txtParty.Text = item.Split(',')[2];
            txtCapacity.ReadOnly = false;
            txtParty.ReadOnly = false;
        }

        SQL s1 = new SQL();

        private void btnCapacity_Click(object sender, EventArgs e)
        {
            if (lstHall.SelectedItem ==null)
            {
                MessageBox.Show("Please choose one Hall", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (int.TryParse(txtCapacity.Text, out int cp))
                {
                    DialogResult result = MessageBox.Show($"Are you sure to edit Capacity {txtID.Text} to {txtCapacity.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lblShow.Text = s1.EditHallCapacity(txtID.Text, cp);
                        RefreshHall();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid Capacity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            if (lstHall.SelectedItem == null)
            {
                MessageBox.Show("Please choose one Hall", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtParty.Text == "")
                {
                    MessageBox.Show("Please enter valid value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Are you sure to edit Hall {txtID.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lblShow.Text = s1.EditHallParty(txtID.Text, lstHall.SelectedItem.ToString().Split(',')[2], txtParty.Text);
                        RefreshHall();
                    }
                }
            }
            
        } 
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstHall.SelectedItem == null)
            {
                MessageBox.Show("Please choose one Hall", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblShow.Text = s1.DeleteHall(txtID.Text, txtParty.Text);
                RefreshHall();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
