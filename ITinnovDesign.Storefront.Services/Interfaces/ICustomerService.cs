using ITinnovDesign.Storefront.Services.Messaging.CustomerService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Interfaces
{
    public interface ICustomerService
    {
        CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
        ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request);
        DeliveryAddressModifyResponse ModifyDeliveryAddress(
        DeliveryAddressModifyRequest request);
        DeliveryAddressAddResponse AddDeliveryAddress(
        DeliveryAddressAddRequest request);
    }
}
