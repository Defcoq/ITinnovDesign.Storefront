using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Implementations
{
    public class CustomerInvalidException : Exception
    {
        public CustomerInvalidException(string message) : base(message)
        {
        }
    }
}
