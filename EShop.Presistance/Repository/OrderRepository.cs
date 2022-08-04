using EShop.Core.IRepository;
using EShop.Models.Entites;
using EShop.Presistance.Context;

namespace EShop.Presistance.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(EShopDbContext context) : base(context)
        {
        }
    }
}
