using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ShopOnline.Data;

namespace ShopOnline.DTOs
{

    public class OrderDTO
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
    
    public class OrderCreateDTO
    {
        public int CustomerId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
    
}
