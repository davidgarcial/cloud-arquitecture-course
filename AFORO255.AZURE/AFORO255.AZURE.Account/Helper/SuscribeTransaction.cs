using AFORO255.AZURE.Account.DTOs;
using AFORO255.AZURE.Account.Repositories;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Account.Helper
{
    public class SuscribeTransaction : ISuscribeTransaction
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SubscriptionClient _subscriptionClient;

        public SuscribeTransaction(IConfiguration configuration, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _subscriptionClient = new SubscriptionClient(configuration["Bus:Cn"],
                                                         configuration["Bus:Topic"],
                                                         configuration["Bus:Subscription"]);
        }


        public async Task CloseSuscribe()
        {
            await _subscriptionClient.CloseAsync();
        }

        private Task ProcessError(ExceptionReceivedEventArgs arg)
        {
            var contextError = arg.ExceptionReceivedContext;
            return Task.CompletedTask;
        }

        private async Task ConsumeMessage(Message message, CancellationToken token)
        {
            string data = Encoding.UTF8.GetString(message.Body);
            TransactionResponse transactionDTO = JsonConvert.DeserializeObject<TransactionResponse>(data);
            await _accountRepository.UpdateAccount(transactionDTO.AccountId, transactionDTO.Amount);

            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }


        public async Task Process()
        {
            MessageHandlerOptions messageopt =
               new MessageHandlerOptions(ProcessError)
               {
                   AutoComplete = false,
                   MaxConcurrentCalls = 1
               };

            _subscriptionClient.RegisterMessageHandler(ConsumeMessage, messageopt);
        }
    }
}
