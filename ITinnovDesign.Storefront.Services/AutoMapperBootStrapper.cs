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
            CreateMap<DeliveryOption, DeliveryOptionView>().ForMember(x => x.ShippingServiceDescription, y => y.MapFrom(z => z.ShippingService.Description));
            CreateMap<BasketItem, BasketItemView>().ForMember(x => x.ProductId, y => y.MapFrom(z => z.Product.Id))
                                                    .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.Name))
                                                    .ForMember(x => x.ProductPrice, y => y.MapFrom(z => z.Product.Price.ToString()))
                                                     .ForMember(x => x.LineTotal, y => y.MapFrom(z => z.LineTotal().ToString()))
                                                     .ForMember(x => x.Qty, y => y.MapFrom(z => z.Qty))
                                                     .ForMember(x => x.ProductSizeName, y => y.MapFrom(z => z.Product.Size.Name));
                                                    
            CreateMap<Basket, BasketView>().ForMember(x => x.Items, y => y.MapFrom(z => z.Items))
                                           .ForMember(x => x.ItemsTotal, y => y.MapFrom(z => z.ItemsTotal.ToString()))
                                           .ForMember(x => x.NumberOfItems, y => y.MapFrom(z => z.NumberOfItems))
                                           .ForMember(x => x.ShippingServiceDescription, y => y.MapFrom(z => z.DeliveryOption.ToString()))
                                           .ForMember(x => x.BasketTotal, y => y.MapFrom(z => z.BasketTotal.ToString()))
                                           .ForMember(x => x.DeliveryCost, y => y.MapFrom(z => z.DeliveryCost().ToString()))
                                           .ForMember(x => x.DeliveryOptionId, y => y.MapFrom(z => z.DeliveryOption.Id))
                                           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            // Global Money Formatter


        }
    }

  
}
