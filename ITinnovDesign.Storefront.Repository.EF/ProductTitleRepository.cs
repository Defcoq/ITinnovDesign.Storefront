using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public class ProductTitleRepository : Repository<ProductTitle, int>, IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base(context, uow)
        {
        }


    }
}
