using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tblRoleClaims")]
    public  class RoleClaims
    {
        [Key]
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; } 
        public bool IsActive { get; set; }
        public  Roles Roles { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }

    }
}
