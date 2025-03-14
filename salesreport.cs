using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assignment
{
    class salesreport
    {
        private string month;
        private string year;
        private string chef;

        public salesreport(string month, string year, string chef)
        {
            this.month = month;
            this.year = year;
            this.chef = chef;
        }

        public static (DataTable, double) salesReportMonth(string month, string year)
        {
            DataTable dataTab = new DataTable();
            double total = 0;
            string nul = "-1";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if(month!=nul && year!= nul)
                {
                    SqlDataAdapter sqlTab = new SqlDataAdapter("select * from sales where MONTH(SaleDate) = @month and YEAR(SaleDate) = @year", con);
                    sqlTab.SelectCommand.Parameters.AddWithValue("@month", int.Parse(month));
                    sqlTab.SelectCommand.Parameters.AddWithValue("@year", int.Parse(year));

                    sqlTab.Fill(dataTab);

                    SqlCommand cmd = new SqlCommand("select ISNULL(SUM(Price), 0) from sales where MONTH(SaleDate) = @month and YEAR(SaleDate) = @year", con);
                    cmd.Parameters.AddWithValue("@month", int.Parse(month));
                    cmd.Parameters.AddWithValue("@year", int.Parse(year));
                    total = Convert.ToDouble(cmd.ExecuteScalar());
                }
                else if (month != nul)
                {
                    SqlDataAdapter sqlTab = new SqlDataAdapter("select * from sales where MONTH(SaleDate) = @month", con);
                    sqlTab.SelectCommand.Parameters.AddWithValue("@month", int.Parse(month));

                    sqlTab.Fill(dataTab);

                    SqlCommand cmd = new SqlCommand("select ISNULL(SUM(Price), 0) from sales where MONTH(SaleDate) = @month", con);
                    cmd.Parameters.AddWithValue("@month", int.Parse(month));
                    total = Convert.ToDouble(cmd.ExecuteScalar());
                }
                else if(year != nul)
                {
                    SqlDataAdapter sqlTab = new SqlDataAdapter("select * from sales where Year(SaleDate) = @year", con);
                    sqlTab.SelectCommand.Parameters.AddWithValue("@year", int.Parse(year));

                    sqlTab.Fill(dataTab);

                    SqlCommand cmd = new SqlCommand("select ISNULL(SUM(Price), 0) from sales where Year(SaleDate) = @year", con);
                    cmd.Parameters.AddWithValue("@year", int.Parse(year));
                    total = Convert.ToDouble(cmd.ExecuteScalar());
                }
                
            }
            
            return (dataTab, total);
        }
        public static List<string> GetChef()
        {
            List<string> store = new List<string>();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select First_Name, Last_Name from staff where Role = @r", con);
                con.Open();
                cmd.Parameters.AddWithValue("@r", "Chef");

                SqlDataReader read = cmd.ExecuteReader();

                while(read.Read())
                {
                    string hold = $"{read["First_Name"]} {read["Last_Name"]}";
                    store.Add(hold);
                }
                read.Close();
            }
            return store;
        }

        public static (DataTable, double) chefReport(string chef)
        {
            double total = 0;
            DataTable report = new DataTable();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Draft\Admin_Database.mdf;Integrated Security=True";
            
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter sqlDB = new SqlDataAdapter("select * from sales where Chef = @chef", con);
                sqlDB.SelectCommand.Parameters.AddWithValue("@chef", chef);
                sqlDB.Fill(report);

                SqlCommand cmd = new SqlCommand("select ISNULL(SUM(Price), 0) from sales where Chef = @chef", con);
                cmd.Parameters.AddWithValue("@chef", chef);
                total = Convert.ToDouble(cmd.ExecuteScalar());
            }
            return (report, total);
        }

    }

}
