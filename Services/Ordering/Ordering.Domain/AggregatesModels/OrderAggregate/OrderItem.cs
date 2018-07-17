using Mervi.SeedWork;
using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }

        private int providerId;
        private string productName;
        private decimal unitPrice;
        private decimal discount;
        private string pictureUrl;
        private int units;
        public OrderItemStatus OrderItemStatus { get; private set; }
        private int orderItemStatusId;

        public int GetProviderId() => providerId;

        public string GetProductName() => productName;

        public decimal GetUnitPrice() => unitPrice;

        public decimal GetCurrentDiscount() => discount;

        public string GetPictureUrl() => pictureUrl;

        public int GetUnits() => units;

        protected OrderItem()
        {
        }

        public OrderItem(int productId, int providerId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {
            ProductId = productId;
            this.providerId = providerId;
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.discount = discount;
            this.pictureUrl = pictureUrl;
            this.units = units;
            orderItemStatusId = OrderItemStatus.Submitted.Id;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
                throw new OrderingDomainException("invalid units");

            this.units += units;
        }

        public void SetNewDiscount(decimal discount)
        {
            if (discount < 0)
            {
                throw new OrderingDomainException("Discount is not valid");
            }

            this.discount = discount;
        }
    }
}
