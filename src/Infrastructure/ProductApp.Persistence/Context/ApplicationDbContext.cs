﻿using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product() { Id = Guid.NewGuid(), Name = "Pen", Value = 2, Quantity = 100 },
                    new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Value = 1, Quantity = 200 },
                    new Product() { Id = Guid.NewGuid(), Name = "Book", Value = 5, Quantity = 300 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}