﻿using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Helpers;
using ITinnovDesign.Storefront.Infrastructure.Payments;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Customers;
using ITinnovDesign.Storefront.Model.Orders;
using ITinnovDesign.Storefront.Model.Orders.States;
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

            // Customer
            CreateMap<Customer, CustomerView>();
            CreateMap<DeliveryAddress, DeliveryAddressView>();

            //Order
            CreateMap<Order, OrderView>();
            CreateMap<OrderItem, OrderItemView>();
            CreateMap<Address, DeliveryAddressView>();
            CreateMap<Order, OrderSummaryView>()
            .ForMember(o => o.IsSubmitted,
            opt => opt.MapFrom
                   (src => src.Status == OrderStatus.Submitted ? true: false));

            CreateMap<OrderView, OrderPaymentRequest>()
                .ForMember(o => o.Total, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Total) ? decimal.Parse(src.Total.Substring(1, src.Total.Length - 1)) : 0))
                .ForMember(o => o.ShippingCharge, opt => opt.MapFrom(src => decimal.Parse(src.ShippingCharge.Substring(1, src.ShippingCharge.Length - 1))));


            CreateMap<OrderItemView, OrderItemPaymentRequest>()
                .ForMember(o => o.Price, opt => opt.MapFrom(src => decimal.Parse(src.Price.Substring(1, src.Price.Length - 1))));


        }

       

    }




}
