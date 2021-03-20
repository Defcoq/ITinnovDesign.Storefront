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
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using ITinnovDesign.Storefront.UI.Web.MVC.Helpers;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Controllers
{

    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;
        //public HomeController(IProductCatalogService productCatalogService)
        //: base(productCatalogService)
        //{
        //    _productCatalogService = productCatalogService;
        //}

        public HomeController(IProductCatalogService productCatalogService,ICookieStorageService cookieStorageService): base(cookieStorageService, productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            GetFeaturedProductsResponse response =_productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;
            homePageView.BasketSummary = base.GetBasketSummaryView();
            return View(homePageView);
        }

      //  [HttpGet("PrintReport")]
        public async Task<JsonResult> PrintReport()
        {
            int id = 1;
            int id2 = 11;
            string pdfPath = string.Empty;
            var exePath = @"C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\CrystalReportTest\bin\Debug\CrystalReportTest.exe";



            //    var result = ProcessAsyncHelper.ExecuteShellCommand(exePath, "3", 5000 * 10).Result;
            //    pdfPath = result.Output;
            //while(string.IsNullOrEmpty(pdfPath))
            //{
            //    pdfPath = result.Output;
            //}
            //    return Json(pdfPath);

            using (var process = new Process())
            {
                process.StartInfo.FileName = @"C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\CrystalReportTest\bin\Debug\CrystalReportTest.exe"; // relative path. absolute path works too.
                process.StartInfo.Arguments = $"{id} {id2}";
                //process.StartInfo.FileName = @"cmd.exe";
                //process.StartInfo.Arguments = @"/c dir";      // print the current working directory information
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.OutputDataReceived += (sender, data) =>
                {
                    Debug.WriteLine("this is what is comming from exe => " + data.Data);
                    pdfPath = data.Data;
                };
                process.ErrorDataReceived += (sender, data) => Debug.WriteLine("ERRROR this is what is comming from exe => " + data.Data);
                Debug.WriteLine("starting");
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                //var exited = process.WaitForExit(10000 * 10);
                process.WaitForExit();
                process.Exited += Process_Exited;       

                // bool verify = true;
                //while(!exited)
                //{
                //    exited = process.WaitForExit(1000 * 10);
                //}

                process.Close();

                //  Debug.WriteLine($"exit {exited}");
            }


            return Json(pdfPath);
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            
            throw new NotImplementedException();
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
