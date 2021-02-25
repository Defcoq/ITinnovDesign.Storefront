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
    }
}
