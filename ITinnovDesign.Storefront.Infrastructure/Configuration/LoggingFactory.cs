using ITinnovDesign.Storefront.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Configuration
{
    public class LoggingFactory
    {
        private static ILogger _logger;

        public static void InitializeLogFactory(ILogger logger)
        {
            _logger = logger;
        }

        public static ILogger GetLogger()
        {
            return _logger;
        }
    }
}
