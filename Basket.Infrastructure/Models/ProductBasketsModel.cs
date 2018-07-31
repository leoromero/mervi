using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Infrastructure.Models
{
    public class ProductBasketsModel
    {
        public string Id { get; set; }
        public List<string> BasketsIds { get; set; }
    }
}
