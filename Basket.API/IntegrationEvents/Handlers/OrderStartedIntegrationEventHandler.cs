using System.Threading.Tasks;
using Basket.API.IntegrationEvents.Events;
using Basket.Infrastructure;
using EventBus.Abstractions;

namespace Basket.API.IntegrationEvents.Handlers
{
    public class OrderStartedIntegrationEventHandler : IIntegrationEventHandler<OrderStartedIntegrationEvent>
    {
        private IBasketRepository repository;

        public OrderStartedIntegrationEventHandler(IBasketRepository repository)
        {
            this.repository = repository;
        }
        public async Task Handle(OrderStartedIntegrationEvent @event)
        {
            await repository.DeleteBasketAsync(@event.UserId);
        }
    }
}