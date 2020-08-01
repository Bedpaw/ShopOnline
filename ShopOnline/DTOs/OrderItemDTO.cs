namespace ShopOnline.DTOs
{
    public class OrderItemDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItemCreateDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}