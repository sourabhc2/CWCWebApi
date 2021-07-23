using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.RequestDTOs
{
    public class OrderReqDTOs
    {
        public string Customer_Name { get; set; }
        public string Phone { get; set; }
        public int TableID { get; set; }
        public List<OrderItems> OrderItems{get;set;}
    }
    public class OrderItems {
        public int Id { get; set; }
        public string FoodItemName { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> FakeQuantity { get; set; }
        public string OrderTakenBy { get; set; }

    }
}
