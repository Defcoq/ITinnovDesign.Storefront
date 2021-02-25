using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Model.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Products
{
    public class Product : EntityBase<int>, IAggregateRoot
    {
        public int ProductSizeId { get; set; }
        public ProductSize Size { get; set; }

        public int ProductTitleId { get; set; }
        public ProductTitle Title { get; set; }

        public string Name
        {
            get { return Title.Name; }
        }

        public Decimal Price
        {
            get { return Title.Price; }
        }

        public int BrandId { get; set; }
        public Brand Brand
        {
            get { return Title.Brand; }
        }


        public int ProductColorId { get; set; }
        public ProductColor Color
        {
            get { return Title.Color; }
        }

        public int CategoryId { get; set; }
        public Category Category
        {
            get { return Title.Category; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
