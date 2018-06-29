using Mervi.SeedWork;
using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class OrderItemStatus : Enumeration
    {
        //ToDo: Change to needed values
        public static OrderItemStatus Submitted = new OrderItemStatus(1, nameof(Submitted).ToLowerInvariant());
        public static OrderItemStatus AwaitingValidation = new OrderItemStatus(2, nameof(AwaitingValidation).ToLowerInvariant());
        public static OrderItemStatus StockConfirmed = new OrderItemStatus(3, nameof(StockConfirmed).ToLowerInvariant());
        public static OrderItemStatus Paid = new OrderItemStatus(4, nameof(Paid).ToLowerInvariant());
        public static OrderItemStatus Shipped = new OrderItemStatus(5, nameof(Shipped).ToLowerInvariant());
        public static OrderItemStatus Cancelled = new OrderItemStatus(6, nameof(Cancelled).ToLowerInvariant());

        protected OrderItemStatus()
        {
        }

        public OrderItemStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<OrderItemStatus> List() =>
            new[] { Submitted, AwaitingValidation, StockConfirmed, Paid, Shipped, Cancelled };

        public static OrderItemStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new OrderingDomainException($"Possible values for OrderItemStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static OrderItemStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new OrderingDomainException($"Possible values for OrderItemStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
