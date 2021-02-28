using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Shipping
{
    public interface IDeliveryOption
    {
        int Id { get; set; }
        decimal FreeDeliveryThreshold { get; }
        decimal Cost { get; }
        ShippingService ShippingService { get; }
        decimal GetDeliveryChargeForBasketTotalOf(decimal total);
    }
}
