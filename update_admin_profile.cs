using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment
{
    class update_admin_profile
    {
        private string username;

        public update_admin_profile(string username)
        {
            this.username = username;
        }

        public bool conPass(string username, string password)
        {
            bool status = false;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from staff where Username = @username and Password = @password and Role = @role", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", "Admin");

                int hold = Convert.ToInt32(cmd.ExecuteScalar());
                
                if(hold != 0)
                {
                    status = true;
                }
            }

            return status;
        }

        public static (string, bool) updatePass(string username, string password)
        {
            string line = null;
            bool status = false;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update staff set Password = @password where Username = @username", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int hold = cmd.ExecuteNonQuery();
                if(hold > 0)
                {
                    line = "Password is changed succesfully!";
                    status = true;
                }
                else
                {
                    line = "Password update failed!";
                }
            }
                return (line, status);
        }

        public static (string, bool) updateEmail(string username, string email)
        {
            string line = null;
            bool status = false;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update staff set Email = @email where Username = @username", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);

                int hold = cmd.ExecuteNonQuery();
                if (hold > 0)
                {
                    line = "Email is changed succesfully!";
                    status = true;
                }
                else
                {
                    line = "No data found!";
                }
            }
            return (line, status);
        }

    }
}
