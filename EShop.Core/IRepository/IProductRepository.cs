using EShop.Models.Entites;
using EShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.IRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<PagedResultDTO<Product>> GetPagedProductsAsync(int pageNumber, int pageSize);
        Task<PagedResultDTO<Product>> FilterProductByCategoriesIds(List<int> categoriesIds, int pageNumber, int pageSize);
        Task<List<Product>> GetProductsWithDiscountByIdsAsync(List<int> productsIds);
    }
}
