using System.Collections.Generic;

namespace Mervi.Database.Entities.Catalogue
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public long ParentId { get; set; }
        public Category Parent { get; set; }
        public virtual ICollection<Category> Subcategories { get; set; }
    }
}