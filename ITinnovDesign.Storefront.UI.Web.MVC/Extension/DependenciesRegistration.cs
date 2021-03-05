using ITinnovDesign.Storefront.Infrastructure;
using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Customers;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Model.Shipping;
using ITinnovDesign.Storefront.Repository.EF;
using ITinnovDesign.Storefront.Services.Implementations;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.UI.Web.MVC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Extension
{
  
        public static class DependenciesRegistration
        {
          
            public static IServiceCollection AddServices(this
            IServiceCollection services)
            {
            services.AddTransient<IProductCatalogService, ProductCatalogService>()
                .AddTransient<IBasketService, BasketService>()
                .AddTransient<ICookieStorageService, CookieStorageService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<ILocalAuthenticationService, AspMembershipAuthentication>();
              
            
                return services;
               
            }


        public static IServiceCollection AddRepositories(this
           IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>()
                     .AddTransient<IProductRepository, ProductRepository>()
                     .AddTransient<IProductTitleRepository, ProductTitleRepository>()
                      .AddTransient<IBasketRepository, BasketRepository>()
                      .AddTransient<IDeliveryOptionRepository, DeliveryOptionRepository>()
                     .AddTransient<IUnitOfWorkRepository, FakeUnitOfWorkRepository>()
                     .AddTransient<IUnitOfWork, FakeUnitOfWork>()
                     .AddTransient<ICustomerRepository, CustomerRepository>();


            return services;

        }
    }
    
}
