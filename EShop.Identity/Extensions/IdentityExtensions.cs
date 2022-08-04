using EShop.Identity.IService;
using EShop.Identity.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Identity.Extensions
{
    public class IdentityExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
