using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.AggregatesModels.BuyerAggregate;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using System;

namespace Ordering.Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("Orders");
            orderConfiguration.HasKey(x => x.Id);


            orderConfiguration.OwnsOne(o => o.Address);

            orderConfiguration.Ignore(x => x.DomainEvents);

            orderConfiguration.Property<DateTime>("OrderDate").IsRequired();
            orderConfiguration.Property<int>("OrderStatusId").IsRequired();
            orderConfiguration.Property<int>("BuyerId").IsRequired();


            orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems))
                .SetPropertyAccessMode(PropertyAccessMode.Field);


            orderConfiguration.HasOne<Buyer>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("BuyerId");

            orderConfiguration.HasOne(o => o.OrderStatus)
                .WithMany()
                .HasForeignKey("OrderStatusId");
        }
    }
}
