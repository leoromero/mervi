using System.Threading.Tasks;
using Basket.BL.IntegrationEvents.Events;
using Basket.Infrastructure;
using EventBus.Abstractions;

namespace Basket.BL.IntegrationEvents.Handlers
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