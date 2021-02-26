using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Model.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Products
{
    public class ProductTitle : EntityBase<int>, IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ProductColor Color { get; set; }
       // public IEnumerable<Product> Products { get; set; }
        public IList<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
