using AutoMapper;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateProductSearchResultFrom(this IEnumerable<Product> productsMatchingRefinement, GetProductsByCategoryRequest request, IMapper _mapper)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();

            IEnumerable<ProductTitle> productsFound = productsMatchingRefinement.Select(p => p.Title).Distinct();

            productSearchResultView.SelectedCategory = request.CategoryId;

            productSearchResultView.NumberOfTitlesFound = productsFound.Count();

            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                                                              productSearchResultView.NumberOfTitlesFound);

            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound, _mapper);

            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, productsFound, _mapper);

            return productSearchResultView;
        }

        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductTitle> productsFound, IMapper _mapper)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip).Take(numberOfResultsPerPage).ConvertToProductViews(_mapper);
            }
            else
                return productsFound.Take(numberOfResultsPerPage).ConvertToProductViews(_mapper);
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductTitle> productsFound, IMapper _mapper)
        {
            var brandsRefinementGroup = productsFound.Select(p => p.Brand).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(b => (IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.brand, _mapper);
            var colorsRefinementGroup = productsFound.Select(p => p.Color).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(c => (IProductAttribute)c).ConvertToRefinementGroup(RefinementGroupings.color, _mapper);
            var sizesRefinementGroup = (from p in productsFound
                                        from si in p.Products
                                        select si.Size).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(s => (IProductAttribute)s).ConvertToRefinementGroup(RefinementGroupings.size, _mapper);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);
            return refinementGroups;
        }
    }
}
