using EventBus.Events;
using Provider.API.Application.Model;
using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Collections.Generic;

namespace Provider.API.Application.IntegrationEvents.Events
{
    public class ProviderOrderStatusChangedToConfirmedIntegrationEvent : IntegrationEvent
    {
        public string ProviderId { get; }
        public int OrderId { get; }
        public string OrderStatus { get; }
        public IList<OrderItemDto> Items { get; private set; }
        public Guid RequestId { get; private set; }
       
        public ProviderOrderStatusChangedToConfirmedIntegrationEvent(int customerOrderId, string providerId, string orderStatus, IList<OrderItemDto> items)
        {
            ProviderId = providerId;
            OrderId = customerOrderId;
            OrderStatus = orderStatus;
            Items = items;
        }
    }
}
