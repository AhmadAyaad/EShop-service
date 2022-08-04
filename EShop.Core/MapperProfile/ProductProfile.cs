using AutoMapper;
using EShop.Core.DTOS;
using EShop.Models.Entites;

namespace EShop.Core.MapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap()
                                            .ForMember(dest => dest.DiscountId, opt => opt
                                            .MapFrom(src => src.Discount.Id));
        }
    }
}
