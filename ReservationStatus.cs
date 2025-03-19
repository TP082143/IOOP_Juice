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
    public partial class ReservationStatus : Form
    {
        private string username;
        public ReservationStatus(string user)
        {
            InitializeComponent();
            username = user;
            label1.Text = username;
        }

        private void ReservationStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
