using AFORO255.AZURE.Account.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _accountRepository.GetAccounts());
        }

    }
}