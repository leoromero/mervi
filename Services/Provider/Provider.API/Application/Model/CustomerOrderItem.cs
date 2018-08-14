using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.API.Application.Model
{
    public class CustomerOrderItem
    {
        public string ProductId { get; internal set; }
        public string ProviderId { get; internal set; }
        public string ProductName { get; internal set; }
        public decimal UnitPrice { get; internal set; }
        public int Quantity { get; internal set; }
        public string PictureUrl { get; internal set; }
    }
}
