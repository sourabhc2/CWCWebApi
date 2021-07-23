using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.DAL.Entity
{
   public class InventoryUsage
    {
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public double Used_Qty { get; set; }
        public string Description { get; set; }
        public string Used_Date { get; set; }
        public int BillNo { get; set; }
    }
}
