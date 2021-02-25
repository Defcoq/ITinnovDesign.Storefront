using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Products
{
    public interface IProductTitleRepository : IReadOnlyRepository<ProductTitle, int>
    {
    }
}
