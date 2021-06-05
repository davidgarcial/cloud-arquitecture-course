using Microsoft.AspNetCore.Identity;

namespace AFORO255.AZURE.Security.Components
{
    public interface IJwtGenerator
    {
        string Create(IdentityUser userRequest);
    }
}
