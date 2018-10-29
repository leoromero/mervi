using Mervi.Model.Base;

namespace Mervi.Model.Catalogue
{
    public class CategoryModel : IViewModel
    {
        public string Name { get; set; }
        public long ParentId { get; set; }
        public CategoryModel Parent { get; set; }
    }
}