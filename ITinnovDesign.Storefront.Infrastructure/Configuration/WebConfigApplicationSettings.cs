using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName { get; set; }

        public string NumberOfResultsPerPage { get; set; }

        public string JanrainApiKey
        { get; set; }

        public string PayPalBusinessEmail
        { get; set; }

        public string PayPalPaymentPostToUrl
        { get; set; }
    }
}
