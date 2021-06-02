using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
