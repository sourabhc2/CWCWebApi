using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tblMenuItems")]
    public class Menuitems
    {
        [Key]
        public int ID { get; set; }
        public string Food_Item_Name { get; set; }     
        public string Details { get; set; }
        public double Price { get; set; }
        public bool ItemApprvFrmSuperAdm { get; set; }
        public bool ItemDelFromSuperAdm { get; set; }
        public string AddedBy { get; set; }
        public string DeletedBy { get; set; }
        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryID { get; set; }
       

    }
}
