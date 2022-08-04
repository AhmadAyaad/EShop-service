using EShop.Core.IRepository;
using EShop.Models.Entites;
using EShop.Presistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EShop.Presistance.Repository
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(EShopDbContext context) : base(context)
        {
        }
        public Task<Discount> GetDiscountByProductIdAsync(int productId)
        {
            return _context.Discounts.SingleOrDefaultAsync(discount => discount.ProductId == productId);
        }
    }
}
