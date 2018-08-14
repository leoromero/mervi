using Ordering.API.Application.Model;
using Ordering.DTOs.OrderAggregateDtos;
using System.Collections.Generic;

namespace Ordering.API.Extensions
{
    public static class BasketItemExtensions
    {
        public static IEnumerable<OrderItemDto> ToOrderItemsDTO(this IEnumerable<BasketItem> basketItems)
        {
            foreach (var item in basketItems)
            {
                yield return item.ToOrderItemDTO();
            }
        }

        public static OrderItemDto ToOrderItemDTO(this BasketItem item)
        {
            return new OrderItemDto()
            {
                ProductId = int.TryParse(item.ProductId, out int id) ? id : -1,
                ProductName = item.ProductName,
                PictureUrl = item.PictureUrl,
                UnitPrice = item.UnitPrice,
                Units = item.Quantity,
                Discount = item.Discount,
                ProviderId = item.ProviderId                
            };
        }
    }
}
