using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Security.Repositories
{
    public class UserRepository
    {
        public static async Task Execute(SecurityContext context, UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new IdentityUser
                {
                    UserName = "aforo255",
                    Email = "icuadros@aforo255.com"
                };
                await userManager.CreateAsync(user, "Aforo255#");
            }
        }

    }
}
