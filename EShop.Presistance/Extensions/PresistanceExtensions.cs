using EShop.Core.IUnitofWork;
using EShop.Presistance.Context;
using EShop.Presistance.UnitofWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Presistance.Extensions
{
    public class PresistanceExtensions
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EShopDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
