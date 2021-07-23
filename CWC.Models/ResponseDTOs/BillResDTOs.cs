using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.ResponseDTOs
{
    public class BillResDTOs
    {

        public string OrderId { get; set; }
        public string Customer_Name { get; set; }
        public string Phone { get; set; }
        public int TableID { get; set; }
        public Nullable<double> PriceWithoutTax { get; set; }
        public float TotalPrice { get; set; }
        public List<OrderItems> OrderItem { get; set; }
    }
    public class OrderItems
    {
        public string FoodItemName { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Quantity { get; set; }

    }
}


