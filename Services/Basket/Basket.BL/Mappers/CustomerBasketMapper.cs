using Basket.Domain;
using Basket.DTOs;
using Mervi.Services.Mappers;
using System.Linq;

namespace Basket.BL.Mappers
{
    public class CustomerBasketMapper : Mapper<CustomerBasket, CustomerBasketDTO>
    {
        public override CustomerBasketDTO ToDto(CustomerBasket entity)
        {
            return new CustomerBasketDTO
            {
                BuyerId = entity.BuyerId,
                Items = new BasketItemMapper().ToDtos(entity.Items).ToList()
            };
        }

        public override CustomerBasket ToEntity(CustomerBasketDTO dto)
        {
            var basket = new CustomerBasket(dto.BuyerId);
            basket.Items = new BasketItemMapper().ToEntities(dto.Items).ToList();

            return basket;
        }
    }
}
