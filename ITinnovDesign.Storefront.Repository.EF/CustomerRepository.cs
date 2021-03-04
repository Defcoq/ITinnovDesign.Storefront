using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using ITinnovDesign.Storefront.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public class CustomerRepository : Repository<Customer, int>,
                                          ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow, ITInnovDesignSorefrontContext context)
            : base(context,uow)
        {
        }

        public Customer FindBy(string identityToken)
        {
          
            IList<Customer> customers = Context.Customers.Where(x => x.IdentityToken == identityToken).ToList();
           //IList <Customer> customers = criteriaQuery.List<Customer>();

            Customer customer = customers.FirstOrDefault();
            return customer;
        }
    }
}
