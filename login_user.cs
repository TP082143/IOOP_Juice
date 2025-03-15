using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Assignment
{
    class login_user
    {
        private string username;
        private string password;
        public string first_name, last_name;

        public login_user(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string login()
        {
            int count2 = 0;
            string status = null;
            List<string> login_detail = new List<string>();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("select count(*) from staff where Username = @u and Password = @p", con);
            cmd1.Parameters.AddWithValue("@u", username);
            cmd1.Parameters.AddWithValue("@p", password);

            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
            if(count1 == 0)
            {
                SqlCommand cmd2 = new SqlCommand("select count(*) from staff where Email = @e and Password = @p", con);
                cmd2.Parameters.AddWithValue("@e", username);
                cmd2.Parameters.AddWithValue("@p", password);

                count2 = Convert.ToInt32(cmd2.ExecuteScalar());
                if(count2 > 0)
                {
                    SqlCommand cmd3 = new SqlCommand("select Username from staff where Email = @e and Password = @p", con);
                    cmd3.Parameters.AddWithValue("@e", username);
                    cmd3.Parameters.AddWithValue("@p", password);

                    SqlDataReader read = cmd3.ExecuteReader();
                    if (read.Read())
                        username = read["Username"].ToString();
                    read.Close();
                }
            }
            
            if (count1 > 0 || count2 > 0)
            {
                status = "found";

                login_detail.Add(username);
                login_detail.Add(password);

                SqlCommand cmd4 = new SqlCommand("select First_Name, Last_Name, Username, Role from staff where Username = @u and Password = @p", con);
                cmd4.Parameters.AddWithValue("@u", username);
                cmd4.Parameters.AddWithValue("@p", password);

                SqlDataReader reader = cmd4.ExecuteReader();

                if (reader.Read())
                {
                    login_detail.Add(reader["First_Name"].ToString());
                    login_detail.Add(reader["Last_Name"].ToString());
                    login_detail.Add(reader["Role"].ToString());
                    login_detail.Add(reader["Username"].ToString());

                    if (login_detail[4].TrimEnd() == "Admin")
                    {
                        Admin_Menu obj = new Admin_Menu(login_detail[5].TrimEnd());
                        obj.first_name = login_detail[2].TrimEnd();
                        obj.last_name = login_detail[3].TrimEnd();
                        obj.ShowDialog();
                    }
                    else if (login_detail[4].TrimEnd() == "Chef")
                    {
                                                
                    }
                }
                reader.Close();
            }
            else
                status = "Incorrect Username / Password";

            con.Close();

            return status;
        }
        public static (bool, string) forgotFind(string username, string email)
        { 
            bool status = false; string mess = null;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from staff where Username = @username and Email = @email", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);

                int store = Convert.ToInt32(cmd.ExecuteScalar());
                if(store != 0)
                {
                    status = true;
                    mess = "The user has been found!";
                }
            }

            return (status, mess);
        }
        public static bool updatePass(string username, string email, string password)
        {
            bool status = !true;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update staff set Password = @password where Username = @username and Email = @email", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                int store = cmd.ExecuteNonQuery();

                if(store > 0)
                {
                    status = true;
                }
            }

            return status;
        }
    }
}
