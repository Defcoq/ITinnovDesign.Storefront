using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using ITinnovDesign.Storefront.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.Controllers
{
   public class ProductCatalogBaseController : Controller
    {
        private readonly IProductCatalogService _productCatalogService;
        public ProductCatalogBaseController(
        IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }
        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response = _productCatalogService.GetAllCategories();
            return response.Categories;
        }
    }
}
