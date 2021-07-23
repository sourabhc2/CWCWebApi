using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models.RequestDTOs
{
   public class UserReqDTOs
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
    }
}
