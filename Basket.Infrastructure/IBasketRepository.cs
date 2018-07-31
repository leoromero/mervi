using Basket.Domain;
using Basket.Infrastructure.Models;
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
        ProductBasketsModel GetProductsBasketsAsync(string id);
    }
}