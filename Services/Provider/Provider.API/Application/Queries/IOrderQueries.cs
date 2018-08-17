using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.API.Application.Queries
{
    public interface IOrderQueries
    {
        Task<IList<OrderDto>> GetProviderOrdersAsync(string providerId);
        Task<OrderDto> GetOrderAsync(int orderId);
    }
}
