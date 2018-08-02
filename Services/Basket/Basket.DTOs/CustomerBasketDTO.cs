using System.Collections.Generic;

namespace Basket.DTOs
{
    public class CustomerBasketDTO
    {
        public string BuyerId { get; set; }
        public IList<BasketItemDTO> Items { get; set; }
    }
}