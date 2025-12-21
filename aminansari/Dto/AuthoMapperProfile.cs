using aminansari.Models;
using AutoMapper;

namespace aminansari.Dto
{
    public class AuthoMapperProfile : Profile
    {

        public AuthoMapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();


        }
    }
}
