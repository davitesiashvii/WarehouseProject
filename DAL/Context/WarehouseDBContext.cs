using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class WarehouseDBContext : IdentityDbContext<AppUser>
    {
        public WarehouseDBContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Shope> Shopes { get; set; }

        public DbSet<Production> Productions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductionShope> ProductionShopes { get; set; }

        public DbSet<UserRate> UserRates { get; set; }

       // public DbSet<UserShope> UserShopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Prodaction
            modelBuilder.Entity<Production>()
                .Property(e=>e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Production>()
                .Property(e => e.ManufacturerCompany)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Production>()
                .Property(e => e.Image)
                .HasMaxLength(5000)
                .IsRequired();

            //User
          
            //Sope
            modelBuilder.Entity<Shope>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Shope>()
                .Property(e => e.Address)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Shope>()
                .Property(e => e.Type)
                .HasMaxLength(200)
                .IsRequired();

            //ProdactShope
            modelBuilder.Entity<ProductionShope>()
                .HasOne(e => e.Production)
                .WithMany(e => e.Shopes)
                .HasForeignKey(e => e.ProductionID);

            modelBuilder.Entity<ProductionShope>()
                .HasOne(e => e.Shope)
                .WithMany(e => e.Productions)
                .HasForeignKey(e => e.ShopeID);

            modelBuilder.Entity<ProductionShope>()
                .Property(e => e.Price)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<ProductionShope>()
                .Property(e => e.Code)
                .HasMaxLength(200)
                .IsRequired();

            ///User
            modelBuilder.Entity<User>()
                .Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasMaxLength(256)
                .IsRequired();

            //UserRate

            modelBuilder.Entity<UserRate>()
                .Property(e => e.Score)
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<UserRate>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserRates)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserRate>()
               .HasOne(e => e.Shope)
               .WithMany(e => e.Rates)
               .HasForeignKey(e => e.ShopeId);

        }
    }
}
