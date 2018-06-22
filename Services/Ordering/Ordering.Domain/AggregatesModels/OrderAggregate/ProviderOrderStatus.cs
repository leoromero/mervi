using Ordering.Domain.Exceptions;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class ProviderOrderStatus : Enumeration
    {
        public static ProviderOrderStatus Submitted = new ProviderOrderStatus(1, nameof(Submitted).ToLowerInvariant());
        public static ProviderOrderStatus AwaitingValidation = new ProviderOrderStatus(2, nameof(AwaitingValidation).ToLowerInvariant());
        public static ProviderOrderStatus StockConfirmed = new ProviderOrderStatus(3, nameof(StockConfirmed).ToLowerInvariant());
        public static ProviderOrderStatus Paid = new ProviderOrderStatus(4, nameof(Paid).ToLowerInvariant());
        public static ProviderOrderStatus Shipped = new ProviderOrderStatus(5, nameof(Shipped).ToLowerInvariant());
        public static ProviderOrderStatus Cancelled = new ProviderOrderStatus(6, nameof(Cancelled).ToLowerInvariant());

        protected ProviderOrderStatus()
        {
        }

        public ProviderOrderStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<ProviderOrderStatus> List() =>
            new[] { Submitted, AwaitingValidation, StockConfirmed, Paid, Shipped, Cancelled };

        public static ProviderOrderStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new OrderingDomainException($"Possible values for ProviderOrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ProviderOrderStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
