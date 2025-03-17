using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class ManagerMainMenu : Form
    {
        public ManagerMainMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewHall obj = new ManagerViewHall();
            obj.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_Page obj = new Login_Page();
            obj.Show();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewMenu obj = new ManagerViewMenu();
            obj.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewMenu obj = new ManagerViewMenu();
            obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerAddHall obj = new ManagerAddHall();
            obj.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerReservationReport obj = new ManagerReservationReport();
            obj.Show();
        }

        private void DropDown ()
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

        private void label3_Click(object sender, EventArgs e)
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

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

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


        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
