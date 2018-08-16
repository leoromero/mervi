using MediatR;
using Mervi.Services.Interfaces;
using Provider.API.Application.IntegrationEvents;
using Provider.API.Application.IntegrationEvents.Events;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.Domain.Events;
using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Provider.API.Application.DomainEventHandlers.OrderStartedEvent
{
    public class OrderConfirmedEventHandler
                        : INotificationHandler<OrderConfirmedDomainEvent>
    {
        private readonly IMapper<Order, OrderDto> _orderMapper;
        private readonly IProviderIntegrationEventService _orderingIntegrationEventService;

        public OrderConfirmedEventHandler(
            IProviderIntegrationEventService orderingIntegrationEventService,
            IMapper<Order, OrderDto> orderMapper) 
        {
            _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
            _orderMapper = orderMapper ?? throw new ArgumentNullException(nameof(orderMapper));
        }

        public async Task Handle(OrderConfirmedDomainEvent orderConfirmedEvent, CancellationToken cancellationToken)
        {
            var order = _orderMapper.ToDto(orderConfirmedEvent.Order);
            var providerOrderStatusChangedToConfirmedIntegrationEvent = new ProviderOrderStatusChangedToConfirmedIntegrationEvent(order.CustomerOrderId, order.SellerId, order.OrderStatusName, order.OrderItems);
            await _orderingIntegrationEventService.PublishThroughEventBusAsync(providerOrderStatusChangedToConfirmedIntegrationEvent);
        }
    }
}
