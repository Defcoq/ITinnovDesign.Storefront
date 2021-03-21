using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Controllers.ViewModels.CustomerAccount;
using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.CustomerService;
using ITinnovDesign.Storefront.Services.Messaging.OrderService;
using Microsoft.AspNetCore.Identity;
using ITinnovDesign.Storefront.UI.Web.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITinnovDesign.Storefront.Controllers.Controllers
{
    public class OrderController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrderController(ICustomerService customerService,
                               IOrderService orderService,
                               ICookieStorageService cookieStorageService, 
                               SignInManager<ApplicationUser> signInManager, 
                               UserManager<ApplicationUser> userManager)
            : base(cookieStorageService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public ActionResult List()
        {
            GetCustomerRequest request = new GetCustomerRequest()
            {
                CustomerIdentityToken = _userManager.GetUserAsync(HttpContext.User).Result.Id,
                LoadOrderSummary = true
            };

            GetCustomerResponse response = _customerService.GetCustomer(request);

            CustomersOrderSummaryView customersOrderSummaryView =
                                                new CustomersOrderSummaryView();
            customersOrderSummaryView.Orders = response.Orders;
            customersOrderSummaryView.BasketSummary = base.GetBasketSummaryView();

            return View(customersOrderSummaryView);
        }

        [Authorize]
        public ActionResult Detail(int orderId)
        {
            GetOrderRequest request = new GetOrderRequest() { OrderId = orderId };
            GetOrderResponse response = _orderService.GetOrder(request);

            CustomerOrderView orderView = new CustomerOrderView();
            orderView.BasketSummary = base.GetBasketSummaryView();
            orderView.Order = response.Order;

            return View(orderView);
        }
    }

}
