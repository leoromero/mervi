using EventBus.Events;
using Provider.API.Application.Model;
using System;
using System.Collections.Generic;

namespace Provider.API.Application.IntegrationEvents.Events
{
    public class OrderStatusChangedToSubmittedIntegrationEvent : IntegrationEvent
    {
        public string OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }
        public IList<CustomerOrderItem> Items { get; private set; }
        public Guid RequestId { get; private set; }
        public string BuyerId { get; private set; }

        public OrderStatusChangedToSubmittedIntegrationEvent(string orderId, string orderStatus, string buyerName, IList<CustomerOrderItem> items)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
            Items = items;
        }
    }
}
