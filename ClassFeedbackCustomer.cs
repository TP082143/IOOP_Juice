using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    class ClassFeedbackCustomer
    {
        string connection = "@";
        public void CusFeedback(string u, string f)
        {
            using (SqlConnection CusFeedback = new SqlConnection(connection))
            {
                CusFeedback.Open();
                string query = "Insert into feedback(Username, Feedback) Values(@username,@feedback)";
                using (SqlCommand cmd = new SqlCommand(query, CusFeedback))
                {
                    cmd.Parameters.AddWithValue("@username", u);
                    cmd.Parameters.AddWithValue("@feedback", f);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Thank you for your valuable feedback! We truly appreciate your time and effort in sharing your thoughts with us");
            }
        }

    }
}
