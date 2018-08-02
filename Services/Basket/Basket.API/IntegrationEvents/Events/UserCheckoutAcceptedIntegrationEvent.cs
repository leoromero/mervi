using Basket.Domain;
using EventBus.Events;
using System;

namespace Basket.API.IntegrationEvents.Events
{
    internal class UserCheckoutAcceptedIntegrationEvent : IntegrationEvent
    {
        private readonly string buyerId;
        private readonly string city;
        private readonly string street;
        private readonly string state;
        private readonly string country;
        private readonly string zipCode;
        private readonly string cardNumber;
        private readonly string cardHolderName;
        private readonly DateTime cardExpiration;
        private readonly string cardSecurityNumber;
        private readonly int cardTypeId;
        private readonly CustomerBasket basket;

        public UserCheckoutAcceptedIntegrationEvent(string buyerId, string city, string street, string state, string country, 
            string zipCode, string cardNumber, string cardHolderName, DateTime cardExpiration, string cardSecurityNumber, 
            int cardTypeId, CustomerBasket basket)
        {
            this.buyerId = buyerId;
            this.city = city;
            this.street = street;
            this.state = state;
            this.country = country;
            this.zipCode = zipCode;
            this.cardNumber = cardNumber;
            this.cardHolderName = cardHolderName;
            this.cardExpiration = cardExpiration;
            this.cardSecurityNumber = cardSecurityNumber;
            this.cardTypeId = cardTypeId;
            this.basket = basket;
        }
    }
}