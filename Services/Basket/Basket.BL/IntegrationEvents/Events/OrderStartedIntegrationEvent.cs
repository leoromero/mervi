using EventBus.Events;

namespace Basket.BL.IntegrationEvents.Events
{
    public class OrderStartedIntegrationEvent : IntegrationEvent
    {
        public string UserId { get; set; }
        public string OrderID { get; set; }
    }
}