using MediatR;
using Provider.Domain.AggregatesModels.OrderAggregate;

namespace Provider.Domain.Events
{
    public class OrderConfirmedDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderConfirmedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
