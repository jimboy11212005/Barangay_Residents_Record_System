using System;
using System.Collections.Generic;
using BRRAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BRRAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Resident> Residents { get; set; }
    }
}