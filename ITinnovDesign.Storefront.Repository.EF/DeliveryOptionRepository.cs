using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public class DeliveryOptionRepository : Repository<DeliveryOption, int>,
                                                           IDeliveryOptionRepository
    {
        public DeliveryOptionRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base(context,uow)
        {
        }
    }
}
