using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.ResponseDTOs
{
  public  class VendorsResDTOs
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Contact_No { get; set; }
        public string EmailID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsNewApproved { get; set; }
    }
}
