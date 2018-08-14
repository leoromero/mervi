using EventBus.Abstractions;
using MediatR;
using Ordering.API.Application.IntegrationEvents.Events;
using Provider.API.Application.Commands;
using Provider.API.Application.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.IntegrationEvents.Handlers
{
    public class OrderStatusChangedToSubmittedIntegrationEventHandler : IIntegrationEventHandler<OrderStatusChangedToSubmittedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly IProviderIntegrationEventService _orderingIntegrationEventService;

        public OrderStatusChangedToSubmittedIntegrationEventHandler(IMediator mediator,
            IProviderIntegrationEventService orderingIntegrationEventService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
        }


        public async Task Handle(OrderStatusChangedToSubmittedIntegrationEvent eventMsg)
        {
            if (eventMsg.RequestId != Guid.Empty)
            {
                var providerItems = eventMsg.Items.GroupBy(i => i.ProviderId);

                foreach (var order in providerItems)
                {
                    var providerId = order.Key;
                    var items = order.Select(x => x).ToList();

                    var createOrderCommand = new CreateOrderCommand(items, eventMsg.BuyerId, eventMsg.OrderId, eventMsg.BuyerName, providerId, eventMsg.CreationDate);

                    await _mediator.Send(createOrderCommand);
                }

            }
        }
    }
}
