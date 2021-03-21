using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Controllers.ViewModels.Checkout;
using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.CustomerService;
using ITinnovDesign.Storefront.Services.Messaging.OrderService;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using ITinnovDesign.Storefront.Services.ViewModels;
using ITinnovDesign.Storefront.UI.Web.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITinnovDesign.Storefront.Controllers.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ICookieStorageService _cookieStorageService;
        private readonly IBasketService _basketService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CheckoutController(ICookieStorageService cookieStorageService,
                                  IBasketService basketService,
                                  ICustomerService customerService,
                                  IOrderService orderService,
                                SignInManager<ApplicationUser> signInManager,
                               UserManager<ApplicationUser> userManager)
            : base(cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
            _basketService = basketService;
            _customerService = customerService;
            _orderService = orderService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public ActionResult Checkout()
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest()
            {
                CustomerIdentityToken = _userManager.GetUserAsync(HttpContext.User).Result.Id
            };

            GetCustomerResponse customerResponse =
                            _customerService.GetCustomer(customerRequest);
            CustomerView customerView = customerResponse.Customer;


            if (customerView.DeliveryAddressBook.Count() > 0)
            {
                OrderConfirmationView orderConfirmationView =
                                         new OrderConfirmationView();
                GetBasketRequest getBasketRequest = new GetBasketRequest()
                {
                    BasketId = base.GetBasketId()
                };

                GetBasketResponse basketResponse =
                                       _basketService.GetBasket(getBasketRequest);

                orderConfirmationView.Basket = basketResponse.Basket;
                orderConfirmationView.DeliveryAddresses =
                                       customerView.DeliveryAddressBook;

                return View("ConfirmOrder", orderConfirmationView);
            }

            return AddDeliveryAddress();
        }

        [Authorize]
        public ActionResult AddDeliveryAddress()
        {
            DeliveryAddressView deliveryAddressView = new DeliveryAddressView();
            return View("AddDeliveryAddress", deliveryAddressView);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddDeliveryAddressPost(DeliveryAddressView deliveryAddressView)
        {
            DeliveryAddressAddRequest request = new DeliveryAddressAddRequest();
            request.Address = deliveryAddressView;
            request.CustomerIdentityToken = _userManager.GetUserAsync(HttpContext.User).Result.Id;

            _customerService.AddDeliveryAddress(request);

            return Checkout();
        }

        [Authorize]
        public ActionResult PlaceOrder(IFormCollection collection)
        {
            CreateOrderRequest request = new CreateOrderRequest();
            request.BasketId = base.GetBasketId();
            request.CustomerIdentityToken = _userManager.GetUserAsync(HttpContext.User).Result.Id;
            request.DeliveryId =
                   int.Parse(collection[FormDataKeys.DeliveryAddress.ToString()]);

            CreateOrderResponse response = _orderService.CreateOrder(request);


            _cookieStorageService.Save(CookieDataKeys.BasketItems.ToString(),
                                       "0", DateTime.Now.AddDays(1), HttpContext);
            _cookieStorageService.Save(CookieDataKeys.BasketTotal.ToString(),
                                       "0", DateTime.Now.AddDays(1),HttpContext);

            return RedirectToAction("CreatePaymentFor", "Payment",
                                    new { orderId = response.Order.Id });
        }
    }

}
