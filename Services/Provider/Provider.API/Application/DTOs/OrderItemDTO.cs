namespace Provider.API.Application.DTOs
{
    public class OrderItemDTO
    {
        public int ProductId { get; internal set; }
        public string ProductName { get; internal set; }
        public string PictureUrl { get; internal set; }
        public decimal UnitPrice { get; internal set; }
        public int Units { get; internal set; }
    }
}
