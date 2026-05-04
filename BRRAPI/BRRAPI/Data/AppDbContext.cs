using System;
using System.Collections.Generic;
using BRRAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BRRAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Resident> Residents { get; set; } = null!;
        public DbSet<Household> Households { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);

                // New mappings to match database schema
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime(6)")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP")
                      .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.HasKey(e => e.ResidentId);
                entity.Property(e => e.FullName).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(300);
            });

            modelBuilder.Entity<Household>(entity =>
            {
                entity.HasKey(e => e.HouseholdId);
                entity.Property(e => e.HouseholdName).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.HasMany(h => h.Members)
                      .WithOne()
                      .HasForeignKey(r => r.HouseholdId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}