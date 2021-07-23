using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CWC.DAL.Entity
{
    [Table("tblUsers")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }  
        public bool IsDeleted { get; set; }
        public DateTime RecDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public Roles Roles { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
      

    }
}
