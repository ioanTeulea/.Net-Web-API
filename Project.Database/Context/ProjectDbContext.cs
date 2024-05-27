using Microsoft.EntityFrameworkCore;
using Project.Database.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Project.Database.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Produs)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.IdProdus);

            modelBuilder.Entity<Produs>()
                .Property(p => p.Nume)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Review>()
                .Property(r => r.Titlu)
                .HasMaxLength(50);

            modelBuilder.Entity<Review>()
                .Property(r => r.Descriere)
                .HasMaxLength(500);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Project;User Id=sa1;Password=Admin123!;TrustServerCertificate=True")
                .LogTo(Console.WriteLine);
        }
    }
}
