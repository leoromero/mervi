using Mervi.Services.Mappers;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Ordering.DTOs.OrderAggregateDtos;
using System;

namespace Ordering.Services
{
    public class OrderItemMapper : Mapper<OrderItem, OrderItemDto>
    {
        public override OrderItemDto ToDto(OrderItem entity)
        {
            return new OrderItemDto
            {
                Discount = entity.GetCurrentDiscount(),
                PictureUrl = entity.GetPictureUrl(),
                ProductId = entity.ProductId,
                ProductName  = entity.GetProductName(),
                ProviderId = entity.GetProviderId(),
                UnitPrice = entity.GetUnitPrice(),
                Units = entity.GetUnits()
            };
        }

        public override OrderItem ToEntity(OrderItemDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
