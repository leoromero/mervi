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
    public class CreateOrderCommand
        : IRequest<bool>
    {
        [DataMember]
        private readonly List<OrderItemDto> _orderItems;

        [DataMember]
        public string UserId { get; private set; }

        [DataMember]
        public string UserName { get; private set; }

        [DataMember]
        public string City { get; private set; }

        [DataMember]
        public string Street { get; private set; }

        [DataMember]
        public string State { get; private set; }

        [DataMember]
        public string Country { get; private set; }

        [DataMember]
        public string ZipCode { get; private set; }

        [DataMember]
        public string Comments { get; private set; }

        [DataMember]
        public IEnumerable<OrderItemDto> OrderItems => _orderItems;

        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDto>();
        }

        public CreateOrderCommand(List<BasketItem> basketItems, string userId, string userName, string city,
            string street, string state, string country, string zipcode) : this()
        {
            _orderItems = basketItems.ToOrderItemsDTO().ToList();
            UserId = userId;
            UserName = userName;
            City = city;
            Street = street;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
    }
}
