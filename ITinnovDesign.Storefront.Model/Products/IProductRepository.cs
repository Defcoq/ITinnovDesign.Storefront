using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Products
{
    public interface IProductRepository : IReadOnlyRepository<Product, int>
    {
    }
}
