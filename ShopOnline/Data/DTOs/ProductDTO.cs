using System;

namespace ShopOnline.ProductDTO
{


    public class ProductDTD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public virtual Order Order { get; set; }
    }
}