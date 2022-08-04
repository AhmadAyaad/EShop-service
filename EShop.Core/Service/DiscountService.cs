using AutoMapper;
using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Core.IUnitofWork;
using EShop.Models.Entites;
using EShop.Shared;
using System.Threading.Tasks;

namespace EShop.Core.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiscountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> AddNewDiscountAsync(DiscountDTO discountDTO)
        {
            var existingProduct = await _unitOfWork.ProductRepo.GetByIdAsync(discountDTO.ProductId);
            if (existingProduct is null)
                return new Response(ResponseStatus.BadRequest, "Invalid product id.");
            var newDiscount = _mapper.Map<Discount>(discountDTO);
            await _unitOfWork.DiscountRepo.AddAsync(newDiscount);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }

        public async Task<DiscountDTO> GetDiscountByProductIdAsync(int productId)
        {
            var discount = await _unitOfWork.DiscountRepo.GetDiscountByProductIdAsync(productId);
            return _mapper.Map<DiscountDTO>(discount);
        }
    }
}
