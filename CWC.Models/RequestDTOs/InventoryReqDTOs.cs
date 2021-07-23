using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.RequestDTOs
{
  public  class InventoryReqDTOs
    {
        public int InventoryId { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public string Measurement { get; set; }       
        public int VendorID { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }         
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
