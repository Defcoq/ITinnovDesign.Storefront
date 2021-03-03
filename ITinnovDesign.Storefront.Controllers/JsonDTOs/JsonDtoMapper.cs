﻿using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
    public static class JsonDtoMapper
    {
        public static IList<ProductQtyUpdateRequest>
          ConvertToBasketItemUpdateRequests(
                              this JsonBasketQtyUpdateRequest jsonBasketQtyUpdateRequest)
        {
            return jsonBasketQtyUpdateRequest.Items
                         .ConvertToBasketItemUpdateRequests();
        }

        public static IList<ProductQtyUpdateRequest>
          ConvertToBasketItemUpdateRequests(
                        this JsonBasketItemUpdateRequest[] jsonBasketItemUpdateRequests)
        {
            int i = 0;
            IList<ProductQtyUpdateRequest> basketItemUpdateRequests =
                                                    new List<ProductQtyUpdateRequest>();

            for (i = 0; i < jsonBasketItemUpdateRequests.Length; i++)
            {
                basketItemUpdateRequests.Add(
                    jsonBasketItemUpdateRequests[i]
                           .ConvertToBasketItemUpdateRequest());
            }

            return basketItemUpdateRequests;
        }

        public static ProductQtyUpdateRequest ConvertToBasketItemUpdateRequest(
                           this JsonBasketItemUpdateRequest jsonBasketItemUpdateRequest)
        {
            return new ProductQtyUpdateRequest
            {
                ProductId = jsonBasketItemUpdateRequest.ProductId,
                NewQty = jsonBasketItemUpdateRequest.Qty
            };
        }
    }
}