using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.ActionArguments
{
    public interface IActionArguments
    {
        string GetValueForArgument(ActionArgumentKey key, HttpContext ctx);
    }
}
