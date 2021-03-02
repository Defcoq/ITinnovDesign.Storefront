using AutoMapper;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Mapping
{
    public static class BasketMapper
    {
        public static BasketView ConvertToBasketView(this Basket basket, IMapper _mapper)
        {
            return _mapper.Map<Basket, BasketView>(basket);
        }
    }
}
