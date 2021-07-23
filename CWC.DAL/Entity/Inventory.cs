using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tblInventory")]
    public  class Inventory
    {  
        [Key]
        public int InventoryId { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> Price { get; set; }       
        public string Measurement { get; set; }
        public Vendors Vendors { get; set; }
        [ForeignKey("Vendors")]
        public int VendorID { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Menuitems> Menuitems { get; set; }

    }
}
