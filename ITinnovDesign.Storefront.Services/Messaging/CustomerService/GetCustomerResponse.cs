using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Messaging.CustomerService
{
    public class GetCustomerResponse
    {
        public bool CustomerFound { get; set; }
        public CustomerView Customer { get; set; }
        public IEnumerable<OrderSummaryView> Orders { get; set; }
    }
}
