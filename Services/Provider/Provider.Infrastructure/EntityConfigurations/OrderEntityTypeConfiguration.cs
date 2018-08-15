using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.Domain.AggregatesModels.ProviderAggregate;
using System;

namespace Provider.Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("Orders");
            orderConfiguration.HasKey(x => x.Id);

            orderConfiguration.Ignore(x => x.DomainEvents);

            orderConfiguration.Property<DateTime>("OrderDate").IsRequired();
            orderConfiguration.Property<int>("OrderStatusId").IsRequired();
            orderConfiguration.Property<string>("CustomerOrderId").IsRequired();

            orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            orderConfiguration.HasOne<Seller>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("SellerId");

            orderConfiguration.HasOne(o => o.Status)
                .WithMany()
                .HasForeignKey("OrderStatusId");
        }
    }
}
