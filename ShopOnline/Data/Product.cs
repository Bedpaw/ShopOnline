using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Data
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required] [StringLength(30)] public string Name { get; set; }

        [Required] public string Image { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? AvailableQuantity { get; set; }

        [JsonIgnore] public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}