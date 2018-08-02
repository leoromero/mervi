using Basket.Domain;
using Basket.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket.Infrastructure
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);
        IEnumerable<string> GetUsers();
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string id);
        Task<ProductBasketsDTO> GetProductsBasketsAsync(string id);
    }
}