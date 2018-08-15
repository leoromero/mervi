using System;
using System.Threading.Tasks;
using EventBus.Abstractions;
using EventBus.Events;
using Provider.Infrastructure;

namespace Provider.API.Application.IntegrationEvents
{
    public class ProviderIntegrationEventService : IProviderIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ProviderContext _providerContext;

        public ProviderIntegrationEventService(IEventBus eventBus, ProviderContext providerContext)
        {
            _providerContext = providerContext ?? throw new ArgumentNullException(nameof(providerContext));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }
        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            await SaveEventAndProviderContextChangesAsync(evt);
            _eventBus.Publish(evt);
        }

        private async Task SaveEventAndProviderContextChangesAsync(IntegrationEvent evt)
        {
             await _providerContext.SaveChangesAsync();
        }
    }
}
