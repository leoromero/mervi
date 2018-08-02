using System.Collections.Generic;

namespace Basket.DTOs
{
    public class CustomerBasketDTO
    {
        public string BuyerId { get; set; }
        public IEnumerable<BasketItemDTO> Items { get; set; }
    }
}