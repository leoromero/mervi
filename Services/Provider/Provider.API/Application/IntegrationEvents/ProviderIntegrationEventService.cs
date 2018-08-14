using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Abstractions;
using EventBus.Events;
using Ordering.Infrastructure;

namespace Ordering.API.Application.IntegrationEvents
{
    public class ProviderIntegrationEventService : IProviderIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly OrderingContext _orderingContext;

        public ProviderIntegrationEventService(IEventBus eventBus, OrderingContext orderingContext)
        {
            _orderingContext = orderingContext ?? throw new ArgumentNullException(nameof(orderingContext));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }
        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            await SaveEventAndOrderingContextChangesAsync(evt);
            _eventBus.Publish(evt);
        }

        private async Task SaveEventAndOrderingContextChangesAsync(IntegrationEvent evt)
        {
             await _orderingContext.SaveChangesAsync();
        }
    }
}
