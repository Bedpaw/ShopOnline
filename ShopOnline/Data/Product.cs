using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopOnline.Data
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required]
        public string Image { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AvailableQuantity { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

}
