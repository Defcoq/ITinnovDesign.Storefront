using ITinnovDesign.Storefront.Controllers;
using ITinnovDesign.Storefront.Controllers.Controllers;
using ITinnovDesign.Storefront.Controllers.JsonDTOs;
using ITinnovDesign.Storefront.Controllers.ViewModels;
using ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog;
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using ITinnovDesign.Storefront.Services.Implementations;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Controllers
{
    public class BasketController : ProductCatalogBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ICookieStorageService _cookieStorageService;

        public BasketController(IProductCatalogService productCatalogueService,
                                IBasketService basketService,
                                ICookieStorageService cookieStorageService)
            : base(cookieStorageService, productCatalogueService)
        {
            _basketService = basketService;
            _cookieStorageService = cookieStorageService;
        }

        public ActionResult Detail()
        {
            BasketDetailView basketView = new BasketDetailView();
            Guid basketId = base.GetBasketId();

            GetBasketRequest basketRequest = new GetBasketRequest() { BasketId = basketId };
            GetBasketResponse basketResponse =
                            _basketService.GetBasket(basketRequest);

            GetAllDispatchOptionsResponse dispatchOptionsResponse =
                                                _basketService.GetAllDispatchOptions();

            basketView.Basket = basketResponse.Basket;
            basketView.Categories = base.GetCategories();
            basketView.BasketSummary = base.GetBasketSummaryView();
            basketView.DeliveryOptions = dispatchOptionsResponse.DeliveryOptions;

            return View("View", basketView);
        }

        [HttpPost("RemoveItem")]
        public JsonResult RemoveItem(int productId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.ItemsToRemove.Add(productId);
            request.BasketId = base.GetBasketId();

            ModifyBasketResponse reponse = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(reponse.Basket.NumberOfItems,
                                      reponse.Basket.BasketTotal);

            BasketDetailView basketDetailView = new BasketDetailView();

            basketDetailView.BasketSummary = new BasketSummaryView()
            {
                BasketTotal = reponse.Basket.BasketTotal,
                NumberOfItems = reponse.Basket.NumberOfItems
            };

            basketDetailView.Basket = reponse.Basket;
            basketDetailView.DeliveryOptions =
                                  _basketService.GetAllDispatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }

        [HttpPost("UpdateShipping")]
        public JsonResult UpdateShipping(int shippingServiceId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.SetShippingServiceIdTo = shippingServiceId;
            request.BasketId = base.GetBasketId();

            BasketDetailView basketDetailView = new BasketDetailView();

            ModifyBasketResponse reponse = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(reponse.Basket.NumberOfItems,
                                      reponse.Basket.BasketTotal);

            basketDetailView.BasketSummary = new BasketSummaryView()
            {
                BasketTotal = reponse.Basket.BasketTotal,
                NumberOfItems = reponse.Basket.NumberOfItems
            };

            basketDetailView.Basket = reponse.Basket;
            basketDetailView.DeliveryOptions =
                            _basketService.GetAllDispatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }

        [HttpPost("UpdateItems")]
        public JsonResult UpdateItems(
                                JsonBasketQtyUpdateRequest jsonBasketQtyUpdateRequest)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.BasketId = base.GetBasketId();
            request.ItemsToUpdate = jsonBasketQtyUpdateRequest
                                           .ConvertToBasketItemUpdateRequests(); ;

            BasketDetailView basketDetailView = new BasketDetailView();
            ModifyBasketResponse reponse = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(reponse.Basket.NumberOfItems,
                                      reponse.Basket.BasketTotal);

            basketDetailView.BasketSummary = new BasketSummaryView()
            {
                BasketTotal = reponse.Basket.BasketTotal,
                NumberOfItems = reponse.Basket.NumberOfItems
            };

            basketDetailView.Basket = reponse.Basket;

            basketDetailView.DeliveryOptions = _basketService
                                         .GetAllDispatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }

        [HttpPost("AddToBasket")]
        public JsonResult AddToBasket(int productId)
        {
            BasketSummaryView basketSummaryView = new BasketSummaryView();
            Guid basketId = base.GetBasketId();
            bool createNewBasket = basketId == Guid.Empty;

            if (createNewBasket == false)
            {
                ModifyBasketRequest modifyBasketRequest =
                                       new ModifyBasketRequest();

                modifyBasketRequest.ProductsToAdd.Add(productId);
                modifyBasketRequest.BasketId = basketId;

                try
                {
                    ModifyBasketResponse response = _basketService
                                                      .ModifyBasket(modifyBasketRequest);
                    basketSummaryView = response.Basket.ConvertToSummary();
                    SaveBasketSummaryToCookie(basketSummaryView.NumberOfItems,
                                              basketSummaryView.BasketTotal);
                }
                catch (BasketDoesNotExistException ex)
                {
                    
                    createNewBasket = true;
                }
            }

            if (createNewBasket)
            {
                CreateBasketRequest createBasketRequest =
                                         new CreateBasketRequest();

                createBasketRequest.ProductsToAdd.Add(productId);

                CreateBasketResponse response = _basketService
                                                   .CreateBasket(createBasketRequest);

                SaveBasketIdToCookie(response.Basket.Id);
                basketSummaryView = response.Basket.ConvertToSummary();
                SaveBasketSummaryToCookie(basketSummaryView.NumberOfItems,
                                          basketSummaryView.BasketTotal);
            }

            return Json(basketSummaryView);
        }

        private void SaveBasketIdToCookie(Guid basketId)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketId.ToString(),
                                       basketId.ToString(), DateTime.Now.AddDays(1), HttpContext);
        }

        private void SaveBasketSummaryToCookie(int numberOfItems,
                                               string basketTotal)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketItems.ToString(),
                                      numberOfItems.ToString(), DateTime.Now.AddDays(1), HttpContext);
            _cookieStorageService.Save(CookieDataKeys.BasketTotal.ToString(),
                                       basketTotal.ToString(), DateTime.Now.AddDays(1), HttpContext);
        }
    }
}
