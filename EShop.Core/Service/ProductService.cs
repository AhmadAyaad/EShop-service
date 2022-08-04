using AutoMapper;
using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Core.IUnitofWork;
using EShop.Models.Entites;
using EShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddNewProductAsync(ProductDTO productDTO)
        {
            var newProduct = _mapper.Map<Product>(productDTO);
            await _unitOfWork.ProductRepo.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<PagedResultDTO<ProductDTO>> FilterProductsByCategoriesIds(List<int> categoriesIds, int pageNumber, int pageSize)
        {
            var filteredProducts = await _unitOfWork.ProductRepo.FilterProductByCategoriesIds(categoriesIds, pageNumber, pageSize);
            return new PagedResultDTO<ProductDTO>
            {
                Items = _mapper.Map<List<ProductDTO>>(filteredProducts.Items),
                RowCount = filteredProducts.RowCount
            };
        }
        public async Task<PagedResultDTO<ProductDTO>> GetPaginatedProductsAsync(int pageNumber, int pageSize)
        {
            var productPagedResultDTO = await _unitOfWork.ProductRepo.GetPagedProductsAsync(pageNumber, pageSize);
            return new PagedResultDTO<ProductDTO>
            {
                Items = _mapper.Map<List<ProductDTO>>(productPagedResultDTO.Items),
                RowCount = productPagedResultDTO.RowCount
            };
        }
        public async Task<Response<ProductDTO>> GetProductAsync(int id)
        {
            var product = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            if (product is null)
                return new Response<ProductDTO>(null, ResponseStatus.BadRequest, "Invalid product id.");
            return new Response<ProductDTO>(_mapper.Map<ProductDTO>(product), ResponseStatus.Succeeded);
        }
        public async Task<List<ProductDTO>> GetProductsWithDiscountByIdsAsync(List<int> productsIds)
        {
            var products = await _unitOfWork.ProductRepo.GetProductsWithDiscountByIdsAsync(productsIds);
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
