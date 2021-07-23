using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.RequestDTOs
{

  public class MenuItemReqDTOs
    {
        public string Food_Item_Name { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string AddedBy { get; set; }
        public int VendorID { get; set; }

    }
}
