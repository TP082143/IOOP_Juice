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
using System.Collections;
using System.Configuration;
using static System.Windows.Forms.AxHost;

namespace Assignment
{
    public partial class Manager : Form
    {
        bool sideExpand, staffDropDown, imgBoolStaff, imgBoolUpdate, addManager, delManager, staffReservation, staffCustomer, updateProfile, boolSale, salePanel;
        string role = "Manager", user;
        addstaff addobj;
        editstaff editobj;
        int timeleft = 20;
        string ColVal;
        
        public Manager(string username)
        {
            InitializeComponent();
            ArrayList store = editstaff.GetData(role);

            foreach (var item in store)
            {
                lstViewUsername.Items.Add(item.ToString()+"\n");
            }
            this.WindowState = FormWindowState.Maximized;
            user = username;
        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'staffDataSet.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.staffDataSet.staff);
            // TODO: This line of code loads data into the 'staffDataSet.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.staffDataSet.staff);

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
        }

        

        private void btnStaffCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer form = new Customer(user);
            form.ShowDialog();
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
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxEmail.Clear();
            txtBoxFirst.Text = string.Empty;
            txtBoxLast.Text = string.Empty;
            txtBoxUsername.Text = string.Empty;
            txtBoxFirst.Focus();
        }

        private void lblUpdatePassTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateEmail form = new UpdateEmail(user);
            form.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string genValue = "null";
            if(!radioBtnMale.Checked && !radioBtnFemale.Checked && !radioBtnOther.Checked)
            {
                MessageBox.Show("The gender is not selected");
            }
            else
            {
                if (radioBtnMale.Checked)
                {
                    genValue = "Male";
                }
                else if (radioBtnFemale.Checked)
                {
                    genValue = "Female";
                }
                else
                    genValue = "Other";

                
                if (txtBoxEmail.Text.IndexOf('@') != -1)
                {
                    addobj = new addstaff(txtBoxFirst.Text, txtBoxLast.Text, txtBoxEmail.Text, txtBoxUsername.Text, genValue, role);
                    string stat = addobj.staffaddmethod();
                    if (stat != null)
                    {
                        if(stat == "0")
                        {
                            MessageBox.Show("Username existed!. Try another");
                            return;
                        }
                        else
                        {
                            MessageBox.Show(stat);
                            txtBoxFirst.Focus();
                            lblAddOut.Text = $"Username - {txtBoxUsername.Text}\nPassword - {txtBoxUsername.Text + "123"}";
                            lblAddOut.Visible = true;
                            timeleft = 20;
                            timeruserpassword.Start();
                            txtBoxEmail.Clear();
                            txtBoxFirst.Text = string.Empty;
                            txtBoxLast.Text = string.Empty;
                            txtBoxUsername.Text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is some problem! Try again.");
                        txtBoxFirst.Text = string.Empty;
                        txtBoxLast.Text = string.Empty;
                        txtBoxEmail.Text = string.Empty;
                        txtBoxUsername.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Enter a valid Email!");
                    return;
                }

                panelAddManager.Width = panelAddManager.MinimumSize.Width;
                panelAddManager.Height = panelAddManager.MinimumSize.Height;
            }
                
            
            
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
        }

        private void picBoxPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picBoxSelf_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Menu obj = new Admin_Menu(user);
            obj.ShowDialog();
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
            panelAddManager.Height += 10;
            panelAddManager.Width += 10;

            if (panelAddManager.Height == panelAddManager.MaximumSize.Height
                && panelAddManager.Width == panelAddManager.MaximumSize.Width)
            {
                timerAdd.Stop();
            }
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
            if(comboBoxSelection.SelectedIndex != -1)
            {
                switch (comboBoxSelection.SelectedIndex)
                {
                    case 0:
                        //for Edit Manager Section Disappear
                        panelEdit.Width = panelEdit.MinimumSize.Width;
                        panelEdit.Height = panelEdit.MinimumSize.Height;
                        //for Delete Manager Section Disappear
                        panelDelManager.Width = panelDelManager.MinimumSize.Width;
                        panelDelManager.Height = panelDelManager.MinimumSize.Height;

                        lstViewUsername.Width = lstViewUsername.MinimumSize.Width;
                        lstViewUsername.Height = lstViewUsername.MinimumSize.Height;

                        timerAdd.Start();
                        break;
                    case 1:
                        //for Add Manager Section Disappear
                        panelAddManager.Width = panelAddManager.MinimumSize.Width;
                        panelAddManager.Height = panelAddManager.MinimumSize.Height;
                        //for Delete Manager Section Disappear
                        panelDelManager.Width = panelDelManager.MinimumSize.Width;
                        panelDelManager.Height = panelDelManager.MinimumSize.Height;

                        ArrayList store = editstaff.GetData(role);
                        lstViewUsername.Items.Clear();
                        foreach (var item in store)
                        {
                            lstViewUsername.Items.Add(item.ToString() + "\n");
                        }

                        lstViewUsername.Width = lstViewUsername.MaximumSize.Width;
                        lstViewUsername.Height = lstViewUsername.MaximumSize.Height;

                        timerEdit.Start();
                        break;
                    case 2:
                        //for Add Manager Section Disappear
                        panelAddManager.Width = panelAddManager.MinimumSize.Width;
                        panelAddManager.Height = panelAddManager.MinimumSize.Height;
                        //for Edit Manager Section Disappear
                        panelEdit.Width = panelEdit.MinimumSize.Width;
                        panelEdit.Height = panelEdit.MinimumSize.Height;

                        store = editstaff.GetDatawithEmail(role);
                        lstViewUsername.Items.Clear();
                        foreach (var item in store)
                        {
                            lstViewUsername.Items.Add(item.ToString() + "\n");
                        }

                        lstViewUsername.Width = lstViewUsername.MaximumSize.Width;
                        lstViewUsername.Height = lstViewUsername.MaximumSize.Height;

                        timerDel.Start();
                        break;
                    default:
                        MessageBox.Show("Nothing is selected!");
                        break;
                }
            }
            else
                MessageBox.Show("Nothing is selected!");
        }

