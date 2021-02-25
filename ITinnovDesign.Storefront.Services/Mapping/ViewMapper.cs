using AutoMapper;
using ITinnovDesign.Storefront.Model.Categories;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public class ViewMapper : Profile
    {
        public ViewMapper()
        {
            // Product Title and Product
            CreateMap<ProductTitle, ProductSummaryView>();
            CreateMap<ProductTitle, ProductView>();
            CreateMap<Product, ProductSummaryView>();
            CreateMap<Product, ProductSizeOption>();
            // Category
            CreateMap<Category, CategoryView>();
            // IProductAttribute
            CreateMap<IProductAttribute, Refinement>();

            // Global Money Formatter
         //   Mapper.AddFormatter<MoneyFormatter>();
        }
    }

   /* public class MoneyFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                decimal money = (decimal)context.SourceValue;
                return money.FormatMoney();
            }
            return context.SourceValue.ToString();
        }
    }*/
}
//}
