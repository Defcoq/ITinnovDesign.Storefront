using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService
    {
        public void Save(string key, string value, DateTime expires, HttpContext ctx)
        {

            ctx.Response.Cookies.Append(key, value, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = expires
            });
         
        }

        public string Retrieve(string key, HttpContext ctx)
        {
            var cookie = ctx.Request.Cookies[key];
            if (cookie != null)
                return cookie;
            return "";
        }
    }
}
