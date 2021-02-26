using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
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
            .HasOne(p => p.Brand);


            modelBuilder.Entity<ProductTitle>()
              .HasOne(p => p.Category);

            modelBuilder.Entity<ProductTitle>()
             .HasOne(p => p.Color);

            modelBuilder.Entity<ProductColor>()
           .HasKey("Id");


            modelBuilder.Entity<ProductSize>()
            .HasKey("Id");

            modelBuilder.Entity<Brand>()
           .HasKey("Id");








        }
    }
}
