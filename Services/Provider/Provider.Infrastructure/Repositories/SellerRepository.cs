using Mervi.SeedWork;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Provider.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ProviderContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public SellerRepository(ProviderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async Task<Order> GetAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.OrderStatus)
                .Include(o => o.Address)
                .SingleOrDefaultAsync(o => o.Id == orderId);

            return order;
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
