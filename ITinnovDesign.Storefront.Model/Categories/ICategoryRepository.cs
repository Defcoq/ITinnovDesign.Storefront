using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Categories
{
    public interface ICategoryRepository : IReadOnlyRepository<Category, int>
    {
    }
}
