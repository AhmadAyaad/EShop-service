using EShop.Core.IRepository;
using EShop.Models.Entites;
using EShop.Presistance.Context;

namespace EShop.Presistance.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EShopDbContext context) : base(context)
        {
        }
    }
}
