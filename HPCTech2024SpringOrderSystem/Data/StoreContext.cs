using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HPCTech2024SpringOrderSystem.Models;

namespace HPCTech2024SpringOrderSystem.Data;

public class StoreContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HPCTech2024SpringOrderSystem;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 1,
            Name = "Meat Lovers",
            Price = 10.99M
        });
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 2,
            Name = "Deluxe Pizza",
            Price = 12.99M
        });
        modelBuilder.Entity<Customer>().HasData(new Customer()
        {
            Id = 1,
            FirstName = "Eric",
            LastName = "Couch",
            Address = "123 Main St",
            Email = "eric.couch@cognizant.com",
            Phone = "123-456-7890"
        });
        modelBuilder.Entity<Order>().HasData(new Order()
        {
            Id = 1,
            OrderDate = DateTime.Now.AddMinutes(-45),
            OrderFullfilled = DateTime.Now.AddMinutes(-25),
            CustomerId = 1
        });
        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail()
        {
            Id = 1,
            OrderId = 1,
            ProductId = 1,
            Quantity = 2
        });
        modelBuilder.Entity<Order>().HasData(new Order()
        {
            Id = 2,
            OrderDate = DateTime.Now.AddMinutes(-30),
            OrderFullfilled = DateTime.Now.AddMinutes(-15),
            CustomerId = 1
        });
        modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail()
        {
            Id = 2,
            OrderId = 2,
            ProductId = 2,
            Quantity = 2
        });
    }
}

