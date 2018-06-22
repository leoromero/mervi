using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime _orderDate;

        private readonly List<ProviderOrder> _providerOrders;
        public IReadOnlyCollection<ProviderOrder> ProviderOrders => _providerOrders;

        public Address Address { get; private set; }

        public OrderStatus OrderStatus { get; private set; }
        private int _orderStatusId;

        public int? GetBuyerId => _buyerId;
        private int? _buyerId;

        protected Order()
        {
            _providerOrders = new List<ProviderOrder>();
            _orderDate = DateTime.Now;
        }

        public Order(int buyerId, Address address) : this()
        {
            _buyerId = buyerId;
            Address = address;
            _orderStatusId = OrderStatus.Submitted.Id;
        }

        private void AddProviderOrder(int providerId)
        {
            if ((_providerOrders.Where(x => x.GetProviderId == providerId) == null))
                _providerOrders.Add(new ProviderOrder(providerId));
        }

        public void AddOrderItem(int providerId, int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {
            AddProviderOrder(providerId);
            _providerOrders.First(x => x.GetProviderId == providerId).AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
        }
    }
}
