using EventBus.Events;

namespace Basket.BL.IntegrationEvents.Events
{
    public class ProductPriceChangedIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; internal set; }
        public decimal NewPrice { get; internal set; }
        public decimal OldPrice { get; internal set; }
    }
}