using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Interfaces
{
    public interface IBasketService
    {
        GetBasketResponse GetBasket(GetBasketRequest basketRequest);
        CreateBasketResponse CreateBasket(CreateBasketRequest basketRequest);
        ModifyBasketResponse ModifyBasket(ModifyBasketRequest request);
        GetAllDispatchOptionsResponse GetAllDispatchOptions();
    }
}
