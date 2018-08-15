using Mervi.Services.Mappers;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.DTOs.OrderAggregateDtos;
using System;

namespace Provider.Services
{
    public class OrderItemMapper : Mapper<OrderItem, OrderItemDto>
    {
        public override OrderItemDto ToDto(OrderItem entity)
        {
            return new OrderItemDto
            {
                PictureUrl = entity.GetPictureUrl(),
                ProductId = entity.ProductId,
                ProductName  = entity.GetProductName(),
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
