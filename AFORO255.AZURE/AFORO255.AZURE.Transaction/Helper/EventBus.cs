using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Transaction.Helper
{
    public class EventBus : IEventBus
    {
        private readonly IConfiguration _configuration;

        public EventBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> PublishMessage(object request)
        {
            string data = JsonConvert.SerializeObject(request);
            Message message = new Message(Encoding.UTF8.GetBytes(data));
            TopicClient client = new TopicClient(_configuration["Bus:Cn"], _configuration["Bus:Topic"]);

            await client.SendAsync(message);

            return true;
        }

    }

}
