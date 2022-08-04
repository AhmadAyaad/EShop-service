using EShop.Core.DTOS;
using EShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.IService
{
    public interface IProductService
    {
        Task AddNewProductAsync(ProductDTO productDTO);
        Task<PagedResultDTO<ProductDTO>> GetPaginatedProductsAsync(int pageNumber, int pageSize);
        Task<PagedResultDTO<ProductDTO>> FilterProductsByCategoriesIds(List<int> categoriesIds, int pageIndex, int pageSize);
        Task<Response<ProductDTO>> GetProductAsync(int id);
        Task<List<ProductDTO>> GetProductsWithDiscountByIdsAsync(List<int> productsIds);
    }
}
