using Mervi.SeedWork;
using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItem : Entity
    {
        public OrderItemStatus Status { get; private set; }

        private string _providerId;
        private string _productName;
        private decimal _unitPrice;
        private decimal _discount;
        private string _pictureUrl;
        private int _units;
        private int _orderItemStatusId;
        private int _orderId;

        public int ProductId { get; private set; }

        public string GetProviderId() => _providerId;

        public string GetProductName() => _productName;

        public decimal GetUnitPrice() => _unitPrice;

        public decimal GetCurrentDiscount() => _discount;

        public string GetPictureUrl() => _pictureUrl;

        public int GetUnits() => _units;

        public int GetOrderId() => _orderId;

        protected OrderItem()
        {
        }

        public OrderItem(int productId, string providerId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units)
        {
            this.ProductId = productId;
            this._providerId = providerId;
            this._productName = productName;
            this._unitPrice = unitPrice;
            this._discount = discount;
            this._pictureUrl = pictureUrl;
            this._units = units;
            _orderItemStatusId = OrderItemStatus.Submitted.Id;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
                throw new OrderingDomainException("invalid units");

            this._units += units;
        }

        public void SetNewDiscount(decimal discount)
        {
            if (discount < 0)
            {
                throw new OrderingDomainException("Discount is not valid");
            }

            this._discount = discount;
        }

        public void SetSubmittedState()
        {
            this._orderItemStatusId = OrderItemStatus.Submitted.Id;
            this.Status = OrderItemStatus.Submitted;
        }

        public void SetConfirmedState()
        {
            this._orderItemStatusId = OrderItemStatus.StockConfirmed.Id;
            this.Status = OrderItemStatus.StockConfirmed;
        }
    }
}
