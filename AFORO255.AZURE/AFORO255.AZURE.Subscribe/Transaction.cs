using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;

namespace AFORO255.AZURE.Subscribe
{
    public static class Transaction
    {
        [FunctionName("Transaction")]
        public async static void Run([ServiceBusTrigger("transaction-topic", "report-subscription", Connection = "CnBus")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            var data = JsonConvert.DeserializeObject<TransactionRequest>(mySbMsg);
            log.LogInformation($"La cuenta es: {data.AccountId}, se realizara un {data.Type} de {data.Amount} USD");


            log.LogInformation(" ==================================");
            log.LogInformation("    Start proccess in database");
            var cnMongo = Environment.GetEnvironmentVariable("CnMongo");
            var databaseMongo = Environment.GetEnvironmentVariable("DatabaseMongo");
            var collectionMongo = Environment.GetEnvironmentVariable("CollectionMongo");

            MongoClient client = new MongoClient(cnMongo);
            var database = client.GetDatabase(databaseMongo);
            var collection = database.GetCollection<TransactionModel>(collectionMongo);

            TransactionModel transactionModel = new TransactionModel()
            {
                IdTransaction = data.Id,
                AccountId = data.AccountId,
                Amount = data.Amount,
                CreationDate = data.CreationDate,
                Type = data.Type
            };
            await collection.InsertOneAsync(transactionModel);
            log.LogInformation("        Created item in database with id: {0} \n", data.Id);
            log.LogInformation("    End proccess in database");
            log.LogInformation(" ==================================");

        }


        public class TransactionRequest
        {
            public int Id { get; set; }
            public int IdTransaction { get; set; }
            public decimal Amount { get; set; }
            public string Type { get; set; }
            public string CreationDate { get; set; }
            public int AccountId { get; set; }
        }


        public class TransactionModel
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public int IdTransaction { get; set; }
            public decimal Amount { get; set; }
            public string Type { get; set; }
            public string CreationDate { get; set; }
            public int AccountId { get; set; }
        }


    }
}
