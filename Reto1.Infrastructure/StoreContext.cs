using Microsoft.EntityFrameworkCore;
using Reto1.Core.Entities;
using System;

namespace Reto1.Infrastructure
{
    public class StoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Mug> Mugs { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.Status)
                    .HasConversion<string>();

                entity.HasOne(o => o.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(o => o.Client);
                entity.HasIndex(o => o.Status);
                entity.HasIndex(o => o.CreatedAt);
            });

            // Configure Attachment entity
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Type)
                    .HasConversion<string>();

                entity.HasOne(a => a.Order)
                    .WithMany(o => o.Attachments)
                    .HasForeignKey(a => a.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Product entities
            modelBuilder.Entity<TShirt>(entity =>
            {
                entity.HasIndex(t => t.Sku).IsUnique();
            });

            modelBuilder.Entity<Mug>(entity =>
            {
                entity.HasIndex(m => m.Sku).IsUnique();
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.HasIndex(p => p.Sku).IsUnique();
            });

            // Seed Data
            //SeedData(modelBuilder);
        

        }

        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    // Seed TShirts
        //    modelBuilder.Entity<TShirt>().HasData(
        //        new TShirt { Id = 1, Sku = "TS001", Size = "S", Color = "Red", Price = 15.99m },
        //        new TShirt { Id = 2, Sku = "TS002", Size = "M", Color = "Blue", Price = 15.99m },
        //        new TShirt { Id = 3, Sku = "TS003", Size = "L", Color = "Black", Price = 17.99m },
        //        new TShirt { Id = 4, Sku = "TS004", Size = "XL", Color = "White", Price = 17.99m },
        //        new TShirt { Id = 5, Sku = "TS005", Size = "M", Color = "Green", Price = 16.99m }
        //    );

        //    // Seed Mugs
        //    modelBuilder.Entity<Mug>().HasData(
        //        new Mug { Id = 6, Sku = "MG001", CapacityInMl = 350, Color = "White", Price = 12.99m },
        //        new Mug { Id = 7, Sku = "MG002", CapacityInMl = 500, Color = "Black", Price = 14.99m },
        //        new Mug { Id = 8, Sku = "MG003", CapacityInMl = 300, Color = "Blue", Price = 11.99m },
        //        new Mug { Id = 9, Sku = "MG004", CapacityInMl = 400, Color = "Red", Price = 13.99m },
        //        new Mug { Id = 10, Sku = "MG005", CapacityInMl = 600, Color = "Gray", Price = 16.99m }
        //    );

        //    // Seed Posters
        //    modelBuilder.Entity<Poster>().HasData(
        //        new Poster { Id = 11, Sku = "PS001", HeightCm = 40.0m, WidthCm = 30.0m, PaperType = "Glossy", Price = 8.99m },
        //        new Poster { Id = 12, Sku = "PS002", HeightCm = 60.0m, WidthCm = 40.0m, PaperType = "Matte", Price = 12.99m },
        //        new Poster { Id = 13, Sku = "PS003", HeightCm = 80.0m, WidthCm = 60.0m, PaperType = "Canvas", Price = 24.99m },
        //        new Poster { Id = 14, Sku = "PS004", HeightCm = 50.0m, WidthCm = 35.0m, PaperType = "Photo Paper", Price = 15.99m },
        //        new Poster { Id = 15, Sku = "PS005", HeightCm = 100.0m, WidthCm = 70.0m, PaperType = "Vinyl", Price = 34.99m }
        //    );

        //    // Seed Orders
        //    var baseDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        //    modelBuilder.Entity<Order>().HasData(
        //        new Order
        //        {
        //            Id = 1,
        //            Client = "John Smith",
        //            Description = "Custom red t-shirt for company event",
        //            ProductId = 1,
        //            Status = OrderStatus.DELIVERED,
        //            CreatedAt = baseDate.AddDays(1),
        //            UpdatedAt = baseDate.AddDays(5)
        //        },
        //        new Order
        //        {
        //            Id = 2,
        //            Client = "Maria Garcia",
        //            Description = "Corporate mug with logo",
        //            ProductId = 6,
        //            Status = OrderStatus.IN_PRODUCTION,
        //            CreatedAt = baseDate.AddDays(10),
        //            UpdatedAt = baseDate.AddDays(12)
        //        },
        //        new Order
        //        {
        //            Id = 3,
        //            Client = "Robert Johnson",
        //            Description = "Marketing poster for new product launch",
        //            ProductId = 12,
        //            Status = OrderStatus.APPROVED,
        //            CreatedAt = baseDate.AddDays(15),
        //            UpdatedAt = baseDate.AddDays(16)
        //        },
        //        new Order
        //        {
        //            Id = 4,
        //            Client = "Emma Wilson",
        //            Description = "Black t-shirt with custom design",
        //            ProductId = 3,
        //            Status = OrderStatus.UNDER_REVIEW,
        //            CreatedAt = baseDate.AddDays(20),
        //            UpdatedAt = baseDate.AddDays(21)
        //        },
        //        new Order
        //        {
        //            Id = 5,
        //            Client = "Carlos Rodriguez",
        //            Description = "Large canvas poster for office decoration",
        //            ProductId = 13,
        //            Status = OrderStatus.RECEIVED,
        //            CreatedAt = baseDate.AddDays(25),
        //            UpdatedAt = baseDate.AddDays(25)
        //        }
        //    );

        //    // Seed Attachments
        //    modelBuilder.Entity<Attachment>().HasData(
        //        new Attachment
        //        {
        //            Id = 1,
        //            OrderId = 1,
        //            Url = "https://example.com/designs/tshirt-design-001.png",
        //            Type = AttachmentType.DESIGN
        //        },
        //        new Attachment
        //        {
        //            Id = 2,
        //            OrderId = 2,
        //            Url = "https://example.com/logos/company-logo.svg",
        //            Type = AttachmentType.IMAGE
        //        },
        //        new Attachment
        //        {
        //            Id = 3,
        //            OrderId = 2,
        //            Url = "https://example.com/specs/mug-specifications.pdf",
        //            Type = AttachmentType.SPECIFICATION
        //        },
        //        new Attachment
        //        {
        //            Id = 4,
        //            OrderId = 3,
        //            Url = "https://example.com/designs/poster-mockup.jpg",
        //            Type = AttachmentType.DESIGN
        //        },
        //        new Attachment
        //        {
        //            Id = 5,
        //            OrderId = 4,
        //            Url = "https://example.com/references/design-reference.pdf",
        //            Type = AttachmentType.DOCUMENT
        //        }
        //    );
        //}
    }
}
