using AutoMapper;
using Mervi.Database;
using Mervi.Database.Entities.Catalogue;
using Mervi.Database.Repositories;
using Mervi.Model.Catalogue;

namespace Mervi.Core
{
    public class ProductsService : CrudService<Product, ProductModel, ProductCreateModel, ProductUpdateModel>, IProductsService
    {
        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IProductsRepository>(), mapper)
        {
        }
    }

    public interface IProductsService : ICrudService<Product, ProductModel, ProductCreateModel, ProductUpdateModel>
    {
    }
}