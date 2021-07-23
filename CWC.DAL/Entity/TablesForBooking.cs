using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tbl_TablesForBooking")]
   public class TablesForBooking
    {
        [Key]
        public int ID { get; set; }
        public string TableNo { get; set; }
        public bool Status { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
