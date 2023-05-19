public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductForCreateDto>().ReverseMap();
        CreateMap<Product, ProductForReadDto>().ReverseMap();
        CreateMap<Product, ProductForUpdateDto>().ReverseMap();
    }
}