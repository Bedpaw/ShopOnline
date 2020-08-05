using System.Collections.Generic;

namespace ShopOnline.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }

    public class OrderCreateDTO
    {
        public int CustomerId { get; set; }
        public ICollection<OrderItemCreateDTO> OrderItems { get; set; }
    }
}