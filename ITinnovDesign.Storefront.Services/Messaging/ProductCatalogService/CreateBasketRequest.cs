using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService
{
    public class CreateBasketRequest
    {
        public CreateBasketRequest()
        {
            ProductsToAdd = new List<int>();
        }
        public IList<int> ProductsToAdd { get; set; }
    }
}
