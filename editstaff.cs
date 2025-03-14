using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Assignment
{
    class editstaff
    {
        private string username, role;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

        public editstaff(string username, string role)
        {
            this.username = username;
            this.role = role;
        }

        public static ArrayList GetData(string role)
        {

            ArrayList store = new ArrayList();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select Username from staff where Role = @r ORDER BY Id ASC", con);
            cmd1.Parameters.AddWithValue("@r", role);
            SqlDataReader read = cmd1.ExecuteReader();
            int ID = 1;
            while (read.Read())
            {
                string line = $"{ID}.  {read["Username"]}";
                store.Add(line);
                ID += 1;
            }
            con.Close();
            return store;
        }
        public static ArrayList GetDatawithEmail(string role)
        {
            ArrayList store = new ArrayList();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select Username, Email from staff where Role = @r ORDER BY Id ASC", con);
            cmd1.Parameters.AddWithValue("@r", role);
            SqlDataReader read = cmd1.ExecuteReader();
            int ID = 1;
            while (read.Read())
            {
                string line = $"{ID}.  {read["Username"]} - {read["Email"]}";
                store.Add(line);
                ID += 1;
            }
            con.Close();
            return store;
        }

        public bool GetUser()
        {
            bool status = false;

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("select count(*) from staff where Username = @u", con);
            cmd1.Parameters.AddWithValue("@u", username);

            int count = Convert.ToInt32(cmd1.ExecuteScalar());
            if (count > 0)
            {
                return status = true;
            }
            return status;
        }

        public static bool EditCol(string colval, string username, string updata, string role)
        {
            bool status = false;
 
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd2 = new SqlCommand($"update staff set {colval} = @data where Username = @u and Role = @r", con);
            cmd2.Parameters.AddWithValue("@data", updata);
            cmd2.Parameters.AddWithValue("@u", username);
            cmd2.Parameters.AddWithValue("@r", role);

            int byPass = cmd2.ExecuteNonQuery();
           
            if (byPass != 0)
                return status = true;
            else
                return status;
        }


        public static ArrayList ShowData(string username)
        {
            ArrayList value = new ArrayList();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select First_Name, Last_Name, Username, Email, Password from staff where Username = @u", con);
            cmd.Parameters.AddWithValue("@u", username);
            SqlDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                for (int i = 0; i <= 4; i++)
                {
                    value.Add(read[i].ToString());
                }
            }

            con.Close();

            return value;
        }

        public static bool DelUser(string username, string email)
        {
            bool status = false;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from staff where Username = @u and Email = @e", con);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@e", email);

            int hold = cmd.ExecuteNonQuery();
            con.Close();

            if(hold != 0)
            {
                status = true;
            }

            return status;
        }
    }
}
