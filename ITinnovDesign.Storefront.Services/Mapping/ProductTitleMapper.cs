using AutoMapper;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class ProductTitleMapper
    {
        public static IEnumerable<ProductSummaryView> ConvertToProductViews(
                                                this IEnumerable<ProductTitle> products, IMapper _mapper)
        {
            return _mapper.Map<IEnumerable<ProductTitle>,
                              IEnumerable<ProductSummaryView>>(products);
        }

        public static ProductView ConvertToProductDetailView(this ProductTitle product, IMapper _mapper)
        {
            return _mapper.Map<ProductTitle, ProductView>(product);
        }
    }
}
