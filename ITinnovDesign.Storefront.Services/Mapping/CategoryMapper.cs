using AutoMapper;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViews(
                                                this IEnumerable<Category> categories, IMapper _mapper)
        {
            return _mapper.Map<IEnumerable<Category>,
                              IEnumerable<CategoryView>>(categories);
        }
    }
}
