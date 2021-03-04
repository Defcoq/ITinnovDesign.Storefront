using AutoMapper;
using ITinnovDesign.Storefront.Model.Customers;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerView ConvertToCustomerDetailView(this Customer customer, IMapper _mapper)
        {
            return _mapper.Map<Customer, CustomerView>(customer);
        }
    }
}
