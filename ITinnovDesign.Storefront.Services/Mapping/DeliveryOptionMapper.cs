using AutoMapper;
using ITinnovDesign.Storefront.Model.Shipping;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class DeliveryOptionMapper
    {
        public static IEnumerable<DeliveryOptionView> ConvertToDeliveryOptionViews
                                     (this IEnumerable<DeliveryOption> deliveryOptions, IMapper _mapper)
        {
            return _mapper.Map<IEnumerable<DeliveryOption>,
                              IEnumerable<DeliveryOptionView>>(deliveryOptions);
        }
    }
}
