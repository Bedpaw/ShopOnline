using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Data
{
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int customerId { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [StringLength(25)]
        public string phone { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(5)]
        public string zipCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}


