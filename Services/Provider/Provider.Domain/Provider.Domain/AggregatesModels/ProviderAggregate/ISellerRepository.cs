using Mervi.SeedWork;
using System.Threading.Tasks;
using Provider.Domain.AggregatesModels.ProviderAggregate;

namespace Provider.Domain.AggregatesModels.OrderAggregate
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Seller Add(Seller seller);

        void Update(Seller seller);

        Task<Seller> GetAsync(int sellerId);
    }
}
