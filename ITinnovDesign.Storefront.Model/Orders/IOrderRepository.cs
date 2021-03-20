using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Infrastructure.Domain;

namespace ITinnovDesign.Storefront.Model.Orders
{
    public interface IOrderRepository : IRepository<Order, int>
    {
    }
}
