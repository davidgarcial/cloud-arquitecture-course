using AFORO255.AZURE.Security.Components;
using AFORO255.AZURE.Security.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IJwtGenerator jwtGenerator;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IJwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtGenerator = jwtGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest userRequest)
        {
            var user = await userManager.FindByEmailAsync(userRequest.Email);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, userRequest.Password, false);
            if (result.Succeeded)
            {
                UserResponse userResponse = new UserResponse()
                {
                    Token = jwtGenerator.Create(user),
                    Username = user.UserName,
                    AccessTokenExpiration = "1d"
                };

                return Ok(userResponse);
            }
            return Unauthorized();
        }


    }
}
