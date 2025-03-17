using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Assignment
{
    internal class SQL
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Huang\Documents\Assignment\Menu.mdf;Integrated Security=True";
       
        public string AddMenu(bool rdb,string id, string nm, double pr)
        {      
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryFood = "Insert Into Food (FoodID, FName, FPrice) Values(@ID, @Name, @Price)";
                string queryDrink = "Insert Into Drink (FoodID, DName, DPrice) Values(@ID, @Name, @Price)";
                if (rdb == true)
                {
                    using (SqlCommand cmd = new SqlCommand(queryFood, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Name", nm);
                        cmd.Parameters.AddWithValue("@Price", pr);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (rdb == false)
                {
                    using (SqlCommand cmd = new SqlCommand(queryDrink, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Name", nm);
                        cmd.Parameters.AddWithValue("@Price", pr);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
                return "Added Succeful";
            }
        }

        public string EditMenu(string cg, string id, string nm, double pr)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryFood = "Update Food Set FName=@Name,FPrice=@Price Where FoodID=@ID";
                string queryDrink = "Update Drink Set DName=@Name,DPrice=@Price Where FoodID=@ID";

                if (cg == "Food")
                {
                    using (SqlCommand cmd = new SqlCommand(queryFood, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Name", nm);
                        cmd.Parameters.AddWithValue("@Price", pr);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (cg == "Drink")
                {
                    using (SqlCommand cmd = new SqlCommand(queryDrink, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Name", nm);
                        cmd.Parameters.AddWithValue("@Price", pr);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            return "Edited Succeful";
        }

        public string DeleteMenu(string cg, string id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryFood = "Delete From Food Where FoodID=@ID";
                string queryDrink = "Delete From Drink Where FoodID=@ID";

                if (cg == "Food")
                {
                    using (SqlCommand cmd = new SqlCommand(queryFood, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (cg == "Drink")
                {
                    using (SqlCommand cmd = new SqlCommand(queryDrink, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            return "Deleted Succeful";
        }

        public string AddHall(string id, int cp, string pt)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryHall = "Insert Into Hall(HallID, Capacity, PartyType) Values(@ID,@Capacity,@Party)";
                using (SqlCommand cmd = new SqlCommand(queryHall,conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Capacity", cp);
                    cmd.Parameters.AddWithValue("@Party", pt);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return "Added Succeful";
        }

        public string EditHallCapacity(string id, int cp)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryCapacity = "Update Hall Set Capacity=@Capacity Where HallID=@ID";
                using (SqlCommand cmd = new SqlCommand(queryCapacity,conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Capacity", cp);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return "Edited Succeful";
        }

        public string EditHallParty(string id, string or, string pt)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryCapacity = "Update Hall Set PartyType=@Party Where HallID=@ID and PartyType=@Ori";
                using (SqlCommand cmd = new SqlCommand(queryCapacity, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Ori", or);
                    cmd.Parameters.AddWithValue("@Party", pt);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return "Edited Succeful";
        }

        public string DeleteHall(string id, string pt)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string queryHall = "Delete From Hall Where HallID=@ID and PartyType=@Party";

                    using (SqlCommand cmd = new SqlCommand(queryHall, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Party", pt);
                        cmd.ExecuteNonQuery();
                    }
                conn.Close();
            }
            return "Deleted Succeful";
        }
    }
}
