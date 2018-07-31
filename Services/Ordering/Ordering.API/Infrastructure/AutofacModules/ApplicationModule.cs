using Autofac;
using EventBus.Abstractions;
using Mervi.Common.EventBus.EventBusRabbitMQ;
using Ordering.API.Application.IntegrationEvents.Events;
using Ordering.API.Application.IntegrationEvents.Handlers;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Ordering.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ordering.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(typeof(CheckoutCompletedIntegrationEventHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
