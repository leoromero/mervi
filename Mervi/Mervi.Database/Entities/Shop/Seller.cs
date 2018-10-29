using System.Collections.Generic;
using Mervi.Database.Entities.Catalogue;

namespace Mervi.Database.Entities.Shop
{
    public class Seller : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}