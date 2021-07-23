using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
   [Table("tblUserRoles")]
   public class UserRoles
    { 


        [Key]
        public int UserRolesId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public Roles Roles { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
       

    }
}
