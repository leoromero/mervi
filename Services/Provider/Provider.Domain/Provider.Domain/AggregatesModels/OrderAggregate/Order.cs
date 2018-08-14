using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider.Domain.AggregatesModels.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string UserId { get; private set; }
        private DateTime _orderDate;

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public OrderStatus OrderStatus { get; private set; }
        private int _orderStatusId;

        public string CustomerOrderId { get; private set; }

        public string GetSellerId => _sellerId;
        private string _sellerId;

        public Order(string userId, string sellerId, string customerOrderId, DateTime orderDate)
        {
            UserId = userId;
            CustomerOrderId = customerOrderId;
            this._orderDate = orderDate;
            this._sellerId = sellerId;
        }

        public void AddOrderItem(int productId, string productName, decimal unitPrice, string pictureUrl, int units)
        {
            var existingOrderForProduct = _orderItems.Where(i => i.ProductId == productId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                var orderItem = new OrderItem(productId, productName, unitPrice, pictureUrl, units);
                _orderItems.Add(orderItem);
            }
        }
    }
}
