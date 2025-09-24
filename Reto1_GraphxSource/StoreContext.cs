using Microsoft.EntityFrameworkCore;
using Reto1.API.Entities;
using System;

namespace Reto1.API
{
    public class StoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Mug> Mugs { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TShirt>().ToTable("TShirts");
            modelBuilder.Entity<Mug>().ToTable("Mugs");
            modelBuilder.Entity<Poster>().ToTable("Posters");

            modelBuilder.Entity<Poster>()
                .Property(p => p.HeightCm)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Poster>()
                .Property(p => p.WidthCm)
                .HasPrecision(5, 2);



            modelBuilder.Entity<Order>()
                .HasOne(o => o.TShirt)
                .WithMany()
                .HasForeignKey(o => o.TShirtId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Mug)
                .WithMany()
                .HasForeignKey(o => o.MugId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Poster)
                .WithMany()
                .HasForeignKey(o => o.PosterId);

            // Order -> Attachments
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Attachments)
                .WithOne(a => a.Order)
                .HasForeignKey(a => a.OrderId);

            // Seed Data
            SeedData(modelBuilder);
        

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed TShirts
            modelBuilder.Entity<TShirt>().HasData(
                new TShirt { Id = 1, Sku = "TS001", Size = "S", Color = "Red", Price = 15.99m },
                new TShirt { Id = 2, Sku = "TS002", Size = "M", Color = "Blue", Price = 15.99m },
                new TShirt { Id = 3, Sku = "TS003", Size = "L", Color = "Black", Price = 17.99m },
                new TShirt { Id = 4, Sku = "TS004", Size = "XL", Color = "White", Price = 17.99m },
                new TShirt { Id = 5, Sku = "TS005", Size = "M", Color = "Green", Price = 16.99m }
            );

            // Seed Mugs
            modelBuilder.Entity<Mug>().HasData(
                new Mug { Id = 1, Sku = "MG001", CapacityInMl = 350, Color = "White", Price = 12.99m },
                new Mug { Id = 2, Sku = "MG002", CapacityInMl = 500, Color = "Black", Price = 14.99m },
                new Mug { Id = 3, Sku = "MG003", CapacityInMl = 300, Color = "Blue", Price = 11.99m },
                new Mug { Id = 4, Sku = "MG004", CapacityInMl = 400, Color = "Red", Price = 13.99m },
                new Mug { Id = 5, Sku = "MG005", CapacityInMl = 600, Color = "Gray", Price = 16.99m }
            );

            // Seed Posters
            modelBuilder.Entity<Poster>().HasData(
                new Poster { Id = 1, Sku = "PS001", HeightCm = 40.0m, WidthCm = 30.0m, PaperType = "Glossy", Price = 8.99m },
                new Poster { Id = 2, Sku = "PS002", HeightCm = 60.0m, WidthCm = 40.0m, PaperType = "Matte", Price = 12.99m },
                new Poster { Id = 3, Sku = "PS003", HeightCm = 80.0m, WidthCm = 60.0m, PaperType = "Canvas", Price = 24.99m },
                new Poster { Id = 4, Sku = "PS004", HeightCm = 50.0m, WidthCm = 35.0m, PaperType = "Photo Paper", Price = 15.99m },
                new Poster { Id = 5, Sku = "PS005", HeightCm = 100.0m, WidthCm = 70.0m, PaperType = "Vinyl", Price = 34.99m }
            );

            // Seed Orders

            modelBuilder.Entity<Order>().HasData(
                new { Id = 1, Client = "Alice", Description = "Black T-Shirt order", TShirtId = 1, MugId = (int?)null, PosterId = (int?)null, Status = OrderStatus.RECEIVED, CreatedAt = new DateTime(2025, 01, 01), UpdatedAt = new DateTime(2025, 01, 01) },
                new { Id = 2, Client = "Bob", Description = "Red Mug order", TShirtId = (int?)null, MugId = 3, PosterId = (int?)null, Status = OrderStatus.SHIPPED, CreatedAt = new DateTime(2025, 01, 01), UpdatedAt = new DateTime(2025, 01, 01) },
                new { Id = 3, Client = "Charlie", Description = "Glossy Poster order", TShirtId = (int?)null, MugId = (int?)null, PosterId = 5, Status = OrderStatus.IN_PRODUCTION, CreatedAt = new DateTime(2025, 01, 01), UpdatedAt = new DateTime(2025, 01, 01) }
            );

            modelBuilder.Entity<Attachment>().HasData(
                new { Id = 1, OrderId = 1, Url = "https://example.com/files/design1.png", Type = AttachmentType.DESIGN },
                new { Id = 2, OrderId = 3, Url = "https://example.com/files/poster-proof.pdf", Type = AttachmentType.DOCUMENT }
            );

        }
    }
}
