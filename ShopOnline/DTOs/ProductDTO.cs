using System.ComponentModel.DataAnnotations;
using ShopOnline.Data;

namespace ShopOnline.DTOs
{

    public class ProductDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public decimal Quantity { get; set; }
        public string Image { get; set; }
  
    }
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float? Price { get; set; }
        
        [Required]
        public float? Quantity { get; set; }
        public string Image { get; set; }
    }
    public class ProductUpdateDTO
    {

        public string Name { get; set; }
      
        public float Price { get; set; }
        
        public float Quantity { get; set; }
        
        public string Image { get; set; }
    }
}