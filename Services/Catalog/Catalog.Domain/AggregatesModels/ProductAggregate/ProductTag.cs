namespace Catalog.Domain.AggregatesModels.ProductAggregate
{
    public class ProductTag
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}