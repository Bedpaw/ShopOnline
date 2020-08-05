using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Data
{
    public class Customer
    {
        [Key] public int Id { get; set; }

        [Required] [StringLength(50)] public string FirstName { get; set; }

        [Required] [StringLength(50)] public string LastName { get; set; }

        [StringLength(25)] public string Phone { get; set; }

        [Required] [StringLength(255)] public string Email { get; set; }

        [StringLength(255)] public string Street { get; set; }

        [StringLength(50)] public string City { get; set; }

        [StringLength(5)] public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}