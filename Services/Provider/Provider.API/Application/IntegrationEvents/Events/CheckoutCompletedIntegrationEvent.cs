using EventBus.Events;
using Ordering.API.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.IntegrationEvents.Events
{
    public class CheckoutCompletedIntegrationEvent : IntegrationEvent
    {
        public string UserId { get; }

        public string UserName { get; }

        public string City { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string Buyer { get; set; }

        public Guid RequestId { get; set; }

        public CustomerBasket Basket { get; }

        public CheckoutCompletedIntegrationEvent(string userId, string userName, string city, string street,
            string state, string country, string zipCode, string buyer, Guid requestId,
            CustomerBasket basket)
        {
            UserId = userId;
            City = city;
            Street = street;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Buyer = buyer;
            Basket = basket;
            RequestId = requestId;
            UserName = userName;
        }
    }
}
