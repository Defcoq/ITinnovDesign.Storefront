using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Querying;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using ITinnovDesign.Storefront.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Implementations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IMapper _mapper;
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCatalogService(IProductTitleRepository productTitleRepository,
                                       IProductRepository productRepository,
                                       ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        private IEnumerable<Product> GetAllProductsMatchingQueryAndSort(GetProductsByCategoryRequest request, IQueryable<Product> productQuery)
        {
            IEnumerable<Product> productsMatchingRefinement = _productRepository.FindBy(productQuery);

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceLowToHigh:
                    productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
                    break;
                case ProductsSortBy.PriceHighToLow:
                    productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
            }
            return productsMatchingRefinement;
        }


        public GetFeaturedProductsResponse GetFeaturedProducts()
        {
            GetFeaturedProductsResponse response = new GetFeaturedProductsResponse();

            var productQuery = _productTitleRepository.FindAll().AsQueryable();

           // productQuery.OrderByProperty = new OrderByClause() { Desc = true, PropertyName = PropertyNameHelper.ResolvePropertyName<ProductTitle>(pt => pt.Price) };

            response.Products = _productTitleRepository.FindBy(productQuery, 0, 6).ConvertToProductViews(_mapper);

            return response;
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response;

            //  Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);
            var productQuery = _productRepository.FindAll().Where(x=>x.CategoryId == request.CategoryId || 
            request.BrandIds.Contains(x.BrandId) || request.ColorIds.Contains(x.Color.Id) || request.SizeIds.Contains(x.Size.Id)).AsQueryable();

            IEnumerable<Product> productsMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, productQuery);

            response = productsMatchingRefinement.CreateProductSearchResultFrom(request,_mapper);

            response.SelectedCategoryName =
                _categoryRepository.FindBy(request.CategoryId).Name;


            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();

            ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductId);

            response.Product = productTitle.ConvertToProductDetailView(_mapper);

            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            IEnumerable<Category> categories = _categoryRepository.FindAll();
            response.Categories = categories.ConvertToCategoryViews(_mapper);

            return response;
        }
    }
}
