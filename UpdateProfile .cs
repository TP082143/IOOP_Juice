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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Assignment
{
    public partial class UpdateProfile: Form
    {
        bool sideExpand, staffDropDown, imgBoolStaff, imgBoolUpdate, staffManager, staffChef, staffReservation, staffCustomer, updateProfile, boolSale, salePanel;
        string user, ColVal = null;
        int timeleft = 20;
        public UpdateProfile(string username)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnReset_Click(object sender, EventArgs e)
        {

        }
        private void txtBoxFindUser_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnEditFind_Click(object sender, EventArgs e)
        {

        }
        private void txtBoxUpdateData_TextChanged(object sender, EventArgs e)
        {

        }
        private void panelEdit_Paint(object sender, PaintEventArgs e)
        {

        }
        private void lblUpdatePassTitle_Click(object sender, EventArgs e)
        {

        }

        private void picMenuBar_Click(object sender, EventArgs e)
        {
            sidePanelTimer.Start();
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
        private void timeruserpassword_Tick(object sender, EventArgs e)
        {
            timeleft--;
            if (timeleft <= 0)
            {
                lblOutputData.Visible = false;
                timeruserpassword.Stop();
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
            Reservation obj = new Reservation(user);
            obj.ShowDialog();
        }
        private void btnStaffCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer obj = new Customer(user);
            obj.ShowDialog();
        }
        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateEmail form = new UpdateEmail(user);
            form.ShowDialog();
        }
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePassword form = new UpdatePassword(user);
            form.ShowDialog();
        }
        private void btnMonth_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Month obj = new Sales_Month(user);
            obj.ShowDialog();
        }
        private void btnChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Chef obj = new Sales_Chef(user);
            obj.ShowDialog();
        }
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile obj = new UpdateProfile(user);
            obj.ShowDialog();
        }

        private void btnManagerAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager obj = new Manager(user);
            obj.ShowDialog();
        }

        private void picBoxSelf_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Menu obj = new Admin_Menu(user);
            obj.ShowDialog();
        }
        private void btnStaffChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chef obj = new Chef(user);
            obj.ShowDialog();
        }

        private void comboBoxEditOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditOption.SelectedItem != null)
            {
                panelEditData.Height = panelEditData.MaximumSize.Height;
                panelEditData.Width = panelEditData.MaximumSize.Width;
                switch (comboBoxEditOption.SelectedItem)
                {
                    case "First Name":
                        lblEditSelection.Text = "First Name";
                        ColVal = "First_Name";
                        break;
                    case "Last Name":
                        lblEditSelection.Text = "Last Name";
                        ColVal = "Last_Name";
                        break;
                    case "Username":
                        lblEditSelection.Text = "Username";
                        ColVal = "Username";
                        break;
                    case "Email":
                        lblEditSelection.Text = "Email";
                        ColVal = "Email";
                        break;
                    case "Password":
                        lblEditSelection.Text = "Password";
                        ColVal = "Password";
                        break;
                    case "Gender":
                        lblEditSelection.Text = "Gender";
                        ColVal = "Gender";
                        break;
                }
            }
        }
        private string getInfo()
        {
            List<string> store = new List<string>();
            string value = null;
            string connectionStrings = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study\APU\2nd sem\IOOP\Assignment\Assignment\Home Page, Login & Admin\Assignment\Admin_Database.mdf;Integrated Security = True";

            if (ColVal != "Username")
            {
                string username = user;
                SqlConnection con = new SqlConnection(connectionStrings);
                con.Open();
                SqlCommand cmd = new SqlCommand("select First_Name, Last_Name, Username, Email, Password, Gender from staff where Username = @u", con);
                cmd.Parameters.AddWithValue("@u", username);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        store.Add(read[i].ToString());
                    }
                }
                con.Close();
                return value = $"First Name - {store[0]}\nLast Name - {store[1]}\nUsername - {store[2]}\nEmail - {store[3]}\nPassword - {store[4]}\nGender - {store[5]}";
            }
            else
            {
                string username = txtBoxUpdateData.Text;
                SqlConnection con = new SqlConnection(connectionStrings);
                con.Open();
                SqlCommand cmd = new SqlCommand("select First_Name, Last_Name, Username, Email, Password, Gender from staff where Username = @u", con);
                cmd.Parameters.AddWithValue("@u", username);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        store.Add(read[i].ToString());
                    }
                }
                con.Close();
                return value = $"First Name - {store[0]}\nLast Name - {store[1]}\nUsername - {store[2]}\nEmail - {store[3]}\nPassword - {store[4]}\nGender - {store[5]}";
            }
        }
        private void btnEditSubmit_Click(object sender, EventArgs e)
        {
            if (txtBoxUpdateData.Text != "")
            {
                if (editstaff.EditCol(ColVal, user, txtBoxUpdateData.Text, "Admin"))
                {
                    MessageBox.Show("Updated Successfully!");

                    timeleft = 10;
                    lblOutputData.Visible = true;
                    timeruserpassword.Start();
                    lblOutputData.Text = getInfo();

                    panelEdit.Height = panelEdit.MinimumSize.Height;
                    panelEdit.Width = panelEdit.MinimumSize.Width;
                }
                else
                    MessageBox.Show("Could not Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picBoxPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}
