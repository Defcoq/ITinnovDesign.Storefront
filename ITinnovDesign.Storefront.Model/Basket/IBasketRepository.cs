using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Basket
{
    public interface IBasketRepository : IRepository<Basket, Guid>
    {
    }
}
