using AutoMapper;
using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model.Basket;
using ITinnovDesign.Storefront.Model.Products;
using ITinnovDesign.Storefront.Model.Shipping;
using ITinnovDesign.Storefront.Services.Interfaces;
using ITinnovDesign.Storefront.Services.Mapping;
using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using ITinnovDesign.Storefront.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITinnovDesign.Storefront.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;
        private readonly IUnitOfWork _uow;

        public BasketService(IBasketRepository basketRepository,
                             IProductRepository productRepository,
                             IDeliveryOptionRepository deliveryOptionRepository,
                             IUnitOfWork uow,
                              IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
            _uow = uow;
        }

        public GetBasketResponse GetBasket(GetBasketRequest request)
        {
            GetBasketResponse response = new GetBasketResponse();

            Basket basket = _basketRepository.GetAll().Where(x=>x.Id==request.BasketId).FirstOrDefault();
            BasketView basketView;

            if (basket != null)
                basketView = basket.ConvertToBasketView(_mapper);
            else
                basketView = new BasketView();

            response.Basket = basketView;

            return response;
        }

        public CreateBasketResponse CreateBasket(CreateBasketRequest request)
        {
            CreateBasketResponse response = new CreateBasketResponse();

            Basket basket = new Basket();

            basket.SetDeliveryOption(GetCheapestDeliveryOption());

            AddProductsToBasket(request.ProductsToAdd, basket);

            ThrowExceptionIfBasketIsInvalid(basket);

            _basketRepository.Save(basket);
           // _uow.Commit();

            response.Basket = basket.ConvertToBasketView(_mapper);

            return response;
        }

        private DeliveryOption GetCheapestDeliveryOption()
        {
            return _deliveryOptionRepository.GetAll().Include(x=>x.ShippingService)
                            .OrderBy(d => d.Cost).FirstOrDefault();
        }

        private void ThrowExceptionIfBasketIsInvalid(Basket basket)
        {
            if (basket.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("There were problems saving the Basket:");
                foreach (BusinessRule businessRule in basket.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }

                throw new ApplicationException(brokenRules.ToString());

            }
        }

        public ModifyBasketResponse ModifyBasket(ModifyBasketRequest request)
        {
            ModifyBasketResponse response = new ModifyBasketResponse();
            Basket basket = _basketRepository.FindBy(request.BasketId);

            if (basket == null)
                throw new BasketDoesNotExistException();

            AddProductsToBasket(request.ProductsToAdd, basket);

            UpdateLineQtys(request.ItemsToUpdate, basket);

            RemoveItemsFromBasket(request.ItemsToRemove, basket);

            if (request.SetShippingServiceIdTo != 0)
            {
                DeliveryOption deliveryOption =
                     _deliveryOptionRepository.FindBy(request.SetShippingServiceIdTo);
                basket.SetDeliveryOption(deliveryOption);
            }

            ThrowExceptionIfBasketIsInvalid(basket);

            _basketRepository.Save(basket);
           // _uow.Commit();

            response.Basket = basket.ConvertToBasketView(_mapper);

            return response;
        }

        private void RemoveItemsFromBasket(IList<int> productsToRemove, Basket basket)
        {
            foreach (int productId in productsToRemove)
            {
                Product product = _productRepository.FindBy(productId);
                if (product != null)
                    basket.Remove(product);
            }
        }

        private void UpdateLineQtys(
               IList<ProductQtyUpdateRequest> productQtyUpdateRequests, Basket basket)
        {
            foreach (ProductQtyUpdateRequest productQtyUpdateRequest in
                                                             productQtyUpdateRequests)
            {
                Product product = _productRepository
                                         .FindBy(productQtyUpdateRequest.ProductId);

                if (product != null)
                    basket.ChangeQtyOfProduct(productQtyUpdateRequest.NewQty, product);
            }
        }

        private void AddProductsToBasket(IList<int> productsToAdd, Basket basket)
        {
            Product product;

            if (productsToAdd.Count() > 0)
                foreach (int productId in productsToAdd)
                {
                    product = _productRepository.FindBy(productId);
                    basket.Add(product);
                }
        }

        public GetAllDispatchOptionsResponse GetAllDispatchOptions()
        {
            GetAllDispatchOptionsResponse response = new GetAllDispatchOptionsResponse();
            response.DeliveryOptions = _deliveryOptionRepository.GetAll()
                                    .OrderBy(d => d.Cost).ConvertToDeliveryOptionViews(_mapper);

            return response;
        }
    }
}
