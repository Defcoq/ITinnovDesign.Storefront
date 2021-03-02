using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Basket;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public class BasketRepository : Repository<Basket, Guid>, IBasketRepository
    {
        public BasketRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base(context, uow)
        {
        }
    }
}
