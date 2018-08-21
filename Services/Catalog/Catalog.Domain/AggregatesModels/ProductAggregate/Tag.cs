using Mervi.SeedWork;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Domain.AggregatesModels.ProductAggregate
{
    public class Tag : Entity
    {
        public Tag(string name)
        {
            _name = name;
        }

        private readonly string _name;
        private List<ProductTag> _productTags;
        public IReadOnlyCollection<Product> Products => _productTags.Select(x => x.Product).ToList();

        public string GetName() => _name;
    }
}
