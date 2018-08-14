using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string PictureUrl { get; private set; }
        public int Units { get; private set; }

        public OrderItem(int productId, string productName, decimal unitPrice, string pictureUrl, int units)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.PictureUrl = pictureUrl;
            this.Units = units;
        }

        internal void AddUnits(int units)
        {
            this.Units += units;
        }
    }
}
