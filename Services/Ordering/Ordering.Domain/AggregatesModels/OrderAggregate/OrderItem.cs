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

        private int _ProviderId;
        private string _ProductName;
        private decimal _UnitPrice;
        private decimal _Discount;
        private string _PictureUrl;
        private int _Units;
        private OrderItemStatus _OrderItemStatus;

        public int GetProviderId() => _ProviderId;

        public string GetProductName() => _ProductName;

        public decimal GetUnitPrice() => _UnitPrice;

        public decimal GetCurrentDiscount() => _Discount;

        public string GetPictureUrl() => _PictureUrl;

        public int GetUnits() => _Units;

        protected OrderItem()
        {
        }

        public OrderItem(int productId, int providerId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {
            ProductId = productId;
            _ProviderId = providerId;
            _ProductName = productName;
            _UnitPrice = unitPrice;
            _Discount = discount;
            _PictureUrl = pictureUrl;
            _Units = units;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
                throw new OrderingDomainException("invalid units");

            _Units += units;
        }

        public void SetNewDiscount(decimal discount)
        {
            if (discount < 0)
            {
                throw new OrderingDomainException("Discount is not valid");
            }

            _Discount= discount;
        }
    }
}
