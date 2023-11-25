using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ModelsLibrary.ModelsDto;

namespace ModelsLibrary.Helper
{
    public class IdentityInitializer
    {
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "kozyreva_online_shop@mail.ru";
            var password = "_Aa123456";
            if(await roleManager.FindByNameAsync(Constants.AdminRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName));
            }
            if (await roleManager.FindByNameAsync(Constants.UserRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName));
            }
            var test = await userManager.FindByNameAsync(adminEmail);
            if (test == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail, ContactsName = "Администратор", Adress = "Москва", Surname = "Админ", EmailConfirmed = true };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constants.AdminRoleName);
                }
            }
        }
    }
}