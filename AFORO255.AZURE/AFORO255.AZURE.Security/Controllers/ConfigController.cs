using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AFORO255.AZURE.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { Version = _configuration["Key1Json:name1"], Sql = _configuration["ConnectionStrings:Security"] });
        }

    }
}
