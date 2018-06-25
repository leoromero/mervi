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

        public int GetProviderId() => providerId;
        private readonly int providerId;

        public string GetProductName() => productName;
        private readonly string productName;

        public decimal GetUnitPrice() => unitPrice;
        private decimal unitPrice;

        public decimal GetCurrentDiscount() => discount;
        private decimal discount;

        public string GetPictureUrl() => pictureUrl;
        private readonly string pictureUrl;

        public int GetUnits() => units;
        private int units;

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
