using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Check_Status_customer: Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;";

        public Check_Status_customer()
        {
            InitializeComponent();
        }

        private void Check_Status_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            using (SqlConnection status = new SqlConnection(connection))
            {
                status.Open();
                string queryHall = "Select (CusUsername, Contact, HallID, Capacity, NumPeople, PartyType, Date, TimeStart, TimeEnd, Status) as Checkreservation where CusUsername=@username";
                using (SqlCommand cmd = new SqlCommand(queryHall, status))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.Parameters.AddWithValue("@username", lblUser.Text);
                        cmd.ExecuteNonQuery();
                        while (reader.Read())
                        {
                            lstCheck.Items.Add(reader["Checkreservation"]);
                        }
                    }

                }

            }
        }
    }
}
