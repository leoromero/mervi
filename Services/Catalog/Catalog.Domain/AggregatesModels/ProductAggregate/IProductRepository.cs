using Mervi.SeedWork;
using System.Threading.Tasks;

namespace Catalog.Domain.AggregatesModels.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);

        void Update(Product product);

        Task<Product> GetAsync(int productId);
    }
}
