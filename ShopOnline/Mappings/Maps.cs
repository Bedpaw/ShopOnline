using AutoMapper;
using ShopOnline.Data;
using ShopOnline.DTOs;

namespace ShopOnline.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
