using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.ActionArguments
{
    public class HttpRequestActionArguments : IActionArguments
    {
        public string GetValueForArgument(ActionArgumentKey key, HttpContext ctx)
        {
            return ctx.Request.Query[key.ToString()];
        }
    }
}
