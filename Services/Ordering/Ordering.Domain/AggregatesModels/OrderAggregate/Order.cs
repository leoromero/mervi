using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime _orderDate;

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Address Address { get; private set; }

        public OrderStatus OrderStatus { get; private set; }
        private int _orderStatusId;

        public string GetBuyerId => _buyerId;
        private string _buyerId;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
            _orderDate = DateTime.Now;
        }

        public Order(string buyerId, Address address) : this()
        {
            this._buyerId = buyerId;
            this.Address = address;
            this._orderStatusId = OrderStatus.Submitted.Id;
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

        public void SetBuyerId(string id)
        {
            _buyerId = id;
        }
    }
}
