using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string resource, HttpContext ctx)
        {
            return string.Format("{0}://{1}{2}{3}",
                  ctx.Request.Scheme,
                  ctx.Request.Host.Host,
                  (ctx.Request.Path.Equals("/")) ?
                            string.Empty : ctx.Request.Path.Value,
                  resource);
        }
    }
}
