using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tbl_RestaurantBilling")]
    public class RestaurantBilling
    {
        [Key]
        public int Bill_Number { get; set; }
        public Nullable<int> UserID { get; set; }
        public string PaymentDate { get; set; }
        public Nullable<double> GST { get; set; }
        public Nullable<double> PriceWithoutTax { get; set; }
        public string Mode_Of_Payment { get; set; }
        public Nullable<int> Billed_By { get; set; }
        public Nullable<double> Discount { get; set; }
        public string Customer_GstNO { get; set; }
        public Order Order { get; set; }
        [ForeignKey("TablesForBooking")]
        public int OrderID { get; set; }


    }
}
