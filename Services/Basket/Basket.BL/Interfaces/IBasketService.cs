using Basket.BL.IntegrationEvents.Events;
using Basket.Domain;
using Basket.DTOs;
using Basket.DTOs.Requests;
using Basket.DTOs.Responses;
using System.Threading.Tasks;

namespace Basket.BL.Interfaces
{
    public interface IBasketService
    {
        Task<Response<bool>> Checkout(BasketCheckoutRequest basketCheckout);
        Task<ProductBasketsDTO> GetProductsBasketsAsync(string id);
        Task<CustomerBasketDTO> GetBasketAsync(string basketId);
        Task<Response<CustomerBasketDTO>> UpdateBasketAsync(CustomerBasketDTO basket);
        Task UpdateProductPriceInAllBaskets(ProductPriceChangedIntegrationEvent @event);
    }
}
