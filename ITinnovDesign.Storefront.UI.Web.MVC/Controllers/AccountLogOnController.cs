using ITinnovDesign.Storefront.Controllers.ActionArguments;
using ITinnovDesign.Storefront.Controllers.Controllers;
using ITinnovDesign.Storefront.Controllers.ViewModels.Account;
using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.Services.Interfaces;
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
    public class AccountLogOnController : BaseAccountController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountLogOnController(
                            ILocalAuthenticationService authenticationService,
                            ICustomerService customerService,
                            IActionArguments actionArguments, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
            : base(authenticationService, customerService, actionArguments)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public ActionResult LogOn()
        {
            AccountView accountView = InitializeAccountViewWithIssue(false, "");

            return View(accountView);
        }

        [HttpPost("LogOnPost")]
        public ActionResult LogOnPost(string email, string password, string returnUrl)
        {
            User user = _authenticationService.Login(email, password, HttpContext);

            if (user.IsAuthenticated)
            {

                HttpContext.Session.SetString("USERID", user.AuthenticationToken);
            

                if (!String.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true,
                                "Sorry we could not log you in. " +
                                " Please try again.");
                accountView.CallBackSettings.ReturnUrl =
                                          GetReturnActionFrom(returnUrl).ToString();

                return View("LogOn", accountView);
            }
        }

       

        public ActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private AccountView InitializeAccountViewWithIssue(bool hasIssue,
                                                           string message)
        {
            AccountView accountView = new AccountView();
            accountView.CallBackSettings.Action = "ReceiveTokenAndLogon";
            accountView.CallBackSettings.Controller = "AccountLogOn";
            accountView.HasIssue = hasIssue;
            accountView.Message = message;

            string returnUrl = _actionArguments
                               .GetValueForArgument(ActionArgumentKey.ReturnUrl, HttpContext);
            accountView.CallBackSettings.ReturnUrl =
                                GetReturnActionFrom(returnUrl).ToString();

            return accountView;
        }
    }
}
