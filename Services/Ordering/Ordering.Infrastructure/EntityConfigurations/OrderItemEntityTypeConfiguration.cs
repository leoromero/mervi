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

            orderItemConfiguration.Property("UnitPrice").IsRequired();
            orderItemConfiguration.Property("Discunt").IsRequired();
            orderItemConfiguration.Property("PictureUrl").IsRequired(false);
            orderItemConfiguration.Property("Units").IsRequired();
            orderItemConfiguration.Property("ProviderId").IsRequired();
            orderItemConfiguration.Property("ProductName").IsRequired();

            orderItemConfiguration.Ignore(x => x.DomainEvents);
        }
    }
}
