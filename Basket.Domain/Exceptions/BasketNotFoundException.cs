using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain.Exceptions
{
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException() : base("The requested basket does not exist or is empty.")
        {
        }
    }
}
