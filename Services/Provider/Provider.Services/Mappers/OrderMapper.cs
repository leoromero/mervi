using Mervi.Services.Interfaces;
using Mervi.Services.Mappers;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Linq;

namespace Provider.Services
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
                OrderStatusName = entity.Status.Name,
                OrderItems = orderItemsMapper.ToDtos(entity.OrderItems.ToList()).ToList(),
                OrderDate = entity.GetOrderDate(),
                CustomerOrderId = entity.GetCustomerOrderId(),
                OrderStatusId = entity.Status.Id,
                SellerId = entity.GetSellerId()
            };
        }

        public override Order ToEntity(OrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
