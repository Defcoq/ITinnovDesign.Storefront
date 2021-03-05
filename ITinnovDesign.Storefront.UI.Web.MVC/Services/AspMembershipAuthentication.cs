using ITinnovDesign.Storefront.Infrastructure.Authentication;
using ITinnovDesign.Storefront.UI.Web.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Services
{
    public class AspMembershipAuthentication : ILocalAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AspMembershipAuthentication> _logger;
        public AspMembershipAuthentication(SignInManager<IdentityUser> signInManager,
            ILogger<AspMembershipAuthentication> logger,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public User Login(string email, string password, HttpContext ctx )
        {
            
            var tokenFromCustest = ctx.GetTokenAsync("access_token");
            User user = new User();
            user.IsAuthenticated = false;
            var result = _signInManager.PasswordSignInAsync(email, password,false, lockoutOnFailure: false).Result;
            
            if (result.Succeeded)
            {
                var userSignin = _userManager.FindByNameAsync(email).Result;
                _logger.LogInformation("User logged in.");
                user.AuthenticationToken = _userManager.GetAuthenticationTokenAsync(userSignin, "Default", "access_token").Result;
                user.Email = email;
                user.IsAuthenticated = true;
        
            }

           

            return user;
        }

        public User RegisterUser(string email, string password, HttpContext ctx)
        {
         
            User user = new User();
            user.IsAuthenticated = false;
            var userIdentity = new ApplicationUser { UserName = email, Email = email};
            var result =  _userManager.CreateAsync(userIdentity, password).Result;

            if (result.Succeeded)
            {
                _logger.LogInformation("ITInnovDesign  User created a new account with password.");
                var userSignin = _userManager.FindByNameAsync(email).Result;
                _logger.LogInformation("User logged in.");
                user.AuthenticationToken = _userManager.GetAuthenticationTokenAsync(userSignin, "Default", "access_token").Result;
                user.Email = email;
                user.IsAuthenticated = true;

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    throw new InvalidOperationException(error.Description);
                   
                }
            }

            return user;
        }
    }
}
