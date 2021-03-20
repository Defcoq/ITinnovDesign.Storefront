using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Logging;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Customers;
using ITinnovDesign.Storefront.Model.Orders;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Mapping;
using ITinnovDesign.Storefront.Services.Messaging.OrderService;

namespace ITinnovDesign.Storefront.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,
                            IBasketRepository basketRepository,
                            ICustomerRepository customerRepository,
                            IUnitOfWork uow, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            Customer customer = _customerRepository
                              .FindBy(request.CustomerIdentityToken);
            Basket basket = _basketRepository.FindBy(request.BasketId);

            DeliveryAddress deliveryAddress = customer.DeliveryAddressBook
                         .Where(d => d.Id == request.DeliveryId).FirstOrDefault();

            Order order = basket.ConvertToOrder();

            order.Customer = customer;
            order.DeliveryAddress = deliveryAddress;

            _orderRepository.Save(order);
            _basketRepository.Remove(basket);
          //  _uow.Commit();

            response.Order = order.ConvertToOrderView(_mapper);

            return response;
        }

        public SetOrderPaymentResponse SetOrderPayment(
                                        SetOrderPaymentRequest paymentRequest)
        {
            SetOrderPaymentResponse paymentResponse = new SetOrderPaymentResponse();

            Order order = _orderRepository.FindBy(paymentRequest.OrderId);

            try
            {
                order.SetPayment(
                    PaymentFactory.CreatePayment(paymentRequest.PaymentToken,
                                                 paymentRequest.Amount,
                                                 paymentRequest.PaymentMerchant));

                _orderRepository.Save(order);
               // _uow.Commit();
            }
            catch (OrderAlreadyPaidForException ex)
            {
                // Out of scope of case study: 
                // Refund the payment using the payment service.

              //  LoggingFactory.GetLogger().Log(ex.Message);
            }
            catch (PaymentAmountDoesNotEqualOrderTotalException ex)
            {
                // Out of scope of case study:
                // Refund the payment using the payment service.

              //  LoggingFactory.GetLogger().Log(ex.Message);
            }

            paymentResponse.Order = order.ConvertToOrderView(_mapper);

            return paymentResponse;
        }

        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            GetOrderResponse response = new GetOrderResponse();

            Order order = _orderRepository.FindBy(request.OrderId);

            response.Order = order.ConvertToOrderView(_mapper);

            return response;
        }
    }

}
