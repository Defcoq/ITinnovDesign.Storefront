using ITinnovDesign.Storefront.Infrastructure;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Repository.EF;
using ITinnovDesign.Storefront.Services.Implementations;
using ITinnovDesign.Storefront.Services.Interfaces;
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
            services.AddTransient<IProductCatalogService, ProductCatalogService>();
              
            
                return services;
               
            }


        public static IServiceCollection AddRepositories(this
           IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>()
                     .AddTransient<IProductRepository, ProductRepository>()
                     .AddTransient<IProductTitleRepository, ProductTitleRepository>()
                     .AddTransient<IUnitOfWorkRepository, FakeUnitOfWorkRepository>()
                     .AddTransient<IUnitOfWork, FakeUnitOfWork>();


            return services;

        }
    }
    
}
