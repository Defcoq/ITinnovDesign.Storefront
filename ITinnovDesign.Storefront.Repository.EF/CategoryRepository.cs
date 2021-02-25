using ITinnovDesign.Storefront.Model.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base( context,uow)
        {
        }
    }
}
