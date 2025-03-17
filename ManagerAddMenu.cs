using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class ManagerAddMenu : Form
    {
        public ManagerAddMenu()
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMainMenu obj = new ManagerMainMenu();
            obj.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMainMenu obj = new ManagerMainMenu();
            obj.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewHall obj = new ManagerViewHall();
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
            this.Close();
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

        private void lblReservation_Click_1(object sender, EventArgs e)
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


        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerViewMenu obj = new ManagerViewMenu();
            obj.Show();
        }

        SQL s1 = new SQL();


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFoodID.Text=="" || txtName.Text=="" || txtPrice.Text=="")
            {
                MessageBox.Show("Please enter all value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            else if (double.TryParse(txtPrice.Text, out double pr))
            {
                DialogResult result = MessageBox.Show($"Are you sure to add Item:\nID: {txtFoodID.Text}\nName: {txtName.Text}\nPrice: {txtPrice.Text}", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    char x = txtFoodID.Text.ToUpper()[0];
                    if (rdbFood.Checked)
                    {                       
                        if (x.ToString() == "F")
                        {
                            bool IsFood = true;
                            lblShow.Text = s1.AddMenu(IsFood, txtFoodID.Text, txtName.Text, pr);
                            txtFoodID.Clear();
                            txtName.Clear();
                            txtPrice.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid FoodID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                    else if (rdbDrink.Checked)
                    {
                        if (x.ToString() == "D")
                        {
                            bool IsFood = false;
                            lblShow.Text = s1.AddMenu(IsFood, txtFoodID.Text, txtName.Text, double.Parse(txtPrice.Text));
                            txtFoodID.Clear();
                            txtName.Clear();
                            txtPrice.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please choose one category");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
