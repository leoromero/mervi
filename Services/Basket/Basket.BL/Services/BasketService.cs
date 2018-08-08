using Basket.BL.IntegrationEvents.Events;
using Basket.BL.Interfaces;
using Basket.Domain;
using Basket.DTOs;
using Basket.DTOs.Requests;
using Basket.DTOs.Responses;
using Basket.Infrastructure;
using EventBus.Abstractions;
using System;
using System.Linq;
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
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            var basket = await GetBasketAsEntityAsync(basketId);
            return basket != null ? mapper.ToDto(basket) : null;
        }
        
        private async Task<CustomerBasket> GetBasketAsEntityAsync(string basketId)
        {
            return await repository.GetBasketAsync(basketId);
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

        public async Task UpdateProductPriceInAllBaskets(ProductPriceChangedIntegrationEvent @event)
        {
            var baskets = await GetProductsBasketsAsync(@event.ProductId.ToString());
            var basketsIds = baskets.BasketsIds;

            basketsIds.Distinct().ToList().ForEach(async basketId =>
            {
                var basket = await GetBasketAsEntityAsync(basketId);

                await UpdatePriceInBasketItems(@event.ProductId, @event.NewPrice, @event.OldPrice, basket);
            });
        }
        private async Task UpdatePriceInBasketItems(int productId, decimal newPrice, decimal oldPrice, CustomerBasket basket)
        {
            string match = productId.ToString();
            var itemsToUpdate = basket?.Items?.Where(x => x.ProductId == match).ToList();

            if (itemsToUpdate != null)
            {
                foreach (var item in itemsToUpdate)
                {
                    if (item.UnitPrice == oldPrice)
                    {
                        var originalPrice = item.UnitPrice;
                        item.UnitPrice = newPrice;
                        item.OldUnitPrice = originalPrice;
                    }
                }
                await UpdateBasketAsync(mapper.ToDto(basket));
            }
        }
    }
}
