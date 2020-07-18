using System;

namespace ShopOnline.Data
{  
    [Table ("Orders")]
    public class Order
    {
        public int ID {get; set;}
        public int OrderId {get; set;}
        public string UserName {get; set;}
        public int OrderStatus {get; set;}
        public DateTime OrderSent {get; set;}
        public decimal Amount {get; set;}
        public int? ProductId {get; set;}

        public virtual IList<Product> Product {get; set}

    }
}