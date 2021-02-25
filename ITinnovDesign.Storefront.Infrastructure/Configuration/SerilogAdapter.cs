using ITinnovDesign.Storefront.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Configuration
{


    public class SerilogAdapter : ILogger
    {
        private readonly Serilog.ILogger _serilog;

        public SerilogAdapter(Serilog.ILogger serilog)
        {
            _serilog = serilog;
        }

        public void Log(string message)
        {
            _serilog.Information(message);
        }
    }
    

}
