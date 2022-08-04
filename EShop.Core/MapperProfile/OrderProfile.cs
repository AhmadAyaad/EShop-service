using AutoMapper;
using EShop.Core.DTOS;
using EShop.Models.Entites;
using System;
using System.Linq;

namespace EShop.Core.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ForMember(dest => dest.OrderItems,
                                    opt => opt.MapFrom(src => src.OrderItems.Select(orderItemDTO =>
                                    new OrderItem
                                    {
                                        ProductId = orderItemDTO.ProductId,
                                        Quantity = orderItemDTO.Quantity,
                                        CreatedAt = DateTime.Now
                                    })));
        }
    }
}
