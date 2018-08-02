using Basket.BL.IntegrationEvents.Events;
using Basket.BL.Interfaces;
using Basket.Domain;
using Basket.DTOs;
using Basket.DTOs.Requests;
using Basket.DTOs.Responses;
using Basket.Infrastructure;
using EventBus.Abstractions;
using System;
using System.Threading.Tasks;

namespace Basket.BL
{
    public class BasketService : IBasketService
    {
        private IBasketRepository repository;
        private IEventBus eventBus;
        private readonly IMapper<CustomerBasket, CustomerBasketDTO> mapper;

        public BasketService(IBasketRepository repository, IEventBus eventBus, IMapper<CustomerBasket, CustomerBasketDTO> mapper)
        {
            this.repository = repository;
            this.eventBus = eventBus;
            this.mapper = mapper;
        }

        public async Task<Response<bool>> Checkout(BasketCheckoutRequest basketCheckout)
        {
            //TODO: Get userId from token
            var basket = await repository.GetBasketAsync(basketCheckout.BuyerId);

            if (basket == null && basket.Items.Count == 0)
                return ResponseFactory.GetBoolResponse(false, "The basket does not exist");

            var msg = new UserCheckoutAcceptedIntegrationEvent(basketCheckout.BuyerId, basketCheckout.City, basketCheckout.Street,
                basketCheckout.State, basketCheckout.Country, basketCheckout.ZipCode, basketCheckout.CardNumber, basketCheckout.CardHolderName,
                basketCheckout.CardExpiration, basketCheckout.CardSecurityNumber, basketCheckout.CardTypeId, basket);

            eventBus.Publish(msg);

            return ResponseFactory.GetBoolResponse(true);
        }

        public async Task<CustomerBasketDTO> GetBasketAsync(string basketId)
        {
            var basket = await repository.GetBasketAsync(basketId);
            return mapper.ToDto(basket);
        }

        public CustomerBasketDTO GetBasket(string basketId)
        {
            return Task.Run(() => GetBasketAsync(basketId)).Result;
        }

        public async Task<ProductBasketsDTO> GetProductsBasketsAsync(string id)
        {
            return await repository.GetProductsBasketsAsync(id);
        }

        public async Task<Response<CustomerBasketDTO>> UpdateBasketAsync(CustomerBasketDTO basket)
        {
            try
            {
                var newBasket = mapper.ToEntity(basket);
                newBasket = await repository.UpdateBasketAsync(newBasket);
                return ResponseFactory.GetBasketResponse(mapper.ToDto(newBasket));
            }
            catch (Exception e)
            {
                return ResponseFactory.GetBasketResponse(null, e.Message);
            }            
        }
    }
}
