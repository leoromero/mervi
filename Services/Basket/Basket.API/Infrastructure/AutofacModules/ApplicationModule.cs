using Autofac;
using Basket.BL;
using Basket.BL.Interfaces;
using Basket.BL.Mappers;
using Basket.Infrastructure;
using Mervi.Services.Interfaces;
using System.Reflection;

namespace Ordering.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BasketRepository>()
                .As<IBasketRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BasketService>()
                .As<IBasketService>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CustomerBasketMapper).GetTypeInfo().Assembly)
                 .AsClosedTypesOf(typeof(IMapper<,>));
        }
    }
}
