using System;
using System.Collections.Generic;

namespace Ordering.DTOs.OrderAggregateDtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public IList<OrderItemDto> OrderItems { get; set; }

        public string Address { get; set; }

        public string OrderStatusName { get; set; }

        private int OrderStatusId { get; set; }

        public string BuyerId { get; set; }
    }
}
