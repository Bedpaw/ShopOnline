using ShopOnline.Data;

namespace ShopOnline.DTO
{


    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public virtual Order Order { get; set; }
    }
}