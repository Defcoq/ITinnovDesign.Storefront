using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
