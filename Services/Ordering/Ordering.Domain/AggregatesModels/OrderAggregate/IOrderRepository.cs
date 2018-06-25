using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
