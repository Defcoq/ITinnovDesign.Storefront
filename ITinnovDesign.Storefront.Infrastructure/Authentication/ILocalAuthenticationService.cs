using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Authentication
{
    public interface ILocalAuthenticationService
    {
        User Login(string email, string password, HttpContext ctx);
        User RegisterUser(string email, string password, HttpContext ctx);
    }
}
