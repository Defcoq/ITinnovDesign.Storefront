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
       
    }
}
