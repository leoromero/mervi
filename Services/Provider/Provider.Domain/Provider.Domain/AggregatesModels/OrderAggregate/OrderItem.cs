using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public string GetProductName() => _productName;
        public decimal GetUnitPrice() => _unitPrice;
        public string GetPictureUrl() => _pictureUrl;
        public int GetUnits() => _units; 

        private int _units;
        private readonly string _productName;
        private readonly decimal _unitPrice;
        private readonly string _pictureUrl;

        public OrderItem(int productId, string productName, decimal unitPrice, string pictureUrl, int units)
        {
            this.ProductId = productId;
            this._productName = productName;
            this._unitPrice = unitPrice;
            this._pictureUrl = pictureUrl;
            this._units = units;
        }

        internal void AddUnits(int units)
        {
            this._units += units;
        }
    }
}
