using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Data
{
    [Table("Products")]
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public virtual Order Order { get; set; }
    }
}