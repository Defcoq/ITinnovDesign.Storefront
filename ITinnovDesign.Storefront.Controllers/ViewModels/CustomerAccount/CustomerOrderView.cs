using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Services.ViewModels;

namespace ITinnovDesign.Storefront.Controllers.ViewModels.CustomerAccount
{
    public class CustomerOrderView : BaseCustomerAccountView
    {
        public OrderView Order { get; set; }
    }

}
