using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Model.Customers
{
    public class DeliveryAddressBusinessRules
    {
        public static readonly BusinessRule NameRequired = new
              BusinessRule("Name", "A delivery address must have a name.");
        public static readonly BusinessRule CustomerRequired = new
              BusinessRule("Customer",
                           "A delivery address must be associated with a customer.");
    }
}
