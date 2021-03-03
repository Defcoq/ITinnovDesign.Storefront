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
using ITinnovDesign.Storefront.Repository.EF;
using Microsoft.EntityFrameworkCore;

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
       
            // IEnumerable<Product> productsMatchingRefinement = productsMatchingRefinementList.AsEnumerable();

            productQuery =  productQuery.Include(x => x.Category)
                                                         .Include(x => x.Title)
                                                         .ThenInclude(x => x.Brand)
                                                         .Include(x => x.Size)
                                                         .Include(x => x.Color);
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

            var productQuery = _productTitleRepository.GetAll().Include(x=>x.Category)
                                                               .Include(x => x.Brand)
                                                               .Include(x => x.Color); 

           // productQuery.OrderByProperty = new OrderByClause() { Desc = true, PropertyName = PropertyNameHelper.ResolvePropertyName<ProductTitle>(pt => pt.Price) };

            response.Products = _productTitleRepository.FindBy(productQuery, 0, 30).ConvertToProductViews(_mapper);

            return response;
        }

        private bool checkColor(Product product, GetProductsByCategoryRequest request)
        {
            if(product != null && product.Color != null)
            {
                return request.ColorIds.Contains(product.Color.Id);
            }
            else
            {
                return false;
            }
        }

        private bool checkSize(Product product, GetProductsByCategoryRequest request)
        {
            if (product != null && product.Color != null)
            {
                return request.SizeIds.Contains(product.Size.Id);
            }
            else
            {
                return false;
            }
        }
        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response;

            //  Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);
            IQueryable<Product> productQuery = _productRepository.GetAll().Where(x => x.Title.Category.Id == request.CategoryId)
                                                         .Include(x => x.Title)
                                                         .ThenInclude(x => x.Category)
                                                         .Include(x => x.Title)
                                                         .ThenInclude(x => x.Brand)
                                                          .Include(x => x.Title)
                                                         .ThenInclude(x => x.Color)
                                                         .Include(x => x.Size);
  
          
                                                         
            if (request.BrandIds.Length >0)
            {
                productQuery = _productRepository.GetAll().Where(x => x.Title.Category.Id == request.CategoryId || request.BrandIds.Contains(x.BrandId))
                                                          .Include(x => x.Title)
                                                         .ThenInclude(x => x.Category)
                                                         .Include(x => x.Title)
                                                         .ThenInclude(x => x.Brand)
                                                          .Include(x => x.Title)
                                                         .ThenInclude(x => x.Color)
                                                         .Include(x => x.Size);


            }

            if (request.ColorIds.Length >0)
            {
                productQuery = _productRepository.GetAll().Where(x => x.Title.Category.Id == request.CategoryId || request.BrandIds.Contains(x.BrandId) || (x.Color != null && request.ColorIds.Contains(x.Color.Id)))
                                                          .Include(x => x.Title)
                                                         .ThenInclude(x => x.Category)
                                                         .Include(x => x.Title)
                                                         .ThenInclude(x => x.Brand)
                                                          .Include(x => x.Title)
                                                         .ThenInclude(x => x.Color)
                                                         .Include(x => x.Size);
                
            }

            if (request.SizeIds.Length > 0)
            {
                productQuery = _productRepository.GetAll().Where(x => x.Title.Category.Id == request.CategoryId || request.BrandIds.Contains(x.BrandId) || (x.Color != null && request.ColorIds.Contains(x.Color.Id)) || (x.Size != null && request.SizeIds.Contains(x.Size.Id)))
                                                        .Include(x => x.Title)
                                                         .ThenInclude(x => x.Category)
                                                         .Include(x => x.Title)
                                                         .ThenInclude(x => x.Brand)
                                                          .Include(x => x.Title)
                                                         .ThenInclude(x => x.Color)
                                                         .Include(x => x.Size);
                

            }


            //var productQuery = _productRepository.GetAll().Where(x=>x.CategoryId == request.CategoryId
            //||
            //request.BrandIds.Contains(x.BrandId) || checkColor(x, request) || checkSize(x, request))
            //                                             .Include(x => x.Category)
            //                                             .Include(x => x.Title)
            //                                             .ThenInclude(x => x.Brand)
            //                                             .Include(x => x.Size)
            //                                             .Include(x => x.Color)
            //                                             ;
            //var productQuery = _productRepository.FindAll().Where(x=>x.CategoryId == request.CategoryId || 
            //request.BrandIds.Contains(x.BrandId) ||  checkColor(x, request) || checkSize(x, request)).AsQueryable().Include(x => x.Category)
            //                                             .Include(x => x.Title)
            //                                             .ThenInclude(x => x.Brand)
            //                                             .Include(x => x.Size)
            //                                             .Include(x => x.Color);

            IEnumerable<Product> productsMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, productQuery);

            response = productsMatchingRefinement.CreateProductSearchResultFrom(request,_mapper);

            response.SelectedCategoryName =
                _categoryRepository.FindBy(request.CategoryId).Name;


            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();

            ProductTitle productTitle = _productTitleRepository.GetAll().Include(x => x.Category)
                                                                        .Include(x => x.Brand)
                                                                        .Include(x => x.Color)
                                                                        .Include(x=>x.Products)
                                                                        .ThenInclude(x=>x.Size)
                                                                        .Where(x => x.Id == request.ProductId).FirstOrDefault();
             

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
