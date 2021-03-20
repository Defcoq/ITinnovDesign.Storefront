using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Model.Products;

namespace ITinnovDesign.Storefront.Model.Orders
{
    public class OrderItem : EntityBase<int>
    {
        private  Product _product;
        private  Order _order;
        private  int _qty;
        private  decimal _price;

        public OrderItem()
        {
        }

        public OrderItem(Product product, Order order, int qty)
        {
            _product = product;
            _order = order;
            _price = product.Price.Value;
            _qty = qty;
        }

        public int ProductId { get; set; }
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Qty
        {
            get { return _qty; }
        }

        public decimal Price
        {
            get { return _price; }
        }

        public int OrderId { get; set; }
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public decimal LineTotal()
        {
            return Qty * Price;
        }

        protected override void Validate()
        {
            if (Order == null)
                base.AddBrokenRule(OrderItemBusinessRules.OrderRequired);

            if (Product == null)
                base.AddBrokenRule(OrderItemBusinessRules.ProductRequired);

            if (Price < 0)
                base.AddBrokenRule(OrderItemBusinessRules.PriceNonNegative);

            if (Qty < 0)
                base.AddBrokenRule(OrderItemBusinessRules.QtyNonNegative);
        }

        public bool Contains(Product product)
        {
            return Product == product;
        }
    }

}
