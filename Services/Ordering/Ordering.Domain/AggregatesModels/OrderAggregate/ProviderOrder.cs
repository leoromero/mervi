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

        private int? _providerId;
        public int? GetProviderId => _providerId;

        private ProviderOrderStatus _providerOrderStatus;
        public ProviderOrderStatus GetProviderOrderStatus => _providerOrderStatus;

    }
}
