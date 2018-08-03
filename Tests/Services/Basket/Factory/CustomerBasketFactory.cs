using Basket.Domain;
using System;

namespace Factory
{
    public class CustomerBasketFactory
    {
        public static CustomerBasket GetEmptyCustomerBasket()
        {
            return new CustomerBasket("1");
        }
        public static CustomerBasket GetCustomerBasketWithItems()
        {
            var basket = GetEmptyCustomerBasket();
            basket.Items = BasketItemFactory.GetItemsWithOneItem();
            return basket;
        }
    }
}
