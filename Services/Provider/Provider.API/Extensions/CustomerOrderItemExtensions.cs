using Provider.API.Application.Model;
using Provider.DTOs.OrderAggregateDtos;
using System.Collections.Generic;

namespace Provider.API.Extensions
{
    public static class CustomerOrderItemExtensions
    {
        public static IEnumerable<OrderItemDto> ToOrderItemsDTO(this IEnumerable<CustomerOrderItem> cstomerOrderItems)
        {
            foreach (var item in cstomerOrderItems)
            {
                yield return item.ToOrderItemDTO();
            }
        }

        public static OrderItemDto ToOrderItemDTO(this CustomerOrderItem item)
        {
            return new OrderItemDto()
            {
                ProductId = int.TryParse(item.ProductId, out int id) ? id : -1,
                ProductName = item.ProductName,
                PictureUrl = item.PictureUrl,
                UnitPrice = item.UnitPrice,
                Units = item.Quantity
            };
        }
    }
}
