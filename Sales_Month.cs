using System;
using System.Collections;
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
    public partial class Sales_Month : Form
    {
        bool sideExpand, staffDropDown, imgBoolStaff, imgBoolUpdate, addManager, delManager, staffReservation, staffCustomer, updateProfile, boolSale, salePanel;
        double sum = 0;
        string user;
        public Sales_Month(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            user = username;
        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Menu form = new Admin_Menu(user);
            form.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void picMenuBar_Click(object sender, EventArgs e)
        {
            sidePanelTimer.Start();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Manager form = new Manager(user);
            form.ShowDialog();
            this.Close();
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

        private void btnStaffReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservation form = new Reservation(user);
            form.ShowDialog();
            this.Close();
        }

        

        private void btnStaffCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer form = new Customer(user);
            form.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            timerUpdate.Start();
            if(imgBoolUpdate)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void lblUpdatePassTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateEmail form = new UpdateEmail(user);
            form.ShowDialog();
            this.Close();
        }

        

        private void txtBoxPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxNewEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePassword form = new UpdatePassword(user);
            form.ShowDialog();
            this.Close();
        }

        private void picBoxPower_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBoxSelf_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Menu obj = new Admin_Menu(user);
            obj.ShowDialog();
            this.Close();
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

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile obj = new UpdateProfile(user);
            obj.ShowDialog();
        }

        private void timerAddManager_Tick(object sender, EventArgs e)
        {
           
        }

        private void panelAddManager_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManagerAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnManagerEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnManagerDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnChefAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnChefEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnChefDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnReservationAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnReservationEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnReservationDelete_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void timerDelManager_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void timerEdit_Tick(object sender, EventArgs e)
        {
            
        }

       

        private void comboBoxEditOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelInnerAdd_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showDataGrid(string month, string year)
        {
            var (dbl, sum) = salesreport.salesReportMonth(month, year);
            if (dbl.Rows.Count > 0)
            {
                dataGridMY.Font = new Font("Segoe UI", 14);
                dataGridMY.DataSource = dbl;
                if (sum != 0)
                    lblSum.Text = $"Total - RM {sum}";
            }
            else
                MessageBox.Show("There is no data!", "Findings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string nul = "-1";
            if (comboBoxMonth.SelectedIndex != -1 && comboBoxYear.SelectedIndex != -1)
            {
                showDataGrid(comboBoxMonth.SelectedItem.ToString(), comboBoxYear.SelectedItem.ToString());
            }
            else if (comboBoxMonth.SelectedIndex != -1)
            {
                showDataGrid(comboBoxMonth.SelectedItem.ToString(), nul);
            }
            else if(comboBoxYear.SelectedIndex != -1)
            {
                showDataGrid(nul, comboBoxYear.SelectedItem.ToString());
            }
            else
                MessageBox.Show("Nothing is selected!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridMY_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridMY_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clears selection
            comboBoxMonth.SelectedIndex = -1; 
            comboBoxYear.SelectedIndex = -1;
            dataGridMY.DataSource = null;
            lblSum.Text = string.Empty;
        }

        private void btnChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Chef obj = new Sales_Chef(user);
            obj.ShowDialog();
        }

        private void panelSalesReport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {

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

        private void pictureArrowUpdate_Click(object sender, EventArgs e)
        {
            timerSales.Start();
            if(boolSale)
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

        private void picArrowUpdate_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            if(imgBoolUpdate)
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
            if(updateProfile)
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
            if(staffDropDown)
            {
                panelStaffContainer.Height += 10;
                if(panelStaffContainer.Height == panelStaffContainer.MaximumSize.Height)
                {
                    staffDropDown = false;
                    dropDownPanelStaff.Stop();
                }
            }
            else
            {
                panelStaffContainer.Height -= 10;
                if(panelStaffContainer.Height == panelStaffContainer.MinimumSize.Height)
                {
                    staffDropDown = true;
                    dropDownPanelStaff.Stop();
                }
            }
        }

        

        

        private void btnStaffChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chef form = new Chef(user);
            form.ShowDialog();
        }

    }
}
