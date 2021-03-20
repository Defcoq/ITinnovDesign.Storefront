using AutoMapper;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Orders;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class BasketMapper
    {
        public static BasketView ConvertToBasketView(this Basket basket, IMapper _mapper)
        {
            return _mapper.Map<Basket, BasketView>(basket);
        }


        public static Order ConvertToOrder(this Basket basket)
        {
            Order order = new Order();
            order.ShippingCharge = basket.DeliveryCost();
            order.ShippingService = basket.DeliveryOption.ShippingService;
            foreach (BasketItem item in basket.Items)
            {
                order.AddItem(item.Product, item.Qty);
            }
            return order;
        }
    }
}
