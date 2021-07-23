using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tbl_Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Customer_Name { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public TablesForBooking TablesForBooking { get; set; }
        [ForeignKey("TablesForBooking")]
        public int TableID { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
        public ICollection<RestaurantBilling> RestaurantBilling { get; set; }

    }
}
