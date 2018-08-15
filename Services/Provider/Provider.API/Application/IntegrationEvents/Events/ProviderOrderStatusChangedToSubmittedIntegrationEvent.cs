using EventBus.Events;
using Provider.API.Application.Model;
using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Collections.Generic;

namespace Provider.API.Application.IntegrationEvents.Events
{
    public class ProviderOrderStatusChangedToSubmittedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }
        public string OrderStatus { get; }
        public IList<OrderItemDto> Items { get; private set; }
        public Guid RequestId { get; private set; }
       
        public ProviderOrderStatusChangedToSubmittedIntegrationEvent(int orderId, string orderStatus, IList<OrderItemDto> items)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            Items = items;
        }
    }
}
