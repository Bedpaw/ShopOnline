public class Map : Profile
{
    public Map()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
    }

}
