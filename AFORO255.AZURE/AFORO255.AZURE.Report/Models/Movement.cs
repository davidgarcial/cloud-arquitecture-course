using AFORO255.AZURE.Report.ConfigCollection;

namespace AFORO255.AZURE.Report.Models
{
    [BsonCollection("Movements")]
    public class Movement : Document
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string CreationDate { get; set; }
        public int AccountId { get; set; }

    }
}
