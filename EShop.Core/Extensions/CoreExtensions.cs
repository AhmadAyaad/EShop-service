using EShop.Core.IService;
using EShop.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Core.Extensions
{
    public class CoreExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }
    }
}
