using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Orders;
using ITinnovDesign.Storefront.Repository.EF;

namespace ITinnovDesign.Storefront.Repository.NHibernate.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base(context,uow)
        {
        }
    }

}
