using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.CookieStorage
{
    public interface ICookieStorageService
    {
        void Save(string key, string value, DateTime expires, HttpContext ctx);
        string Retrieve(string key, HttpContext ctx);
    }
}
