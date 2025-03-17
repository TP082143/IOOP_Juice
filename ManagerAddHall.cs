using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Assignment
{
    public partial class ManagerAddHall : Form
    {
        public ManagerAddHall()
        {
            InitializeComponent();
        }

        private void ManagerAddHall_Load(object sender, EventArgs e)
        {

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

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewHall obj = new ManagerViewHall();
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

        SQL s1 = new SQL();

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtHallID.Text == "" || txtCapacity.Text == "" || txtParty.Text == "")
            {
                MessageBox.Show("Please enter all value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.TryParse(txtCapacity.Text, out int cp))
            {
                DialogResult result = MessageBox.Show($"Are you sure to add Item:\nHallID: {txtHallID.Text}\nCapacity: {txtCapacity.Text}\nParty Type: {txtParty.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    char x = txtHallID.Text.ToUpper()[0];
                    if (x.ToString() == "H")
                     {
                        lblShow.Text = s1.AddHall(txtHallID.Text, cp, txtParty.Text);
                        txtHallID.Clear();
                        txtCapacity.Clear();
                        txtParty.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid HallID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid Capacity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
