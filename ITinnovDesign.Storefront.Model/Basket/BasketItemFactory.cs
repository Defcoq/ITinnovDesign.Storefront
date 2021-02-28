using ITinnovDesign.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Basket
{
    public static class BasketItemFactory
    {
        public static BasketItem CreateItemFor(Product product, Basket basket)
        {
            return new BasketItem(product, basket, 1);
        }
    }
}
