using CWC.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CWC.DAL.Data
{
  public  class CWCContext: DbContext
    {
        public CWCContext(DbContextOptions options) : base(options)
        {

        }
     

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<RoleClaims> RoleClaims { get; set; }
        public DbSet<Menuitems> Menuitems { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<TablesForBooking> TablesForBooking { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<TablesForBooking> RestaurantBilling { get; set; }



    }
}
