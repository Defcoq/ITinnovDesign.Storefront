using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.ViewModels.CustomerAccount
{
    public class CustomerDeliveryAddressView : BaseCustomerAccountView
    {
        public CustomerView CustomerView { get; set; }
        public DeliveryAddressView Address { get; set; }
    }
}
