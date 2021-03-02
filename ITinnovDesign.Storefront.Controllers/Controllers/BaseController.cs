using ITinnovDesign.Storefront.Controllers.ViewModels;
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICookieStorageService _cookieStorageService;

        public BaseController(ICookieStorageService cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
        }

        public BasketSummaryView GetBasketSummaryView()
        {
            string basketTotal = "";
            int numberOfItems = 0;

            if (!string.IsNullOrEmpty(_cookieStorageService.Retrieve(
                                            CookieDataKeys.BasketTotal.ToString(), HttpContext)))
                basketTotal = _cookieStorageService.Retrieve(
                                            CookieDataKeys.BasketTotal.ToString(), HttpContext);

            if (!string.IsNullOrEmpty(_cookieStorageService.Retrieve(
                                            CookieDataKeys.BasketItems.ToString(), HttpContext)))
                numberOfItems = int.Parse(_cookieStorageService.Retrieve(
                                            CookieDataKeys.BasketItems.ToString(), HttpContext));

            return new BasketSummaryView
            {
                BasketTotal = basketTotal,
                NumberOfItems = numberOfItems
            };
        }

        public Guid GetBasketId()
        {
            string sBasketId = _cookieStorageService.Retrieve(CookieDataKeys.BasketId.ToString(), HttpContext);
            Guid basketId = Guid.Empty;

            if (!string.IsNullOrEmpty(sBasketId))
            {
                basketId = new Guid(sBasketId);
            }

            return basketId;
        }
    }
}
