using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tbl_OrderItem")]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string FoodItemName { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> FakeQuantity { get; set; }
        public string OrderTakenBy { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrderId{ get; set; }

    }
}
