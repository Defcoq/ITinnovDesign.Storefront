using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Logging;
using ITinnovDesign.Storefront.Infrastructure.Payments;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Mapping;
using ITinnovDesign.Storefront.Services.Messaging.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITinnovDesign.Storefront.Controllers.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public PaymentController(IPaymentService paymentService,
                                 IOrderService orderService, IMapper mapper, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("PaymentCallBack")]
        public void PaymentCallBack(FormCollection collection)
        {
            int orderId = _paymentService.GetOrderIdFor(collection);
            GetOrderRequest request = new GetOrderRequest() { OrderId = orderId };

            GetOrderResponse response = _orderService.GetOrder(request);

            OrderPaymentRequest orderPaymentRequest =
                   response.Order.ConvertToOrderPaymentRequest(_mapper);

            TransactionResult transactionResult =
                   _paymentService.HandleCallBack(orderPaymentRequest, collection, HttpContext);

            if (transactionResult.PaymentOk)
            {
                SetOrderPaymentRequest paymentRequest = new SetOrderPaymentRequest();
                paymentRequest.Amount = transactionResult.Amount;
                paymentRequest.PaymentToken = transactionResult.PaymentToken;
                paymentRequest.PaymentMerchant = transactionResult.PaymentMerchant;
                paymentRequest.OrderId = orderId;

                _orderService.SetOrderPayment(paymentRequest);
            }
            else
            {
                _logger.LogInformation(String.Format(
                 "Payment not ok for order id {0}, payment token {1}",
                    orderId, transactionResult.PaymentToken));
            }
        }

        public ActionResult CreatePaymentFor(int orderId)
        {
            GetOrderRequest request = new GetOrderRequest() { OrderId = orderId };

            GetOrderResponse response = _orderService.GetOrder(request);
            OrderPaymentRequest orderPaymentRequest =
                           response.Order.ConvertToOrderPaymentRequest(_mapper);

            PaymentPostData paymentPostData =
                        _paymentService.GeneratePostDataFor(orderPaymentRequest, HttpContext);

            return View("PaymentPost", paymentPostData);
        }

        public ActionResult PaymentComplete()
        {
            return View();
        }

        public ActionResult PaymentCancel()
        {
            return View();
        }
    }

}
