using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Helpers;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Model.Shipping;
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
            CreateMap<ProductTitle, ProductSummaryView>().ForMember(x => x.BrandName, y => y.MapFrom(z => z.Brand.Name));
            CreateMap<ProductTitle, ProductView>().ForMember(x => x.BrandName, y => y.MapFrom(z => z.Brand.Name));
            CreateMap<Product, ProductSummaryView>().ForMember(x=>x.BrandName, y => y.MapFrom(z => z.Brand.Name));
            CreateMap<Product, ProductSizeOption>();

            // Category
            CreateMap<Category, CategoryView>();

            // IProductAttribute
            CreateMap<IProductAttribute, Refinement>();

            // IProductAttribute
         

            // Basket
            CreateMap<DeliveryOption, DeliveryOptionView>();
            CreateMap<BasketItem, BasketItemView>();
            CreateMap<Basket, BasketView>();

            // Global Money Formatter


        }
    }

  
}
