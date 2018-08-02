using System;
using System.Linq;
using System.Threading.Tasks;
using Basket.BL.IntegrationEvents.Events;
using Basket.BL.Interfaces;
using Basket.Domain;
using Basket.Infrastructure;
using EventBus.Abstractions;

namespace Basket.BL.IntegrationEvents.Handlers
{
    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        private readonly IBasketService service;

        public ProductPriceChangedIntegrationEventHandler(IBasketService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            var baskets = await service.GetProductsBasketsAsync(@event.ProductId.ToString());
            var basketsIds = baskets.BasketsIds;

            basketsIds.Distinct().ToList().ForEach(async basketId =>
            {
                CustomerBasket basket = await service.GetBasketAsync(basketId);

                //throw the update method and don't wait for the result.
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                UpdatePriceInBasketItems(@event.ProductId, @event.NewPrice, @event.OldPrice, basket);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
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
                await service.UpdateBasketAsync(basket);
            }
        }
    }
}