using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Shipping
{
    public interface IDeliveryOptionRepository :
                   IReadOnlyRepository<DeliveryOption, int>
    {
    }
}
