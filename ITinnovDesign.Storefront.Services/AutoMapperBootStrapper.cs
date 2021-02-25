using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Helpers;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services
{
    public class AutoMapperBootStrapper : Profile
    {
        public AutoMapperBootStrapper()
        {
            ConfigureAutoMapper();
        }
        public  void ConfigureAutoMapper()
        {
            // Product Title
            CreateMap<ProductTitle, ProductSummaryView>();
            CreateMap<ProductTitle, ProductView>();
            CreateMap<Product, ProductSummaryView>();
            CreateMap<Product, ProductSizeOption>();

            // Category
            CreateMap<Category, CategoryView>();

            // IProductAttribute
            CreateMap<IProductAttribute, Refinement>();

            // Global Money Formatter
          

        }
    }

  
}
