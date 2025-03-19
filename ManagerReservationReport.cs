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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment
{
    public partial class ManagerReservationReport : Form
    {
        private string username;
        public ManagerReservationReport(string user)
        {
            InitializeComponent();
            username = user;
            label9.Text = username;
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

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewMenu obj = new ManagerViewMenu(username);
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

        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Huang\Documents\Assignment\Menu.mdf;Integrated Security=True";
        
        private void ViewReservation()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "Select Concat(Date,',',CusUsername,',',HallID,',',PartyType,',',NumPeople,',',Status) as Reservation from Reservation";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstReservation.Items.Add(reader["Reservation"]);
                        }
                    }
                }
            }
        }

        private void ViewSelect()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryMonth = "Select Concat(Date,',',CusUsername,',',HallID,',',PartyType,',',NumPeople,',',Status) as Reservation From Reservation Where Month(Date)=@date";
                string queryHall = "Select Concat(Date,',',CusUsername,',',HallID,',',PartyType,',',NumPeople,',',Status) as Reservation From Reservation Where HallID=@id";
                string queryAll = "Select Concat(Date,',',CusUsername,',',HallID,',',PartyType,',',NumPeople,',',Status) as Reservation From Reservation Where Month(Date)=@date and HallID=@id";
                if (cmbMonth.SelectedIndex != 0 && cmbHall.SelectedIndex != 0)
                {
                    using (SqlCommand cmd = new SqlCommand(queryAll, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", cmbMonth.SelectedIndex);
                        cmd.Parameters.AddWithValue("@id", cmbHall.SelectedItem.ToString());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lstReservation.Items.Add(reader["Reservation"]);
                            }
                        }
                    }
                }
                else if (cmbMonth.SelectedIndex != 0)
                {
                    using (SqlCommand cmd = new SqlCommand(queryMonth, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", cmbMonth.SelectedIndex);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lstReservation.Items.Add(reader["Reservation"]);
                            }
                        }
                    }
                }
                else if (cmbHall.SelectedIndex != 0)
                {
                    using (SqlCommand cmd = new SqlCommand(queryHall, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", cmbHall.SelectedItem.ToString());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lstReservation.Items.Add(reader["Reservation"]);
                            }
                        }
                    }
                }
            }
        }

        private void ManagerReservationReport_Load(object sender, EventArgs e)
        {
            ViewReservation();
            foreach (var x in lstReservation.Items)
            {
                string id = x.ToString().Split(',')[2].Trim();
                if (!cmbHall.Items.Contains(id))
                {
                    cmbHall.Items.Add(id);
                }
            }
            cmbHall.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstReservation.Items.Clear();
            if (cmbMonth.SelectedIndex == 0 && cmbHall.SelectedIndex ==0)
            {
                ViewReservation();
            }
            else
            {
                ViewSelect();
            }
        }

        private void cmbHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstReservation.Items.Clear();
            if (cmbMonth.SelectedIndex == 0 && cmbHall.SelectedIndex == 0)
            {
                ViewReservation();
            }
            else
            {
                ViewSelect();
            }
        }
    }
}
