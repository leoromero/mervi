using System;
using Mervi.Model.Base;
using Mervi.Model.Shop;

namespace Mervi.Model.Catalogue
{
    public class ProductCreateModel : ICreateModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryModel Category { get; set; }
        public string Brand { get; set; }
        public string Quality { get; set; }
        public long SellerId { get; set; }
    }
}
