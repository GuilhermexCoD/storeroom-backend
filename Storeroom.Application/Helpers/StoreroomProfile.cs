using AutoMapper;
using Storeroom.Application.Dtos;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Helpers
{
    public class StoreroomProfile : Profile
    {
        public StoreroomProfile()
        {
            CreateMap<Family,FamilyDto>().ReverseMap();

            CreateMap<Product,ProductDto>().ReverseMap();

            CreateMap<ProductProp,ProductPropDto>().ReverseMap();

            CreateMap<ProductStatus,ProductStatusDto>().ReverseMap();

            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}