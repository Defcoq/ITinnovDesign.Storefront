using AutoMapper;
using ITinnovDesign.Storefront.Model.Customers;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class DeliveryAddressMapper
    {
        public static DeliveryAddressView ConvertToDeliveryAddressView(
        this DeliveryAddress deliveryAddress, IMapper _mapper)
        {
            return _mapper.Map<DeliveryAddress,
            DeliveryAddressView>(deliveryAddress);
        }
    }
}
