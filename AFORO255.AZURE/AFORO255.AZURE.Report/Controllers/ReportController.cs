using AFORO255.AZURE.Report.DTOs;
using AFORO255.AZURE.Report.Models;
using AFORO255.AZURE.Report.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.AZURE.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReportController : ControllerBase
    {
        private readonly IMongoRepository<Movement> _mongoRepository;
        private readonly IDistributedCache _distributedCache;

        public ReportController(IMongoRepository<Movement> mongoRepository, IDistributedCache distributedCache)
        {
            _mongoRepository = mongoRepository;
            _distributedCache = distributedCache;
        }


        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            //var movementsAccount = _mongoRepository.FilterBy(
            //    filter => filter.AccountId == id
            //);

            //if (movementsAccount.FirstOrDefault() == null)
            //{
            //    return NotFound();
            //}
            //return Ok(movementsAccount);

            string _key = $"key-account-{id}";

            var _cache = _distributedCache.GetString(_key);
            IEnumerable<Movement> movementsAccount = null;
            if (_cache == null)
            {
                movementsAccount = _mongoRepository.FilterBy(
                filter => filter.AccountId == id
                );
                if (movementsAccount.FirstOrDefault() == null)
                {
                    return NotFound();
                }
                var options = new DistributedCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                _distributedCache.SetString(_key, Newtonsoft.Json.JsonConvert.SerializeObject(movementsAccount), 
                    options);
                return Ok(movementsAccount);
            }
            else
            {
                var movementResponses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MovementResponse>>(_cache);
                return Ok(movementResponses);
            }

        }

    }
}
