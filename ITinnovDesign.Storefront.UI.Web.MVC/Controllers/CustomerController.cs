using ITinnovDesign.Storefront.Controllers.Controllers;
using ITinnovDesign.Storefront.Controllers.ViewModels.CustomerAccount;
using ITinnovDesign.Storefront.Infrastructure.CookieStorage;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.CustomerService;
using ITinnovDesign.Storefront.Services.ViewModels;
using ITinnovDesign.Storefront.UI.Web.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        //private readonly IFormsAuthentication _formsAuthentication;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
       // IdentityUser _user;
        string UserId;
        public CustomerController(ICookieStorageService cookieStorageService,
                                  ICustomerService customerService,
                                  SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager
                               )
            : base(cookieStorageService)
        {
            _customerService = customerService;
            _userManager = userManager;
            _signInManager = signInManager;
            //  _user = _userManager.GetUserAsync(HttpContext.User).Result;
            // _formsAuthentication = formsAuthentication;
          
        }

        [Authorize]
        public ActionResult Detail()
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest();
           
            customerRequest.CustomerIdentityToken = HttpContext.Session.GetString("USERID"); ;

            GetCustomerResponse response = _customerService.GetCustomer(customerRequest);

            CustomerDetailView customerDetailView = new CustomerDetailView();
            customerDetailView.Customer = response.Customer;
            customerDetailView.BasketSummary = base.GetBasketSummaryView();

            return View(customerDetailView);
        }

        [Authorize]
        [HttpPost("DetailPost")]
        public ActionResult DetailPost(CustomerView customerView)
        {
            ModifyCustomerRequest request = new ModifyCustomerRequest();
           
            request.CustomerIdentityToken = HttpContext.Session.GetString("USERID"); ;
            request.Email = customerView.Email;
            request.FirstName = customerView.FirstName;
            request.SecondName = customerView.SecondName;

            ModifyCustomerResponse response = _customerService.ModifyCustomer(request);

            CustomerDetailView customerDetailView = new CustomerDetailView();

            customerDetailView.Customer = response.Customer;
            customerDetailView.BasketSummary = base.GetBasketSummaryView();

            return View(customerDetailView);
        }

        [Authorize]
        public ActionResult DeliveryAddresses()
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerIdentityToken = HttpContext.Session.GetString("USERID");

            GetCustomerResponse response = _customerService.GetCustomer(customerRequest);

            CustomerDetailView customerDetailView = new CustomerDetailView();

            customerDetailView.Customer = response.Customer;
            customerDetailView.BasketSummary = base.GetBasketSummaryView();

            return View("DeliveryAddresses", customerDetailView);
        }

        [Authorize]
        public ActionResult EditDeliveryAddress(int deliveryAddressId)
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerIdentityToken = HttpContext.Session.GetString("USERID"); 
            GetCustomerResponse response = _customerService.GetCustomer(customerRequest);

            CustomerDeliveryAddressView deliveryAddressView =
                                        new CustomerDeliveryAddressView();

            deliveryAddressView.CustomerView = response.Customer;
            deliveryAddressView.Address =
                response.Customer.DeliveryAddressBook
                                 .Where(d => d.Id == deliveryAddressId).FirstOrDefault();
            deliveryAddressView.BasketSummary = base.GetBasketSummaryView();

            return View(deliveryAddressView);
        }

        [Authorize]
        [HttpPost("EditDeliveryAddressPost")]
        public ActionResult EditDeliveryAddressPost(DeliveryAddressView deliveryAddressView)
        {
            DeliveryAddressModifyRequest request = new DeliveryAddressModifyRequest();
            request.Address = deliveryAddressView;
            request.CustomerIdentityToken = HttpContext.Session.GetString("USERID"); ;

            _customerService.ModifyDeliveryAddress(request);

            return DeliveryAddresses();
        }

        [Authorize]
        public ActionResult AddDeliveryAddress()
        {
            CustomerDeliveryAddressView customerDeliveryAddressView =
                                                new CustomerDeliveryAddressView();

            customerDeliveryAddressView.Address = new DeliveryAddressView();
            customerDeliveryAddressView.BasketSummary = base.GetBasketSummaryView();

            return View(customerDeliveryAddressView);
        }

        [Authorize]
       [ HttpPost("AddDeliveryAddressPost")]
        public ActionResult AddDeliveryAddressPost(DeliveryAddressView deliveryAddressView)
        {
            DeliveryAddressAddRequest request = new DeliveryAddressAddRequest();
            request.Address = deliveryAddressView;
            request.CustomerIdentityToken = HttpContext.Session.GetString("USERID"); ;

            _customerService.AddDeliveryAddress(request);

            return DeliveryAddresses();
        }
    }
}
