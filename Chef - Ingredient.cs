using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Assignment
{
    public partial class Ingredient : Form
    {
        public Ingredient()
        {
            InitializeComponent();
        }

        private void labelQUantity_Click(object sender, EventArgs e)
        {

        }

        private void Load_Ingredient()
        {
            listBoxIngredient.Items.Clear();
            {
                {
                    string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TJJJJ\Desktop\IOOP\Assignment\Assignment\ingredient.mdf;Integrated Security = True";
                    using (SqlConnection Ingredient = new SqlConnection(Connection))
                    {
                        Ingredient.Open();
                        string query = "Select IngredientID ,IngredientName, Quantity, Unit, Quantity Ingredient from [Ingredient]";

                        using (SqlCommand cmd = new SqlCommand(query, Ingredient))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string IngredientInfo = $"{reader["IngredientID"]},{reader["IngredientName"]},{reader["Quantity"]},{reader["Unit"]}";
                                    listBoxIngredient.Items.Add(IngredientInfo);

                                }
                            }
                        }
                    }
                }
            }
        }
        private void Clear_Data()
        {
            textBoxIngredientName.Clear();
            textBoxQuantity.Clear();
            textBoxUnit.Clear();
            textBoxAddIngredient.Clear();
        }
        private void Ingredient_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Load_Ingredient();          
        }

        private void Ingredient_Split()
        {
            if (listBoxIngredient.SelectedItem == null)
            {
                listBoxIngredient.SelectedIndex = 0;
            }
            string Ingredient = listBoxIngredient.SelectedItem.ToString(); 
            textBoxAddIngredient.Text = Ingredient.Split(',')[0];
            textBoxIngredientName.Text = Ingredient.Split(',')[1];
            textBoxUnit.Text = Ingredient.Split(',')[3];
            textBoxQuantity.Text = Ingredient.Split(',')[2];
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void listBoxIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ingredient_Split();         
        }

        private void labelShowIngredient_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            

        }

        private void radioButtonAddIngredient_CheckedChanged(object sender, EventArgs e)
        {
            listBoxIngredient.Enabled = false;
            textBoxAddIngredient.Enabled = true;
            textBoxIngredientName.Enabled = true;
            textBoxQuantity.Enabled = true;
            textBoxUnit.Enabled = true;
            Clear_Data();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (radioButtonAddIngredient.Checked)
            {
                Ingredient X = new Ingredient();
                string A, B, D;
                int C;
                A = textBoxAddIngredient.Text.ToUpper().Trim();
                B = textBoxIngredientName.Text.Trim();
                D = textBoxUnit.Text.Trim();

                if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || string.IsNullOrEmpty(D))
                {
                    labelShowIngredient.Text = "Please complete all of the info";
                    return;
                }

                if (!A.StartsWith("I"))
                {
                    labelShowIngredient.Text = "Ingredient ID must start with I";
                    return;
                }

                if (!int.TryParse(textBoxQuantity.Text, out C))
                {
                    labelShowIngredient.Text = "Quantity must be number";
                    return;
                }

                else
                {
                    Inventory Ingredient = new Inventory(A, B, C, D);
                    string message = Ingredient.Add_Ingredient(A, B, C, D);
                    labelShowIngredient.Text = message;
                }
                Clear_Data();
                Load_Ingredient();
            }

            else if (radioButtonEdit.Checked)
            {
                string A, B, D;
                int C;
                A = textBoxAddIngredient.Text.ToUpper().Trim();
                B = textBoxIngredientName.Text;
                D = textBoxUnit.Text;

                if (string.IsNullOrEmpty(A))
                {
                    labelShowIngredient.Text = "Please select item to edit";
                    return;
                }

                if (listBoxIngredient.SelectedItem == null)
                {
                    labelShowIngredient.Text = "Please select Ingredient";
                    return;
                }
                if (int.TryParse(textBoxQuantity.Text, out C))
                {
                    Inventory Edit_Ingredient = new Inventory(A, B, C, D);
                    string msg = Edit_Ingredient.Edit_Ingredient(A, B, C, D);
                    labelShowIngredient.Text = msg;
                }
                else
                {
                    labelShowIngredient.Text = "Please enter Only number of Quantity";
                }
                Load_Ingredient();

            }

            else if (radioButtonDelete.Checked)
            {
                string A;
                A = textBoxAddIngredient.Text.Trim();
                if (string.IsNullOrEmpty(A))
                {
                    labelShowIngredient.Text = "Please select Ingredient ID";
                }
                else
                {
                    Inventory Ingredient = new Inventory(A, "", 0, "");
                    string result = Ingredient.Delete_Ingredient(A);
                    labelShowIngredient.Text = result;

                }
                Clear_Data();
                Load_Ingredient();
            }

            else if (radioButtonSearch.Checked)
            {
                string A = textBoxAddIngredient.Text.Trim().ToUpper();
                bool Ingredient = false;
                if (string.IsNullOrEmpty(A))
                {
                    labelShowIngredient.Text = "Please input an Ingredient ID";
                    return;
                }

                else
                {
                    for (int i = 0; i < listBoxIngredient.Items.Count; i = i + 1)
                    {
                        string items = listBoxIngredient.Items[i].ToString();
                        string IngredientID = items.Split(',')[0];
                        string IngredientName = items.Split(',')[1];
                        string Quantity = items.Split(',')[2];
                        string unit = items.Split(',')[3];

                        if (A == IngredientID)
                        {
                            Ingredient = true;
                            listBoxIngredient.SelectedIndex = i;
                            textBoxAddIngredient.Text = IngredientID;
                            textBoxIngredientName.Text = IngredientName;
                            textBoxQuantity.Text = Quantity;
                            textBoxUnit.Text = unit;
                            labelShowIngredient.Text = "Ingredient Found";
                            break;
                            
                        }
                    }
                }
                if (Ingredient == false)
                {

                    labelShowIngredient.Text = "Ingredient Not found";
                    Clear_Data();

                }
            }
            else { labelShowIngredient.Text = "Please select a function"; }
        }
        
private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            Clear_Data();
            listBoxIngredient.Enabled = true;
            textBoxAddIngredient.Enabled =true;
            textBoxIngredientName.Enabled = false;
            textBoxQuantity.Enabled = false;
            textBoxUnit.Enabled = false;


        }

        private void radioButtonSearch_CheckedChanged(object sender, EventArgs e)
        {
            Clear_Data();
            textBoxAddIngredient.Enabled = true;
            textBoxIngredientName.Enabled = false;
            textBoxQuantity.Enabled = false;
            textBoxUnit.Enabled = false;
            listBoxIngredient.Enabled= false;                
        }

        private void radioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            listBoxIngredient.Enabled = true;
            textBoxAddIngredient.Enabled = true;
            textBoxIngredientName.Enabled = true;
            textBoxQuantity.Enabled = true;
            textBoxUnit.Enabled = true;
            
        }

        private void textBoxAddIngredient_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            MainMenu obj = new MainMenu();
            obj.Show();
        }

        private void labelOrder_Click(object sender, EventArgs e)
        {
            Order obj = new Order();
            obj.Show();
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
            Profile obj = new Profile();
            obj.Show();
        }
    }
}
       