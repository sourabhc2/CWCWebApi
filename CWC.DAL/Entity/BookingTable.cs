using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.DAL.Entity
{
  public class BookingTable
    {
        public int ID { get; set; }
        public Nullable<int> TableID { get; set; }
        public string BookingDate { get; set; }
        public string BookingStartTime { get; set; }
        public string BookingEndTime { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
