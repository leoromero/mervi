using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.AggregatesModels.ProductAggregate
{
    public class Category : Entity
    {
        private string _name;
        private Category _category;
        public string GetName() => _name;
        public Category GetCategory() => _category;
    }
}
