using EShop.Core.IRepository;
using EShop.Models.Entites;
using EShop.Presistance.Context;

namespace EShop.Presistance.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EShopDbContext context) : base(context)
        {
        }
    }
}
