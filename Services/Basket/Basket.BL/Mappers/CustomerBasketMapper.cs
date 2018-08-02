using Basket.Domain;
using Basket.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.BL.Mappers
{
    public class CustomerBasketMapper : Mapper<CustomerBasket, CustomerBasketDTO>
    {
        public CustomerBasketDTO ToDto(CustomerBasket entity)
        {
            return new CustomerBasketDTO
            {
                BuyerId = entity.BuyerId,
                Items = new BasketItemMapper().ToDtos(entity.Items)
            };
        }

        public override CustomerBasket ToEntity(CustomerBasketDTO dto)
        {
            var basket = new CustomerBasket(dto.BuyerId);
            basket.Items = new BasketItemMapper().ToEntities(dto.Items);

            return basket;
        }
    }
}