        private void btnDelReset_Click(object sender, EventArgs e)
        {
            txtBoxDelEmail.Clear();
            txtBoxDelUsername.Text = string.Empty;
        }

        private void timerDelManager_Tick(object sender, EventArgs e)
        {
            panelDelManager.Height += 10;
            panelDelManager.Width += 10;

            if (panelDelManager.Height == panelDelManager.MaximumSize.Height
                && panelDelManager.Width == panelDelManager.MaximumSize.Width)
            {
                timerDel.Stop();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        //NEW METHOD FOR UPDATE DETAILS
        private string getInfo()
        {
            List<string> store = new List<string>();
            string value = null;
            string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            if (ColVal != "Username")
            {
                string username = txtBoxFindUser.Text;
                SqlConnection con = new SqlConnection(connectionStrings);
                con.Open();
                SqlCommand cmd = new SqlCommand("select First_Name, Last_Name, Username, Email, Password, Gender from staff where Username = @u", con);
                cmd.Parameters.AddWithValue("@u", username);
                SqlDataReader read = cmd.ExecuteReader();
                if(read.Read())
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

        private void button2_Click(object sender, EventArgs e)
        {
            editobj = new editstaff(txtBoxFindUser.Text, role);
            if (editobj.GetUser())
            {
                MessageBox.Show("Username Found!");

                lstViewUsername.Items.Clear();
                lstViewUsername.Width = lstViewUsername.MinimumSize.Width;
                lstViewUsername.Height = lstViewUsername.MinimumSize.Height;

                lblOutputData.Text = getInfo();

                panelEditInner.Height = panelEditInner.MaximumSize.Height;
                panelEditInner.Width = panelEditInner.MaximumSize.Width;
            }
            else
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelEditInner.Height = panelEditInner.MinimumSize.Height;
                panelEditInner.Width = panelEditInner.MinimumSize.Width;
            }
        }

        private void timerEdit_Tick(object sender, EventArgs e)
        {
            panelEdit.Height += 10;
            panelEdit.Width += 10;

            if (panelEdit.Height == panelEdit.MaximumSize.Height
                && panelEdit.Width == panelEdit.MaximumSize.Width)
            {
                timerEdit.Stop();
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (editstaff.EditCol(ColVal, txtBoxFindUser.Text, txtBoxUpdateData.Text, role))
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
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void staffBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.staffBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.staffDataSet);

        }

        private void staffBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.staffBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.staffDataSet);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Month obj = new Sales_Month(user);
            obj.ShowDialog();
        }

        private void userpassword_Tick(object sender, EventArgs e)
        {
            timeleft--;
            if(timeleft <= 0)
            {
                lstViewUsername.Visible = false;
                lblOutputData.Visible = false;
                lblAddOut.Visible = false;
                timeruserpassword.Stop();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstViewUsername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBoxDelEmail.Text != "" && txtBoxDelUsername.Text != "")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (editstaff.DelUser(txtBoxDelUsername.Text, txtBoxDelEmail.Text))
                    {
                        MessageBox.Show("User has been deleted successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ArrayList store = new ArrayList();
                        store = editstaff.GetDatawithEmail(role);
                        lstViewUsername.Items.Clear();
                        foreach (var item in store)
                        {
                            lstViewUsername.Items.Add(item.ToString() + "\n");
                        }
                        lstViewUsername.Visible = true;
                        timeleft = 20;
                        timeruserpassword.Start();
                    }
                    else
                        MessageBox.Show("Data has not been found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Username or Email is not filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChef_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Chef obj = new Sales_Chef(user);
            obj.ShowDialog();
        }

        private void txtBoxFindUser_TextChanged(object sender, EventArgs e)
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
