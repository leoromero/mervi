using EventBus.Events;
using Ordering.DTOs.OrderAggregateDtos;
using System;
using System.Collections.Generic;

namespace Ordering.API.Application.IntegrationEvents.Events
{
    public class OrderStatusChangedToSubmittedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }
        public IList<OrderItemDto> Items { get; private set; }
        public Guid RequestId { get; private set; }
        public string BuyerId { get; private set; }

        public OrderStatusChangedToSubmittedIntegrationEvent(int orderId, string orderStatus, string buyerName, IList<OrderItemDto> items)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
            Items = items;
        }
    }
}
