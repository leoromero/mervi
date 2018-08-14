using Provider.API.Application.DTOs;
using Provider.API.Application.Model;
using System.Collections.Generic;

namespace Provider.API.Extensions
{
    public static class CustomerOrderItemExtensions
    {
        public static IEnumerable<OrderItemDTO> ToOrderItemsDTO(this IEnumerable<CustomerOrderItem> cstomerOrderItems)
        {
            foreach (var item in cstomerOrderItems)
            {
                yield return item.ToOrderItemDTO();
            }
        }

        public static OrderItemDTO ToOrderItemDTO(this CustomerOrderItem item)
        {
            return new OrderItemDTO()
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
