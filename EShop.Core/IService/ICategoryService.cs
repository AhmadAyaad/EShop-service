using EShop.Core.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.IService
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategoriesAsync();
    }
}
