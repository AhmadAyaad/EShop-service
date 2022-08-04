using EShop.Core.IRepository;
using EShop.Models.Entites;
using EShop.Presistance.Context;
using EShop.Presistance.Extensions;
using EShop.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Presistance.Repository
{
    public class ProductRepsoitory : BaseRepository<Product>, IProductRepository
    {
        public ProductRepsoitory(EShopDbContext context) : base(context)
        {
        }
        public Task<PagedResultDTO<Product>> FilterProductByCategoriesIds(List<int> categoriesIds, int pageNumber, int pagesize)
        {
            if (categoriesIds.Any())
                return _context.Products.Where(product => categoriesIds
                                        .Any(categoriesId => categoriesId == product.CategoryId))
                                        .GetPagedAsync(pageNumber, pagesize);
            return _context.Products.GetPagedAsync(pageNumber, pagesize);
        }
        public Task<PagedResultDTO<Product>> GetPagedProductsAsync(int pageNumber, int pageSize)
        {
            return _context.Products.Include(product => product.Discount)
                                    .GetPagedAsync(pageNumber, pageSize);
        }
        public Task<List<Product>> GetProductsWithDiscountByIdsAsync(List<int> productsIds)
        {
            return _context.Products.Where(product => productsIds.Any(productId => productId == product.Id))
                                    .ToListAsync();
        }
    }
}
