using EventBus.Abstractions;
using MediatR;
using Ordering.API.Application.IntegrationEvents.Events;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Threading.Tasks;

namespace Ordering.API.Application.IntegrationEvents.Handlers
{
    public class ProviderOrderStatusChangedToConfirmedIntegrationEventHandler : IIntegrationEventHandler<ProviderOrderStatusChangedToConfirmedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;
        private readonly IOrderRepository _orderRepository;

        public ProviderOrderStatusChangedToConfirmedIntegrationEventHandler(IMediator mediator,
            IOrderingIntegrationEventService orderingIntegrationEventService,
            IOrderRepository repository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
            _orderRepository = repository;
        }


        public async Task Handle(ProviderOrderStatusChangedToConfirmedIntegrationEvent eventMsg)
        {

            var command = new SetOrderItemsAsConfirmedCommand(eventMsg.Items, eventMsg.OrderId, eventMsg.ProviderId);

            await _mediator.Send(command);
        }
    }
}
