using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tblVendors")]
    public class Vendors
    {
        [Key]
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Contact_No { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsNewApproved { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string DeletedBy { get; set; }
        public ICollection<Inventory> Inventory { get; set; }

    }
}
