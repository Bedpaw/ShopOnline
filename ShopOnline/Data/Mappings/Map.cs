using AutoMapper;
using ShopOnline.Data;
using ShopOnline.Data.DTO;
using ShopOnline.DTO;
using System;

namespace ShopOnline.Data.Mappings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }

        private object CreateMap<T1, T2>()
        {
            throw new NotImplementedException();
        }
    }
}
