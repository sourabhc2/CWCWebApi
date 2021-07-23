using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.RequestDTOs
{
  public  class UserRolesReqDTOs
    {
        public int UserId { get; set; }
        public List<int> UserRoles { get; set; }
    }
}
