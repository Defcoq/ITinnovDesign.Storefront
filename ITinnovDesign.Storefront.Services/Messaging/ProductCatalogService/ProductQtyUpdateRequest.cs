using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService
{
    public class ProductQtyUpdateRequest
    {
        public int ProductId { get; set; }
        public int NewQty { get; set; }
    }
}
