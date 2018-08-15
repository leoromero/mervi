using MediatR;
using Provider.Domain.AggregatesModels.OrderAggregate;

namespace Provider.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderStartedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
