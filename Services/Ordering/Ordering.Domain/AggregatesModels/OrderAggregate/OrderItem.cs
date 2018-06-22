using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItem : Entity
    {
        private int productId;
        private string productName;
        private decimal unitPrice;
        private decimal discount;
        private string pictureUrl;
        private int units;

        protected OrderItem()
        {
        }

        public OrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {
            this.productId = productId;
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.discount = discount;
            this.pictureUrl = pictureUrl;
            this.units = units;
        }
    }
}
