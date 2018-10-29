
using System;
using System.Collections.Generic;
using System.Text;
using Mervi.Database.Entities;
using Mervi.Database.Entities.Catalogue;

namespace Mervi.Database.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(MerviContext context) : base(context)
        {
        }
    }

    public interface IProductsRepository : IRepository<Product>
    {
    }
}
