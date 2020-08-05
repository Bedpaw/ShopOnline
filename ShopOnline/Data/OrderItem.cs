using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Data
{
    public class OrderItem
    {
        public int OrderId;

        public int ProductId;

        [Key] public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")] public Product Product { get; set; }

        [ForeignKey("OrderId")] public Order Order { get; set; }
    }
}