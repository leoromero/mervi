using System;
using System.Collections.Generic;

namespace Provider.DTOs.OrderAggregateDtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public IList<OrderItemDto> OrderItems { get; set; }

        public string OrderStatusName { get; set; }

        public int OrderStatusId { get; set; }
        
        public string CustomerOrderId { get; set; }

        public string SellerId { get; set; }
    }
}
