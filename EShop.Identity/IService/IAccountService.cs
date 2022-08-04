using EShop.Identity.DTOS;
using EShop.Shared;
using System.Threading.Tasks;

namespace EShop.Identity.IService
{
    public interface IAccountService
    {
        Task<Response<UserDTO>> LoginAsync(LoginDTO loginDTO);
        Task<bool> IsExistingUserAsync(string userId);
    }
}
