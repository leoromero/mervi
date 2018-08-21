using Mervi.SeedWork;
using System.Threading.Tasks;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);

        void Update(Order order);

        Task<Order> GetAsync(int orderId);
    }
}
