using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Catalog.Domain.AggregatesModels.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        private string _name;
        private Category _category;
        private int _categoryId;
        private decimal _price;
        private readonly List<ProductTag> _tags;
        private int _providerId;

        public string GetName() => _name;
        public Category GetCategory() => _category;
        public int GetCategoryId() => _categoryId;
        public decimal GetPrice() => _price;
        public IReadOnlyCollection<ProductTag> ProductTags => _tags;
        public IReadOnlyCollection<Tag> Tags => _tags.Select(x => x.Tag).ToList();
        public int GetProviderId() => _providerId;

        public void AddTags(IList<Tag> tags)
        {
            foreach (var tag in tags)
            {
                AddTag(tag);
            }
        }

        public void AddTag(Tag tag)
        {
            if (!Tags.Contains(tag))
                _tags.Add(new ProductTag { Product = this, ProductId = this.Id, Tag = tag, TagId = tag.Id });
        }

        public void SetCategoryId(int categoryId)
        {
            _categoryId = categoryId;
        }
    }
}
