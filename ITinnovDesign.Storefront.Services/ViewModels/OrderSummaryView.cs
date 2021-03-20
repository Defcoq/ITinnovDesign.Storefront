using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITinnovDesign.Storefront.Services.ViewModels
{
    public class OrderSummaryView
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsSubmitted { get; set; }
    }

}
