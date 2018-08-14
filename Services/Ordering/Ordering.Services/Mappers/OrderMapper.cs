using Mervi.Services.Interfaces;
using Mervi.Services.Mappers;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Ordering.DTOs.OrderAggregateDtos;
using System;
using System.Linq;

namespace Ordering.Services
{
    public class OrderMapper : Mapper<Order, OrderDto>
    {
        private readonly IMapper<OrderItem, OrderItemDto> orderItemsMapper;

        public OrderMapper(IMapper<OrderItem,OrderItemDto> mapper)
        {
            this.orderItemsMapper = mapper;
        }

        public override OrderDto ToDto(Order entity)
        {
            return new OrderDto
            {
                Id = entity.Id,
                Address = string.Format("{0} {1}, {2}, {3}, {4}", entity.Address.Street, entity.Address.Number, entity.Address.City, entity.Address.Province, entity.Address.Country),
                BuyerId = entity.GetBuyerId,
                OrderStatusName = entity.OrderStatus.Name,
                OrderItems = orderItemsMapper.ToDtos(entity.OrderItems.ToList()).ToList(),
                OrderDate = entity.GetOrderDate
            };
        }

        public override Order ToEntity(OrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
