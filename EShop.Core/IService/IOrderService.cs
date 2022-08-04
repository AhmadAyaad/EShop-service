using EShop.Core.DTOS;
using EShop.Shared;
using System.Threading.Tasks;

namespace EShop.Core.IService
{
    public interface IOrderService
    {
        Task<Response> PlaceOrderAsync(OrderDTO orderDTO);
    }
}
