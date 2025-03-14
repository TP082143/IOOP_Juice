using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment
{
    class addstaff
    {
        private string firstn, lastn, email, username, gender, role;

        public addstaff(string firstn, string lastn, string email, string username, string gender, string role)
        {
            this.firstn = firstn;
            this.lastn = lastn;
            this.email = email;
            this.username = username;
            this.gender = gender;
            this.role = role;
        }

        public string staffaddmethod()
        {
            string password = $"{username}123";
            string status = null;
            string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionStrings);
            con.Open();

            SqlCommand chec = new SqlCommand("select count(*) from staff where Username = @u", con);
            chec.Parameters.AddWithValue("@u", username);

            int count = (int)chec.ExecuteScalar();
            if(count > 0)
            {
                return status = "0";
            }
            else
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO staff (First_Name, Last_Name, Username, Email, Password, Gender, Role) VALUES (@first, @last, @user, @email, @password, @gender, @role)", con);
                    cmd.Parameters.AddWithValue("@first", firstn);
                    cmd.Parameters.AddWithValue("@last", lastn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);

                    int affectedRow = cmd.ExecuteNonQuery();

                    if (affectedRow != 0)
                    {
                        status = "Successfully Added!";
                    }
                    else
                        status = "Unable to add data!";


                }
                catch (SqlException mess)
                {
                    return mess.ToString();
                }

            con.Close();

            return status;
        }

    }
}
