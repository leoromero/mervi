using Mervi.Services.Interfaces;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.API.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper<Order, OrderDto> _mapper;

        public OrderQueries(IOrderRepository repository, IMapper<Order, OrderDto> mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<IList<OrderDto>> GetProviderOrdersAsync(string providerId)
        {
            var result = await _repository.GetByProviderAsync(providerId);
            return _mapper.ToDtos(result).ToList();
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            var result = await _repository.GetAsync(orderId);
            return _mapper.ToDto(result);
        }
    }
}
