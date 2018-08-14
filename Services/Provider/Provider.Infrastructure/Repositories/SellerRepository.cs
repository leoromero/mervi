using Mervi.SeedWork;
using Microsoft.EntityFrameworkCore;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.Domain.AggregatesModels.ProviderAggregate;
using System;
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

        public Seller Add(Seller seller)
        {
            return _context.Sellers.Add(seller).Entity;
        }

        public async Task<Seller> GetAsync(int sellerId)
        {
            var order = await _context.Sellers
                .SingleOrDefaultAsync(s => s.Id == sellerId);

            return order;
        }

        public void Update(Seller seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
        }
    }
}
