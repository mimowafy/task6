using FreshLifie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Data
{
    public class FreshLifieContext : DbContext
    {
        public FreshLifieContext(DbContextOptions<FreshLifieContext> options)
        : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<item> Items { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Order_Item>()
                  .HasKey(sc => new { sc.ItemId, sc.OrderId });

            modelBuilder.Entity<Models.Order_Item>()
               .HasOne(sc => sc._Item)
               .WithMany(c => c.OrderList)
               .HasForeignKey(sc => sc.ItemId);

            modelBuilder.Entity<Models.Order_Item>()
                .HasOne(sc => sc._Order)
                .WithMany(s => s.ItemList)
                .HasForeignKey(sc => sc.OrderId);


            modelBuilder.Entity<Models.Provider_Order>()
                .HasKey(sc => new { sc.ProviderID, sc.OrderId });

            modelBuilder.Entity<Models.Provider_Order>()
               .HasOne(sc => sc._provider)
               .WithMany(c => c.orderList)
               .HasForeignKey(sc => sc.ProviderID);

            modelBuilder.Entity<Models.Provider_Order>()
                .HasOne(sc => sc._Order)
                .WithMany(s => s.prvoderslist)
                .HasForeignKey(sc => sc.OrderId);


            modelBuilder.Entity<Models.User_Provider>()
                .HasKey(sc => new { sc.UserId, sc.ProviderID });

            modelBuilder.Entity<Models.User_Provider>()
               .HasOne(sc => sc._user)
               .WithMany(c => c.ProvidersList)
               .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Models.User_Provider>()
                .HasOne(sc => sc._providers)
                .WithMany(s => s.UserList)
                .HasForeignKey(sc => sc.ProviderID);
        }

        public DbSet<FreshLifie.Models.Product_Type> Product_Type { get; set; }

        public DbSet<FreshLifie.Models.User_Provider> User_Provider { get; set; }
    }
}
