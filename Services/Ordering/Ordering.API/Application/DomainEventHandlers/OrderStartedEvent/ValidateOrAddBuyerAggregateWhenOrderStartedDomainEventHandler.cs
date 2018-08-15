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

namespace Ordering.API.Application.DomainEventHandlers.OrderStartedEvent
{
    public class ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler
                        : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IMapper<Order, OrderDto> _orderMapper;
        private readonly IBuyerRepository _buyerRepository;
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;

        public ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler(
            IBuyerRepository buyerRepository,
            IOrderingIntegrationEventService orderingIntegrationEventService,
            IMapper<Order, OrderDto> orderMapper) 
        {
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
            _orderMapper = orderMapper ?? throw new ArgumentNullException(nameof(orderMapper));
        }

        public async Task Handle(OrderStartedDomainEvent orderStartedEvent, CancellationToken cancellationToken)
        {
            var buyer = await _buyerRepository.FindAsync(orderStartedEvent.UserId);
            bool buyerOriginallyExisted = (buyer == null) ? false : true;

            if (!buyerOriginallyExisted)
            {
                buyer = new Buyer(orderStartedEvent.UserId, orderStartedEvent.UserName);
            }
            
            var buyerUpdated = buyerOriginallyExisted ?
                _buyerRepository.Update(buyer) :
                _buyerRepository.Add(buyer);

            await _buyerRepository.UnitOfWork
                .SaveEntitiesAsync();

            var order = _orderMapper.ToDto(orderStartedEvent.Order);
            var orderStatusChangedTosubmittedIntegrationEvent = new OrderStatusChangedToSubmittedIntegrationEvent(order.Id, order.OrderStatusName, buyer.Name, order.OrderItems);
            await _orderingIntegrationEventService.PublishThroughEventBusAsync(orderStatusChangedTosubmittedIntegrationEvent);

        }
    }
}
