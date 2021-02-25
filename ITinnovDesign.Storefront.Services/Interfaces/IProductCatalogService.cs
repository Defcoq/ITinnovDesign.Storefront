using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Interfaces
{
    public interface IProductCatalogService
    {
        GetFeaturedProductsResponse GetFeaturedProducts();
        GetProductsByCategoryResponse GetProductsByCategory(
                                         GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);

        GetAllCategoriesResponse GetAllCategories();
    }
}
