using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Data
{
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int productId { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal quantity { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

}
