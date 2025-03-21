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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Maximized;
           
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
            Profile obj = new Profile();
            obj.Show();
            
        }

        private void labelOrder_Click(object sender, EventArgs e)
        {
            Order obj = new Order();
            obj.Show();
        }

        

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Ingredient obj = new Ingredient();
            obj.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
