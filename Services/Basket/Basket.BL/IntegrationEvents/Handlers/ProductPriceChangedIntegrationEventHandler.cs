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
            await service.UpdateProductPriceInAllBaskets(@event);
        }

       
    }
}