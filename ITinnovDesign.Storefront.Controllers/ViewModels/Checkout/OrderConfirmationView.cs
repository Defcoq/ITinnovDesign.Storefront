using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Services.ViewModels;

namespace ITinnovDesign.Storefront.Controllers.ViewModels.Checkout
{
    public class OrderConfirmationView
    {
        public BasketView Basket { get; set; }
        public IEnumerable<DeliveryAddressView> DeliveryAddresses { get; set; }
    }

}
