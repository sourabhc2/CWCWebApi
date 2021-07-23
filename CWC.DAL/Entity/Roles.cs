using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tblRoles")]
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool Isactive { get; set; }
        public  ICollection<RoleClaims> RoleClaims { get; set; }
        public  ICollection<UserRoles> UserRoles { get; set; }
    }
}
