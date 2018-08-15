using MediatR;
using Ordering.Domain.AggregatesModels.BuyerAggregate;
using Ordering.Domain.AggregatesModels.OrderAggregate;

namespace Ordering.Domain.Events
{
    public class BuyerVerifiedDomainEvent : INotification
    {
        public Buyer Buyer { get; private set; }
        public int OrderId { get; private set; }

        public BuyerVerifiedDomainEvent(Buyer buyer, int orderId)
        {
            Buyer = buyer;
            OrderId = orderId;
        }
    }
}
