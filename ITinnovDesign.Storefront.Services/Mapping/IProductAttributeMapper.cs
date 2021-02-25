using AutoMapper;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(
                                this IEnumerable<IProductAttribute> productAttributes,
                                RefinementGroupings refinementGroupType, IMapper _mapper)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };

            refinementGroup.Refinements =
                      _mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>
                                                                     (productAttributes);

            return refinementGroup;
        }
    }
}
