using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime orderDate;

        private readonly List<OrderItem> orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => orderItems;

        public Address Address { get; private set; }

        public OrderStatus OrderStatus { get; private set; }
        private int orderStatusId;

        public string GetBuyerId => buyerId;
        private string buyerId;

        protected Order()
        {
            orderItems = new List<OrderItem>();
            orderDate = DateTime.Now;
        }

        public Order(string buyerId, Address address) : this()
        {
            this.buyerId = buyerId;
            this.Address = address;
            this.orderStatusId = OrderStatus.Submitted.Id;
        }

        public void AddOrderItem(int providerId, int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {

            var existingOrderForProduct = orderItems.Where(o => o.ProductId == productId)
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
                orderItems.Add(orderItem);
            }
        }
        
        public void SetBuyerId(string id)
        {
            buyerId = id;
        }
    }
}
