using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using E_Commerce.Data.Models;

namespace E_Commerce.Data
{
    public class DataDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public DataDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-M3US80J;Initial Catalog=CarSaleApp;Integrated Security=True;Pooling=False;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.imgUrl)
                .IsRequired()
                .HasColumnName("Img Url");

                entity.Property(x => x.Make)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Car Make");

                entity.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Car Model");

                entity.Property(x => x.Year)
                .IsRequired()
                .HasColumnName("Car Year");

                entity.Property(x => x.Mileage)
                .IsRequired()
                .HasColumnName("Car Mileage");

                entity.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Car Price");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("User Name");

                entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("User Email");

                entity.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("User Password");

                entity.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasColumnName("User Phone");

                entity.Property(x => x.IsActive)
                .HasDefaultValue(true);

                entity.Property(x => x.IsAdmin)
                .HasDefaultValue(false);

                entity.Property(x => x.AdminLevel)
                .HasDefaultValue(0);

                entity.Property(x => x.CreatedAt)
                .HasDefaultValueSql("getutcdate()");

            });
        }
    }
}
