using System;
using System.Collections.Generic;
using Basket.Domain;

namespace Factory
{
    public class BasketItemFactory
    {
        public static IList<BasketItem> GetItemsWithOneItem()
        {
            return new List<BasketItem>
            {
                new BasketItem
                {
                    Id="1",
                    OldUnitPrice=10,
                    PictureUrl="",
                    ProductId="1",
                    ProductName="a product",
                    Quantity=1,
                    UnitPrice=10
                }
            };
}
    }
}