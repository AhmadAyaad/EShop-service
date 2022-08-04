using AutoMapper;
using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Core.IUnitofWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _unitofWork.CategoryRepo.GetAllAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }
    }
}
