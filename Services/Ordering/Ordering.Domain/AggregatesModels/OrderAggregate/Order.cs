using Mervi.SeedWork;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime GetOrderDate => _orderDate;
        private readonly DateTime _orderDate;

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Address Address { get; private set; }

        public OrderStatus OrderStatus { get; private set; }
        private int _orderStatusId;

        public int? GetBuyerId() => _buyerId;
        private int? _buyerId;

        private Order()
        {
            _orderItems = new List<OrderItem>();
            _orderDate = DateTime.Now;
        }

        public Order(string userId, string userName, Address address, int? buyerId = null) : this()
        {
            this._buyerId = buyerId;
            this.Address = address;
            this._orderStatusId = OrderStatus.Submitted.Id;

            // Add the OrderStarterDomainEvent to the domain events collection 
            // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
            AddOrderStartedDomainEvent(userId, userName);
        }

        public void AddOrderItem(string providerId, int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {

            var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId)
                 .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                //if previous line exist modify it with higher discount  and units..

                if (discount > existingOrderForProduct.GetCurrentDiscount())
                {
                    existingOrderForProduct.SetNewDiscount(discount);
                }

                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                //add validated new order item

                var orderItem = new OrderItem(productId, providerId, productName, unitPrice, discount, pictureUrl, units);
                _orderItems.Add(orderItem);
            }
        }

        public void SetItemAsSubmitted(int productId, string providerId)
        {
            this._orderItems.FirstOrDefault(x => x.ProductId == productId && x.GetProviderId() == providerId)?.SetSubmittedState();
        }

        public void SetItemAsConfirmed(int productId, string providerId)
        {
            this._orderItems.FirstOrDefault(x => x.ProductId == productId && x.GetProviderId() == providerId)?.SetConfirmedState();
        }

        public void SetBuyerId(int id)
        {
            _buyerId = id;
        }

        private void AddOrderStartedDomainEvent(string userId, string userName)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userId, userName);

            this.AddDomainEvent(orderStartedDomainEvent);
        }

    }
}
