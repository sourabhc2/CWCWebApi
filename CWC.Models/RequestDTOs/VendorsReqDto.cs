using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.RequestDTOs
{
  public  class VendorsReqDto
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; } 
        public string Contact_No { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<bool> IsNewApproved { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string AddedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
