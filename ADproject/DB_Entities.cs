using ADproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ADproject
{
    public class DB_Entities: DbContext
    {
        public DB_Entities() : base("Burger") { }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }
    }
}