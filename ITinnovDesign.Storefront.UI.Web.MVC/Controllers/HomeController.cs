using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITinnovDesign.Storefront.UI.Web.MVC.Models;
using ITinnovDesign.Storefront.Controllers.Controllers;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Controllers
{

    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;
        public HomeController(IProductCatalogService productCatalogService)
        : base(productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            GetFeaturedProductsResponse response =_productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;
            return View(homePageView);
        }
    }
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}
}
