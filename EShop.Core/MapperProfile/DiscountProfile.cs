using AutoMapper;
using EShop.Core.DTOS;
using EShop.Models.Entites;

namespace EShop.Core.MapperProfile
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountDTO, Discount>().ReverseMap();
        }
    }
}
