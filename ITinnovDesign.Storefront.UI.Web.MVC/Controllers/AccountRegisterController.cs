using ITinnovDesign.Storefront.Controllers;
using ITinnovDesign.Storefront.Controllers.ActionArguments;
using ITinnovDesign.Storefront.Controllers.Controllers;
using ITinnovDesign.Storefront.Controllers.ViewModels.Account;
using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.Services.Implementations;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.CustomerService;
using ITinnovDesign.Storefront.UI.Web.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Controllers
{
    public class AccountRegisterController : BaseAccountController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountRegisterController(
                            ILocalAuthenticationService authenticationService,
                            ICustomerService customerService,
                            IActionArguments actionArguments, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
            : base(authenticationService, customerService, actionArguments)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {
            AccountView accountView = InitializeAccountViewWithIssue(false,
                                                                     string.Empty);

            return View(accountView);
        }


        [HttpPost("RegisterPost")]
        public ActionResult RegisterPost(IFormCollection collection)
        {
            User user;

            string password = collection[FormDataKeys.Password.ToString()];
            string email = collection[FormDataKeys.Email.ToString()];
            string firstName = collection[FormDataKeys.FirstName.ToString()];
            string secondName = collection[FormDataKeys.SecondName.ToString()];

            try
            {
                user = _authenticationService.RegisterUser(email, password, HttpContext);
            }
            catch (InvalidOperationException ex)
            {
                AccountView accountView = InitializeAccountViewWithIssue(
                                                             true,
                                                                         ex.Message);

                return View(accountView);
            }

            if (user.IsAuthenticated)
            {
                try
                {
                    CreateCustomerRequest createCustomerRequest =
                                            new CreateCustomerRequest();
                    createCustomerRequest.CustomerIdentityToken =
                                            user.AuthenticationToken;
                    createCustomerRequest.Email = email;
                    createCustomerRequest.FirstName = firstName;
                    createCustomerRequest.SecondName = secondName;

                    _customerService.CreateCustomer(createCustomerRequest);

                    return RedirectToAction("Detail", "Customer");
                }
                catch (CustomerInvalidException ex)
                {
                    AccountView accountView = InitializeAccountViewWithIssue(
                                                                 true,
                                                                             ex.Message);

                    return View(accountView);
                }
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true,
                               "Sorry we could not authenticate you. " +
                               " Please try again.");

                return View(accountView);
            }
        }

 

        private AccountView InitializeAccountViewWithIssue(bool hasIssue,
                                                           string message)
        {
            AccountView accountView = new AccountView();
            accountView.CallBackSettings.Action = "ReceiveTokenAndRegister";
            accountView.CallBackSettings.Controller = "AccountRegister";
            accountView.HasIssue = hasIssue;
            accountView.Message = message;

            string returnUrl = _actionArguments.GetValueForArgument(ActionArgumentKey.ReturnUrl, HttpContext);
            accountView.CallBackSettings.ReturnUrl =
                       GetReturnActionFrom(returnUrl).ToString();

            return accountView;
        }
    }
}
