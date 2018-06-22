using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime _orderDate;

        private readonly List<ProviderOrder> _providerOrders;
        public IReadOnlyCollection<ProviderOrder> ProviderOrders => _providerOrders;

        public Address Address { get; private set; }

        public int? GetBuyerId => _buyerId;
        private int? _buyerId;
    }
}
