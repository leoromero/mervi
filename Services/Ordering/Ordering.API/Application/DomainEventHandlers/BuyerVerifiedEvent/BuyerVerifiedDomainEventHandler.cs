using MediatR;
using Mervi.Services.Interfaces;
using Mervi.Services.Mappers;
using Microsoft.Extensions.Logging;
using Ordering.API.Application.IntegrationEvents;
using Ordering.API.Application.IntegrationEvents.Events;
using Ordering.Domain.AggregatesModels.BuyerAggregate;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Ordering.Domain.Events;
using Ordering.DTOs.OrderAggregateDtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.DomainEventHandlers.BuyerVerifiedEvent
{
    public class BuyerVerifiedDomainEventHandler
                        : INotificationHandler<BuyerVerifiedDomainEvent>
    {
        private readonly IMapper<Order, OrderDto> _orderMapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;

        public BuyerVerifiedDomainEventHandler(
            IOrderRepository orderRepository,
            IOrderingIntegrationEventService orderingIntegrationEventService,
            IMapper<Order, OrderDto> orderMapper) 
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
            _orderMapper = orderMapper ?? throw new ArgumentNullException(nameof(orderMapper));
        }

        public async Task Handle(BuyerVerifiedDomainEvent buyerVerifiedEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetAsync(buyerVerifiedEvent.OrderId);
            orderToUpdate.SetBuyerId(buyerVerifiedEvent.Buyer.Id);

            _orderRepository.Update(orderToUpdate);
         }
    }
}
