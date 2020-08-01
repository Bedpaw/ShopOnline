using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Data
{
    public class Order
    {
        [Key] public int Id { get; set; }

        public int OrderStatus { get; set; }

        [ForeignKey("CustomerId")] public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}