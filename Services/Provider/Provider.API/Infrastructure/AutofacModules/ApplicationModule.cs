using Autofac;
using Autofac.Core;
using EventBus.Abstractions;
using Provider.API.Application.IntegrationEvents.Handlers;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.Infrastructure.Repositories;
using System.Reflection;

namespace Provider.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SellerRepository>()
                .As<ISellerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(OrderStatusChangedToSubmittedIntegrationEventHandler).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}