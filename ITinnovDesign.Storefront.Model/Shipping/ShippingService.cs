using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Shipping
{
    public class ShippingService : EntityBase<int>
    {
        private readonly string _code;
        private readonly string _description;
        private readonly Courier _courier;

        public ShippingService()
        { }

        public ShippingService(string code, string description, Courier courier)
        {
            _code = code;
            _description = description;
            _courier = courier;
        }

        public int CourierId { get; set; }
        public string Code
        {
            get { return _code; }
            set { value = _code; }
        }

        public string Description
        {
            get { return _description; }
            set { value = _description; }
        }

        public Courier Courier
        {
            get { return _courier; }
            set { value= _courier; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
