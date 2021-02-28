using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Model.Shipping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model
{
 
    public class ITInnovDesignSorefrontContext : DbContext
    {
        public ITInnovDesignSorefrontContext()
        {

        }
        public ITInnovDesignSorefrontContext(DbContextOptions<ITInnovDesignSorefrontContext> options)
         : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductTitle> ProductTitles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ITinnovDesign.Storefront.Model.Basket.Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        //Courier DeliveryOption ShippingService

        public DbSet<Courier> Couriers { get; set; }

        public DbSet<DeliveryOption> DeliveryOptions { get; set; }

        public DbSet<ShippingService> ShippingServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ITinnovDesignStorefront;Persist Security Info=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Use the shadow property as a foreign key
            modelBuilder.Entity<Product>()
               .HasKey("Id");

            modelBuilder.Entity<Product>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Title)
                .WithMany(b => b.Products)
                .HasForeignKey(y=>y.ProductTitleId);

            modelBuilder.Entity<Product>()
              .HasOne(p => p.Brand)
              .WithMany(b => b.Products)
               .HasForeignKey(y => y.BrandId);

            modelBuilder.Entity<Product>()
              .HasOne(p => p.Category)
              .WithMany(b => b.Products)
               .HasForeignKey(y => y.CategoryId);

            modelBuilder.Entity<Product>()
              .HasOne(p => p.Size)
              .WithMany(b => b.Products)
               .HasForeignKey(y => y.ProductSizeId);

            modelBuilder.Entity<Product>()
             .HasOne(p => p.Color)
             .WithMany(b => b.Products)
              .HasForeignKey(y => y.ProductColorId); ;

            modelBuilder.Entity<ProductTitle>()
              .HasKey("Id");

            modelBuilder.Entity<ProductTitle>()
           .Property(f => f.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductTitle>()
            .HasOne(p => p.Brand);


            modelBuilder.Entity<ProductTitle>()
              .HasOne(p => p.Category);

            modelBuilder.Entity<ProductTitle>()
             .HasOne(p => p.Color);

            modelBuilder.Entity<ProductColor>()
           .HasKey("Id");

            modelBuilder.Entity<ProductColor>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();


            modelBuilder.Entity<ProductSize>()
            .HasKey("Id");


            modelBuilder.Entity<ProductSize>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Brand>()
           .HasKey("Id");


            modelBuilder.Entity<Brand>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();


            modelBuilder.Entity<ITinnovDesign.Storefront.Model.Basket.Basket>()
             .HasKey("Id");


            modelBuilder.Entity<ITinnovDesign.Storefront.Model.Basket.Basket>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<BasketItem>()
            .HasKey("Id");

            modelBuilder.Entity< BasketItem>()
           .Property(f => f.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<BasketItem>()
              .HasOne(p => p.Basket)
              .WithMany(b => b.Items)
              .HasForeignKey(y => y.BasketId);

            modelBuilder.Entity<BasketItem>()
            .HasOne(p => p.Product);

            modelBuilder.Entity<DeliveryOption>()
            .HasKey("Id");

            modelBuilder.Entity<DeliveryOption>()
         .Property(f => f.Id)
         .ValueGeneratedOnAdd();

            modelBuilder.Entity<DeliveryOption>()
            .HasOne(p => p.ShippingService);

            modelBuilder.Entity<ShippingService>()
            .HasKey("Id");

            modelBuilder.Entity<ShippingService>()
      .Property(f => f.Id)
      .ValueGeneratedOnAdd();

            modelBuilder.Entity<ShippingService>()
           .HasOne(p => p.Courier)
            .WithMany(b => b.Services)
            .HasForeignKey(y => y.CourierId);

            modelBuilder.Entity<Courier>()
           .HasKey("Id");


            modelBuilder.Entity<Courier>()
      .Property(f => f.Id)
      .ValueGeneratedOnAdd();











        }
    }
}
