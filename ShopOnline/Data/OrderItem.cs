using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Data
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductId;

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int OrderId;
    }
}
