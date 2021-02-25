using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog
{
    public class HomePageView : BaseProductCatalogPageView
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
