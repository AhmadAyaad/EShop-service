using EShop.Core.DTOS;
using EShop.Shared;
using System.Threading.Tasks;

namespace EShop.Core.IService
{
    public interface IDiscountService
    {
        Task<Response> AddNewDiscountAsync(DiscountDTO discountDTO);
        Task<DiscountDTO> GetDiscountByProductIdAsync(int productId);
    }
}
