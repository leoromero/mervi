using Ordering.API.Application.Model;
using Ordering.DTOs.OrderAggregateDtos;
using System.Collections.Generic;

namespace Ordering.API.Extensions
{
    public static class ProviderOrderItemExtension
    {
        public static IEnumerable<OrderItemDto> ToOrderItemsDTO(this IEnumerable<ProviderOrderItem> items)
        {
            foreach (var item in items)
            {
                yield return item.ToOrderItemDTO();
            }
        }

        public static OrderItemDto ToOrderItemDTO(this ProviderOrderItem item)
        {
            return new OrderItemDto()
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                PictureUrl = item.PictureUrl,
                UnitPrice = item.UnitPrice,
                Units = item.Units,
                Discount = item.Discount    
            };
        }
    }
}
