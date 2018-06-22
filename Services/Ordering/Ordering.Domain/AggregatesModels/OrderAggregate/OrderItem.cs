using Ordering.Domain.Exceptions;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }

        public string GetProductName => _productName;
        private string _productName;

        public decimal GetUnitPrice => _unitPrice;
        private decimal _unitPrice;

        public decimal GetDiscount => _discount;
        private decimal _discount;

        public string GetPictureUrl => _pictureUrl;
        private string _pictureUrl;

        public int GetUnits => _units;
        private int _units;

        protected OrderItem()
        {
        }

        public OrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {
            ProductId = productId;
            _productName = productName;
            _unitPrice = unitPrice;
            _discount = discount;
            _pictureUrl = pictureUrl;
            _units = units;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
                throw new OrderingDomainException("invalid units");

            _units += units;
        }
    }
}
