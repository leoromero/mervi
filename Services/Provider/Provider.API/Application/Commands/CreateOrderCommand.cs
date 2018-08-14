using MediatR;
using Provider.API.Application.DTOs;
using Provider.API.Application.Model;
using Provider.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Provider.API.Application.Commands
{
    [DataContract]
    public class CreateOrderCommand
        : IRequest<bool>
    {
        [DataMember]
        private readonly List<OrderItemDTO> _orderItems;

        [DataMember]
        public string UserId { get; private set; }

        [DataMember]
        public string UserName { get; private set; }

        [DataMember]
        public string OrderId { get; private set; }

        [DataMember]
        public int CardTypeId { get; private set; }

        [DataMember]
        public string Comments { get; private set; }

        [DataMember]
        public DateTime OrderDate{ get; private set; }

        [DataMember]
        public string ProviderId { get; internal set; }

        [DataMember]
        public IEnumerable<OrderItemDTO> OrderItems => _orderItems;

        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDTO>();
        }

        public CreateOrderCommand(IList<CustomerOrderItem> customerOrderItems, string userId, string orderId, string userName,
            string providerId, DateTime orderDate) : this()
        {
            _orderItems = customerOrderItems.ToOrderItemsDTO().ToList();
            UserId = userId;
            UserName = userName;
            OrderId = orderId;
            OrderDate = orderDate;
            ProviderId = providerId;
        }
    }
}
