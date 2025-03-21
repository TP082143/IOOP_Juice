using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    internal class Inventory
    {
        private string Ingredient_ID;
        private string Ingredient_Name;
        private int Quantity;
        private string Unit;

        public Inventory(string A, string B, int C, string D)
        {
            Ingredient_ID = A;
            Ingredient_Name = B;
            Quantity = C;
            Unit = D;
        }

        public bool CheckedIngredientID(string IngredientID)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
            using (SqlConnection Check_Ingredient = new SqlConnection(connection))
            {
                Check_Ingredient.Open();
                string query = "Select Count (*) from Ingredient Where IngredientID = @IngredientID";

                using (SqlCommand cmd = new SqlCommand(query, Check_Ingredient))
                {
                    cmd.Parameters.AddWithValue("@IngredientID", IngredientID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }

            }

        }
        public string Add_Ingredient(string A, string B, int C, string D)
        {
            if (CheckedIngredientID(A))
            {
                return "Ingredient ID Already Exist";
            }
            else
            {
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
                using (SqlConnection Add_Ingredient = new SqlConnection(connection))

                {
                    Add_Ingredient.Open();
                    string query = "insert into Ingredient (IngredientID, IngredientName, Quantity, Unit) VALUES (@id, @name, @quantity, @unit)";

                    using (SqlCommand Ingredeint_Add = new SqlCommand(query, Add_Ingredient))
                    {
                        Ingredeint_Add.Parameters.AddWithValue("@id", A.Trim());
                        Ingredeint_Add.Parameters.AddWithValue("@name", B.Trim());
                        Ingredeint_Add.Parameters.AddWithValue("@quantity", C);
                        Ingredeint_Add.Parameters.AddWithValue("@unit", D.Trim());

                        int rowsAffected = Ingredeint_Add.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        { return ("Ingredient Added Successfully"); }
                        else { return ("Failed to Add Ingredient"); }
                    }


                }
            }
        }

        public string Edit_Ingredient(string A, string B, int C, string D)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
            using (SqlConnection Edit_Ingredient = new SqlConnection(connection))
            {
                Edit_Ingredient.Open();
                string query = "Update Ingredient set IngredientName = @IngredientName, Quantity = @Quantity, Unit = @Unit Where IngredientID = @IngredientID";

                using (SqlCommand cmd = new SqlCommand(query, Edit_Ingredient))
                {
                    cmd.Parameters.AddWithValue("@IngredientID", A.Trim());
                    cmd.Parameters.AddWithValue("@IngredientName", B.Trim());
                    cmd.Parameters.AddWithValue("@Quantity", C);
                    cmd.Parameters.AddWithValue("@Unit", D.Trim());

                    int X = cmd.ExecuteNonQuery();
                    if (X > 0) { return ("Ingredient Edited Successfully"); }
                    else { return ("Ingredient Failed To Edit (Ingredient ID might be wrong or don't exist)"); }
                }
            }
        }

        public string Delete_Ingredient(string A)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
            using (SqlConnection Delete_Ingredient = new SqlConnection(connection))
            {
                Delete_Ingredient.Open();
                string query = "Delete from Ingredient where IngredientID = @IngredientID";

                using (SqlCommand cmd = new SqlCommand(query, Delete_Ingredient))
                {
                    cmd.Parameters.AddWithValue("@IngredientID", A.Trim());
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return ("Ingredient Deleted Successfully");
                    }

                    else { return "Ingredient Not Found"; }
                }
            }
        }
        
       public string Search_ingredient (string A)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
            using (SqlConnection Search_Ingredient = new SqlConnection(connection))
            {
                Search_Ingredient.Open();
                string query = "Select IngredientID, IngredientName,Quantity,Unit from Ingredient where IngredientID = @IngredientID";

                using (SqlCommand Search = new SqlCommand (query, Search_Ingredient))
                {
                    Search.Parameters.AddWithValue("@IngredientID", A.Trim());

                    using(SqlDataReader Reader = Search.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            string Info = $"{Reader["IngredientID"]},{Reader["IngredientName"]},{Reader["Quantity"]},{Reader["Unit"]}";
                            string message = "Ingredient Exist";
                            return $"{Info} {message}";  
                            
                        }
                        else
                        {
                            return ("Ingredient ID Not found");
                        }
                    }
                }
            }
        }
    }
}

        
     

   

