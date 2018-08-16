using EventBus.Events;
using Ordering.API.Application.Model;
using System;
using System.Collections.Generic;

namespace Ordering.API.Application.IntegrationEvents.Events
{
    public class ProviderOrderStatusChangedToConfirmedIntegrationEvent : IntegrationEvent
    {
        public string ProviderId { get; }
        public int OrderId { get; }
        public string OrderStatus { get; }
        public IList<ProviderOrderItem> Items { get; private set; }
        public Guid RequestId { get; private set; }
       
        public ProviderOrderStatusChangedToConfirmedIntegrationEvent(int customerOrderId, string providerId, string orderStatus, IList<ProviderOrderItem> items)
        {
            ProviderId = providerId;
            OrderId = customerOrderId;
            OrderStatus = orderStatus;
            Items = items;
        }
    }
}
