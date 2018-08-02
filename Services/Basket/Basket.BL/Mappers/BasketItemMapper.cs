using Basket.BL.Interfaces;
using Basket.Domain;
using Basket.DTOs;
using System.Collections.Generic;

namespace Basket.BL.Mappers
{
    public class BasketItemMapper : Mapper<BasketItem, BasketItemDTO>
    {
        public override BasketItemDTO ToDto(BasketItem entity)
        {
            return new BasketItemDTO
            {
                Id = entity.Id,
                OldUnitPrice = entity.OldUnitPrice,
                PictureUrl = entity.PictureUrl,
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice
            };
        }

        public override BasketItem ToEntity(BasketItemDTO dto)
        {
            return new BasketItem
            {
                UnitPrice = dto.UnitPrice,
                Quantity = dto.Quantity,
                ProductName = dto.ProductName,
                ProductId = dto.ProductId,
                PictureUrl = dto.PictureUrl,
                Id = dto.Id,
                OldUnitPrice = dto.OldUnitPrice
            };
        }
    }
}
