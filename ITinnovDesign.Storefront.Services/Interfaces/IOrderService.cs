using ITinnovDesign.Storefront.Services.Messaging.OrderService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Interfaces
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        SetOrderPaymentResponse SetOrderPayment(SetOrderPaymentRequest paymentRequest);
        GetOrderResponse GetOrder(GetOrderRequest request);
    }
}
