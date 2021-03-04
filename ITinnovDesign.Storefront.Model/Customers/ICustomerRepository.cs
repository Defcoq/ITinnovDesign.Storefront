using ITinnovDesign.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ITinnovDesign.Storefront.Model.Customers
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Customer FindBy(string identityToken);
    }

}
