using MediatR;
using Ordering.API.Application.Model;
using Ordering.API.Extensions;
using Ordering.DTOs.OrderAggregateDtos;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Ordering.API.Application.Commands
{
    [DataContract]
    public class SetOrderItemsAsSubmittedCommand
        : IRequest<bool>
    {
        [DataMember]
        private readonly IList<OrderItemDto> _orderItems;

        [DataMember]
        public int OrderId { get; private set; }

        [DataMember]
        public string ProviderId { get; private set; }

        [DataMember]
        public IList<OrderItemDto> OrderItems => _orderItems;

        public SetOrderItemsAsSubmittedCommand()
        {
            _orderItems = new List<OrderItemDto>();
        }

        public SetOrderItemsAsSubmittedCommand(IList<ProviderOrderItem> items, int orderId, string providerId) : this()
        {
            _orderItems = items.ToOrderItemsDTO().ToList();
            OrderId = orderId;
            ProviderId = providerId;
        }
    }
}
