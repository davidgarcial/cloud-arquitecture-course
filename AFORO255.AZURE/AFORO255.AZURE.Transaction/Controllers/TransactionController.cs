using AFORO255.AZURE.Transaction.DTOs;
using AFORO255.AZURE.Transaction.Helper;
using AFORO255.AZURE.Transaction.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionContext _transactionContext;
        private readonly IEventBus _eventBus;

        public TransactionController(TransactionContext transactionContext, IEventBus eventBus)
        {
            _transactionContext = transactionContext;
            _eventBus = eventBus;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionRequest request)
        {
            Models.Transaction transaction = new Models.Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                Type = "Deposit",
                CreationDate = DateTime.Now.ToString()
            };
            _transactionContext.Add(transaction);
            await _transactionContext.SaveChangesAsync();

            await _eventBus.PublishMessage(transaction);

            return Ok(transaction);
        }

        [HttpPost("withdrawal")]
        public async Task<IActionResult> Withdrawal([FromBody] TransactionRequest request)
        {
            Models.Transaction transaction = new Models.Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount * -1,
                Type = "withdrawal",
                CreationDate = DateTime.Now.ToString()
            };
            _transactionContext.Add(transaction);
            await _transactionContext.SaveChangesAsync();

            await _eventBus.PublishMessage(transaction);

            return Ok(transaction);
        }

    }
}
