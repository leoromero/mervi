using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class ProviderOrder : Entity
    {
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private int _providerId;
        public int GetProviderId => _providerId;

        private int _providerOrderStatusId;
        public ProviderOrderStatus ProviderOrderStatus { get; private set; }

        protected ProviderOrder()
        {
            _orderItems = new List<OrderItem>();
        }

        public ProviderOrder(int? providerId) : this()
        {
            _providerOrderStatusId = ProviderOrderStatus.Submitted.Id;
        }

        internal void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {
            var newOrder = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
            _orderItems.Add(newOrder);
        }
    }
}
