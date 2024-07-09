﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Entities.Identity;
using LibraryManagementSystem.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class LibraryContext : IdentityDbContext<AppUser,AppRole,string>
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr =
                    "Server=localhost,1453;initial Catalog=BookHavenDB;User=sa;Password=***3Hasenek***3;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer().UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
