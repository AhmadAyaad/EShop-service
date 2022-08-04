using AutoMapper;
using EShop.Core.DTOS;
using EShop.Models.Entites;

namespace EShop.Core.MapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
