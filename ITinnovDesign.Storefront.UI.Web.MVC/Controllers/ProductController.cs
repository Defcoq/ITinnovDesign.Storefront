using ITinnovDesign.Storefront.Controllers.Controllers;
using ITinnovDesign.Storefront.Controllers.JsonDTOs;
using ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog;
using ITinnovDesign.Storefront.Infrastructure.Configuration;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using ITinnovDesign.Storefront.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Controllers
{
    public class ProductController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productService;

        public ProductController(IProductCatalogService productService)
            : base(productService)
        {
            _productService = productService;
        }

        public ActionResult GetProductsByCategory(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest =
                        GenerateInitialProductSearchRequestFrom(categoryId);

            GetProductsByCategoryResponse response =
                        _productService.GetProductsByCategory(productSearchRequest);

            ProductSearchResultView productSearchResultView =
                        GetProductSearchResultViewFrom(response);

            return View("ProductSearchResults", productSearchResultView);
        }

        private ProductSearchResultView GetProductSearchResultViewFrom(
                                      GetProductsByCategoryResponse response)
        {
            ProductSearchResultView productSearchResultView =
                                              new ProductSearchResultView();

            productSearchResultView.Categories = base.GetCategories();
            productSearchResultView.CurrentPage = response.CurrentPage;
            productSearchResultView.NumberOfTitlesFound = response.NumberOfTitlesFound;
            productSearchResultView.Products = response.Products;
            productSearchResultView.RefinementGroups = response.RefinementGroups;
            productSearchResultView.SelectedCategory = response.SelectedCategory;
            productSearchResultView.SelectedCategoryName = response.SelectedCategoryName;
            productSearchResultView.TotalNumberOfPages = response.TotalNumberOfPages;
            return productSearchResultView;
        }

        private static GetProductsByCategoryRequest
                               GenerateInitialProductSearchRequestFrom(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest =
                                     new GetProductsByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = int.Parse(ApplicationSettingsFactory
                                     .GetApplicationSettings().NumberOfResultsPerPage);
            productSearchRequest.CategoryId = categoryId;
            productSearchRequest.Index = 1;
            productSearchRequest.SortBy = ProductsSortBy.PriceHighToLow;
            return productSearchRequest;
        }

       [HttpPost("GetProductsByAjax")]
        public JsonResult GetProductsByAjax(
                                JsonProductSearchRequest jsonProductSearchRequest)
        {
            GetProductsByCategoryRequest productSearchRequest =
                         GenerateProductSearchRequestFrom(jsonProductSearchRequest);
            GetProductsByCategoryResponse response =
                         _productService.GetProductsByCategory(productSearchRequest);

            ProductSearchResultView productSearchResultView =
                         GetProductSearchResultViewFrom(response);

            return Json(productSearchResultView);
        }

        private static GetProductsByCategoryRequest GenerateProductSearchRequestFrom(
                                      JsonProductSearchRequest jsonProductSearchRequest)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();

            productSearchRequest.NumberOfResultsPerPage = int.Parse(ApplicationSettingsFactory.GetApplicationSettings().NumberOfResultsPerPage);
            productSearchRequest.Index = jsonProductSearchRequest.Index;
            productSearchRequest.CategoryId = jsonProductSearchRequest.CategoryId;
            productSearchRequest.SortBy = jsonProductSearchRequest.SortBy;

            List<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            RefinementGroup refinementGroup;

            foreach (JsonRefinementGroup jsonRefinementGroup in
                                        jsonProductSearchRequest.RefinementGroups)
            {
                switch ((RefinementGroupings)jsonRefinementGroup.GroupId)
                {
                    case RefinementGroupings.brand:
                        productSearchRequest.BrandIds =
                                     jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.color:
                        productSearchRequest.ColorIds =
                                     jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.size:
                        productSearchRequest.SizeIds =
                                     jsonRefinementGroup.SelectedRefinements;
                        break;
                    default:
                        break;
                }
            }
            return productSearchRequest;
        }

        public ActionResult Detail(int id)
        {
            ProductDetailView productDetailView = new ProductDetailView();
            GetProductRequest request = new GetProductRequest() { ProductId = id };
            GetProductResponse response = _productService.GetProduct(request);

            ProductView productView = response.Product;

            productDetailView.Product = productView;
            productDetailView.Categories = base.GetCategories();

            return View(productDetailView);
        }
    }
}
