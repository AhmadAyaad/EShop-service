using EShop.Core.IRepository;
using EShop.Core.IUnitofWork;
using EShop.Presistance.Context;
using EShop.Presistance.Repository;
using System.Threading.Tasks;

namespace EShop.Presistance.UnitofWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private IDiscountRepository _discountRepository;
        private IInvoiceRepository _invoiceRepository;
        private readonly EShopDbContext _context;
        public UnitOfWork(EShopDbContext context)
        {
            _context = context;
        }
        public IProductRepository ProductRepo
        {
            get
            {
                if (_productRepository is null)
                    _productRepository = new ProductRepsoitory(_context);
                return _productRepository;
            }
        }
        public IUserRepository UserRepo
        {
            get
            {
                if (_userRepository is null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }
        public IOrderRepository OrderRepo
        {
            get
            {
                if (_orderRepository is null)
                    _orderRepository = new OrderRepository(_context);
                return _orderRepository;
            }
        }
        public ICategoryRepository CategoryRepo
        {
            get
            {
                if (_categoryRepository is null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }
        public IDiscountRepository DiscountRepo
        {
            get
            {
                if (_discountRepository is null)
                    _discountRepository = new DiscountRepository(_context);
                return _discountRepository;
            }
        }
        public IInvoiceRepository InvoiceRepo
        {
            get
            {
                if (_invoiceRepository is null)
                    _invoiceRepository = new InvoiceRepsoitory(_context);
                return _invoiceRepository;
            }
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
