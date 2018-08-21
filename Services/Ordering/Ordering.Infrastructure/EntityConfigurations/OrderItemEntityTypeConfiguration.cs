using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.AggregatesModels.BuyerAggregate;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using System;

namespace Ordering.Infrastructure.EntityConfigurations
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
        {
            orderItemConfiguration.ToTable("OrderItems");
            orderItemConfiguration.HasKey(x => x.Id);            

            orderItemConfiguration.Property<int>("ProductId").IsRequired();

            orderItemConfiguration.Property<decimal>("UnitPrice").IsRequired();
            orderItemConfiguration.Property<decimal>("Discunt").IsRequired();
            orderItemConfiguration.Property<string>("PictureUrl").IsRequired(false);
            orderItemConfiguration.Property<int>("Units").IsRequired();
            orderItemConfiguration.Property<string>("ProviderId").IsRequired();
            orderItemConfiguration.Property<string>("ProductName").IsRequired();
            orderItemConfiguration.Property<int>("OrderId").IsRequired();
            
            orderItemConfiguration.Ignore(x => x.DomainEvents);
        }
    }
}
