using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment; 

namespace Assignment
{
    public partial class Admin_Menu : Form
    {
        bool sideExpand, staffDropDown, imgBoolStaff, imgBoolUpdate, staffManager, staffChef, staffReservation, staffCustomer, updateProfile, boolSale, salePanel;
        public string first_name, last_name, user;

        public Admin_Menu(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            user = username;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void lblAdminWelcome_Click(object sender, EventArgs e)
        {

        }
        private void picBoxSelf_Click(object sender, EventArgs e)
        {

        }
        private void picMenuBar_Click(object sender, EventArgs e)
        {
            sidePanelTimer.Start();
        }
        private void Admin_Menu_Load(object sender, EventArgs e)
        {
            if (first_name != null)
            {
                lblAdminWelcome.Text = $"Welcome {first_name} {last_name}!";
            }
            else
                lblAdminWelcome.Text = "Welcome!";
        }
        private void btnStaff_Click(object sender, EventArgs e)
        {
            dropDownPanelStaff.Start();
            if (imgBoolStaff)
            {
                picArrowStaff.Image = imageArrowList.Images[1];
                imgBoolStaff = false;
            }
            else
            {
                picArrowStaff.Image = imageArrowList.Images[0];
                imgBoolStaff = true;
            }
        }
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            timerUpdate.Start();
            if (imgBoolUpdate)
            {
                picArrowUpdate.Image = imageArrowList.Images[1];
                imgBoolUpdate = false;
            }
            else
            {
                picArrowUpdate.Image = imageArrowList.Images[0];
                imgBoolUpdate = true;
            }
        }
        private void picArrowSale_Click(object sender, EventArgs e)
        {
            timerSales.Start();
            if (boolSale)
            {
                picArrowSale.Image = imageArrowList.Images[1];
                boolSale = false;
            }
            else
            {
                picArrowSale.Image = imageArrowList.Images[0];
                boolSale = true;
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            timerSales.Start();
            if (boolSale)
            {
                picArrowSale.Image = imageArrowList.Images[1];
                boolSale = false;
            }
            else
            {
                picArrowSale.Image = imageArrowList.Images[0];
                boolSale = true;
            }
        }
        private void timerSales_Tick(object sender, EventArgs e)
        {
            if (salePanel)
            {
                panelSalesReport.Height += 10;
                if (panelSalesReport.Height == panelSalesReport.MaximumSize.Height)
                {
                    timerSales.Stop();
                    salePanel = false;
                }
            }
            else
            {
                panelSalesReport.Height -= 10;
                if (panelSalesReport.Height == panelSalesReport.MinimumSize.Height)
                {
                    timerSales.Stop();
                    salePanel = true;
                }
            }
        }
        private void picArrowUpdate_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            if (imgBoolUpdate)
            {
                picArrowUpdate.Image = imageArrowList.Images[1];
                imgBoolUpdate = false;
            }
            else
            {
                picArrowUpdate.Image = imageArrowList.Images[0];
                imgBoolUpdate = true;
            }
        }
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (updateProfile)
            {
                panelUpdate.Height += 10;
                if (panelUpdate.Height == panelUpdate.MaximumSize.Height)
                {
                    timerUpdate.Stop();
                    updateProfile = false;
                }
            }
            else
            {
                panelUpdate.Height -= 10;
                if (panelUpdate.Height == panelUpdate.MinimumSize.Height)
                {
                    timerUpdate.Stop();
                    updateProfile = true;
                }
            }
        }
        private void picArrowDown_Click(object sender, EventArgs e)
        {
            dropDownPanelStaff.Start();
            if (imgBoolStaff)
            {
                picArrowStaff.Image = imageArrowList.Images[1];
                imgBoolStaff = false;
            }
            else
            {
                picArrowStaff.Image = imageArrowList.Images[0];
                imgBoolStaff = true;
            }
        }
        private void dropDownPanelStaff_Tick(object sender, EventArgs e)
        {
            if (staffDropDown)
            {
                panelStaffContainer.Height += 10;
                if (panelStaffContainer.Height == panelStaffContainer.MaximumSize.Height)
                {
                    staffDropDown = false;
                    dropDownPanelStaff.Stop();
                }
            }
            else
            {
                panelStaffContainer.Height -= 10;
                if (panelStaffContainer.Height == panelStaffContainer.MinimumSize.Height)
                {
                    staffDropDown = true;
                    dropDownPanelStaff.Stop();
                }
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sideExpand)
            {
                sidePanel.Width -= 10;
                if(sidePanel.Width == sidePanel.MinimumSize.Width)
                {
                    sideExpand = false;
                    sidePanelTimer.Stop();
                }
            }
            else
            {
                sidePanel.Width += 10;
                if (sidePanel.Width == sidePanel.MaximumSize.Width)
                {
                    sideExpand = true;
                    sidePanelTimer.Stop();
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Manager obj = new Manager(user);
            obj.ShowDialog();
        }
        private void btnStaffReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservation form = new Reservation(user);
            form.ShowDialog();
        }
        private void btnStaffCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer form = new Customer(user);
            form.ShowDialog();
        }
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePassword form = new UpdatePassword(user);
            form.ShowDialog();
        }
        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateEmail form = new UpdateEmail(user);
            form.ShowDialog();
        }
        private void btnChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Chef obj = new Sales_Chef(user);
            obj.ShowDialog();
        }
        private void btnMonth_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Month obj = new Sales_Month(user);
            obj.ShowDialog();
        }
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile obj = new UpdateProfile(user);
            obj.ShowDialog();
        }
        private void btnStaffChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chef form = new Chef(user);
            form.ShowDialog();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void picBoxPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
