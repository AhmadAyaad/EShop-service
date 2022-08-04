using EShop.Models.Entites;
using System.Threading.Tasks;

namespace EShop.Core.IRepository
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        Task<Discount> GetDiscountByProductIdAsync(int productId);
    }
}
