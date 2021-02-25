using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base(context,uow)
        {
        }

       
    }
}
