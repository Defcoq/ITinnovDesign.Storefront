using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Payments
{
    public interface IPaymentService
    {
        PaymentPostData GeneratePostDataFor(OrderPaymentRequest orderRequest, HttpContext ctx);
        TransactionResult HandleCallBack(OrderPaymentRequest orderRequest,
                                         FormCollection collection, HttpContext ctx);
        int GetOrderIdFor(FormCollection collection);
    }

}
