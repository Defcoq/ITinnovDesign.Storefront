using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog
{
    public class BasketDetailView : BaseProductCatalogPageView
    {
        public BasketView Basket { get; set; }
        public IEnumerable<DeliveryOptionView> DeliveryOptions { get; set; }
    }

}
