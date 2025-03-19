using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Chef_Customer_Order 
    {
        private int OrderID;
        private string FoodID;
        private string Food_Name;
        private double Price;
        private DateTime Date;
        private string Order_status;
        private double Total_Prices;
        private string Chef_Username;

        public Chef_Customer_Order(int a, string b,string c,double d,DateTime e,string f,double g, string h)
        {
            OrderID = a;
            FoodID = b;
            Food_Name = c;
            Price = d;
            Date = e;
            Order_status = f;
            Total_Prices = g;
            Chef_Username = h;
        }




    }
}
