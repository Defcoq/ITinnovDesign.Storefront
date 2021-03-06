using ITinnovDesign.Storefront.Controllers.ActionArguments;
using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.Controllers
{
    public abstract class BaseAccountController : Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly ICustomerService _customerService;
        protected readonly IActionArguments _actionArguments;

        public BaseAccountController(
                            ILocalAuthenticationService authenticationService,
                            ICustomerService customerService, IActionArguments actionArguments)
        {
            _authenticationService = authenticationService;
            _customerService = customerService;
            _actionArguments = actionArguments;

        }

        public ActionResult RedirectBasedOn(string returnUrl)
        {
            if (returnUrl == ActionArgumentKey.GoToCheckout.ToString())
                return RedirectToAction("Checkout", "Checkout");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionArgumentKey GetReturnActionFrom(string returnUrl)
        {
            if (!String.IsNullOrEmpty(returnUrl) &&
                                    returnUrl.ToLower().Contains("checkout"))
                return ActionArgumentKey.GoToCheckout;
            else
                return ActionArgumentKey.GoToAccount;
        }
    }

}
