using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.AggregatesModels.BuyerAggregate;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using System;

namespace Ordering.Infrastructure.EntityConfigurations
{
    public class OrderItemStatusEntityTypeConfiguration : IEntityTypeConfiguration<OrderItemStatus>
    {
        public void Configure(EntityTypeBuilder<OrderItemStatus> orderStatusConfiguration)
        {
            orderStatusConfiguration.ToTable("OrderItemStatus");

            orderStatusConfiguration.HasKey(o => o.Id);

            orderStatusConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            orderStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
