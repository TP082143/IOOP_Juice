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
    public partial class EditReservation : Form
    {
        private string username;
        public EditReservation(string user)
        {
            InitializeComponent();
            username = user;
            label1.Text = username;
        }

        private void EditReservation_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
