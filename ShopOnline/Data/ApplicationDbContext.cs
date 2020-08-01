using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Pawel",
                    LastName = "Bednarczyk",
                    Phone = "888777666",
                    Email = "bedpaw111@jakisemail.com",
                    Street = "Kolejowa 5/7",
                    City = "Toruń",
                    ZipCode = "87118",
                    Orders = null
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Patrycja",
                    LastName = "Peczyńska",
                    Phone = "333444555",
                    Email = "patiiiii93@jakisemail.com",
                    Street = "Konstruktorska 3/4",
                    City = "Warszawa",
                    ZipCode = "02254",
                    Orders = null
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Ola",
                    LastName = "Kołacz",
                    Phone = "555666777",
                    Email = "alex@jakisemail.com",
                    Street = "Mickiewicza 11/7",
                    City = "Warszawa",
                    ZipCode = "02111",
                    Orders = null
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Wojtek",
                    LastName = "Jabłoński",
                    Phone = "666777888",
                    Email = "wojciechjsky@jakisemail.com",
                    Street = "Cybernetyki 6",
                    City = "Sandomierz",
                    ZipCode = "27600",
                    Orders = null
                }
            );

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Banana",
                    Price = 0.5m,
                    AvailableQuantity = 50,
                    Image =
                        "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/b9c923fc-b1ea-4ea5-a7fe-8bf4a4d161fc/dbp6tcm-5eaa1d87-5b5d-4eb3-8274-abc0fce4766b.png/v1/fill/w_1024,h_1024,q_80,strp/angry_banana_by_ragenanners258_dbp6tcm-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOiIsImlzcyI6InVybjphcHA6Iiwib2JqIjpbW3siaGVpZ2h0IjoiPD0xMDI0IiwicGF0aCI6IlwvZlwvYjljOTIzZmMtYjFlYS00ZWE1LWE3ZmUtOGJmNGE0ZDE2MWZjXC9kYnA2dGNtLTVlYWExZDg3LTViNWQtNGViMy04Mjc0LWFiYzBmY2U0NzY2Yi5wbmciLCJ3aWR0aCI6Ijw9MTAyNCJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTppbWFnZS5vcGVyYXRpb25zIl19.ymP9H5-qT7QEIMXnK69ONyAqFbSzLcEdJbf9dMBefhc"
                },
                new Product
                {
                    Id = 2,
                    Name = "Strawberry",
                    Price = 0.9m,
                    AvailableQuantity = 700,
                    Image = "https://cdn.pixabay.com/photo/2017/10/14/15/51/strawberry-2850845_960_720.png"
                },
                new Product
                {
                    Id = 3,
                    Name = "Raspberry",
                    Price = 0.2m,
                    AvailableQuantity = 1000,
                    Image = "https://cdn.pixabay.com/photo/2017/10/14/15/51/raspberry-2850842_960_720.png"
                },
                new Product
                {
                    Id = 4,
                    Name = "Kiwi",
                    Price = 1.5m,
                    AvailableQuantity = 150,
                    Image = "https://cdn.pixabay.com/photo/2013/07/12/19/34/kiwi-155022_960_720.png"
                },
                new Product
                {
                    Id = 5,
                    Name = "Apple",
                    Price = 0.6m,
                    AvailableQuantity = 1550,
                    Image = "https://cdn.pixabay.com/photo/2016/06/23/18/55/apple-1475977_960_720.png"
                },
                new Product
                {
                    Id = 6,
                    Name = "Apricot",
                    Price = 0.4m,
                    AvailableQuantity = 400,
                    Image = "https://cdn.pixabay.com/photo/2020/06/23/06/45/apricot-5331575_960_720.png"
                },
                new Product
                {
                    Id = 7,
                    Name = "Orange",
                    Price = 1.5m,
                    AvailableQuantity = 500,
                    Image = "https://cdn.pixabay.com/photo/2018/02/24/10/03/orange-3177693_960_720.png"
                },
                new Product
                {
                    Id = 8,
                    Name = "Avocado",
                    Price = 50,
                    AvailableQuantity = 2,
                    Image =
                        "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.0-9/59922551_304682407111959_1556794403484336128_n.jpg?_nc_cat=106&_nc_sid=09cbfe&_nc_ohc=wSdiX14mNWUAX8IAqOb&_nc_ht=scontent.fzgh1-1.fna&oh=fe1cc92b02e7102c00a71500eddbd36a&oe=5F369CE8"
                });
        }
    }
}