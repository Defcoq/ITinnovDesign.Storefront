using ITinnovDesign.Storefront.Controllers.ViewModels;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers
{
    public static class BasketMapper
    {
        public static BasketSummaryView ConvertToSummary(this BasketView basket)
        {
            return new BasketSummaryView()
            {
                BasketTotal = basket.BasketTotal,
                NumberOfItems = basket.NumberOfItems
            };
        }
    }
}
