using EShop.Core.IRepository;
using System.Threading.Tasks;

namespace EShop.Core.IUnitofWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public IProductRepository ProductRepo { get; }
        public ICategoryRepository CategoryRepo { get; }
        public IDiscountRepository DiscountRepo { get; }
        public IInvoiceRepository InvoiceRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
