using AFORO255.AZURE.Report.Models;
using AFORO255.AZURE.Report.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AFORO255.AZURE.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMongoRepository<Movement> _mongoRepository;

        public ReportController(IMongoRepository<Movement> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var movementsAccount = _mongoRepository.FilterBy(
                filter => filter.AccountId == id
            );
            if (movementsAccount.FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok(movementsAccount);
        }

    }
}
