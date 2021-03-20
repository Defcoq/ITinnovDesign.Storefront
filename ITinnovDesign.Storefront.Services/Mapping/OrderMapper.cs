using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Model.Orders;
using ITinnovDesign.Storefront.Services.ViewModels;
using AutoMapper;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class OrderMapper
    {
        public static OrderView ConvertToOrderView(this Order order, IMapper _mapper)
        {
            return _mapper.Map<Order, OrderView>(order);
        }

        public static IEnumerable<OrderSummaryView> ConvertToOrderSummaryViews(
                                                      this IEnumerable<Order> orders, IMapper _mapper)
        {
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderSummaryView>>(orders);
        }
    }

}
