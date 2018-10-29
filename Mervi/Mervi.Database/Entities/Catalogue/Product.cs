using Mervi.Database.Entities.Shop;

namespace Mervi.Database.Entities.Catalogue
{
    public class Product : BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string Brand { get; set; }
        public string Quality { get; set; }
        public long SellerId { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
