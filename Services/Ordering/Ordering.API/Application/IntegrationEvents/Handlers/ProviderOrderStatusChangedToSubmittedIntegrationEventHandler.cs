using EventBus.Abstractions;
using MediatR;
using Ordering.API.Application.Commands;
using Ordering.API.Application.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ordering.Domain.AggregatesModels.OrderAggregate;

namespace Ordering.API.Application.IntegrationEvents.Handlers
{
    public class ProviderOrderStatusChangedToSubmittedIntegrationEventHandler : IIntegrationEventHandler<ProviderOrderStatusChangedToSubmittedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;
        private readonly IOrderRepository _orderRepository;

        public ProviderOrderStatusChangedToSubmittedIntegrationEventHandler(IMediator mediator,
            IOrderingIntegrationEventService orderingIntegrationEventService,
            IOrderRepository repository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
            _orderRepository = repository;
        }


        public async Task Handle(ProviderOrderStatusChangedToSubmittedIntegrationEvent eventMsg)
        {
            var command = new SetOrderItemsAsSubmittedCommand(eventMsg.Items, eventMsg.OrderId, eventMsg.ProviderId);

            await _mediator.Send(command);
        }
    }
}
