using EShop.Models.Entites;
using EShop.Shared;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Identity.Seeder
{
    public class EShopSeeder
    {
        public static async Task SeedEssentialsAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.User.ToString()));
            //Seed Default User
            var defaultUser = new User { UserName = Authorization.DEFAULT_ADMIN_USERNAME, Email = Authorization.DEFAULT_ADMIN_EMAIL, EmailConfirmed = true, PhoneNumberConfirmed = true };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorization.DEFAULT_ADMIN_PASSWORD);
                await userManager.AddToRoleAsync(defaultUser, Authorization.ADMIN_ROLE.ToString());
            }

        }
    }
}
