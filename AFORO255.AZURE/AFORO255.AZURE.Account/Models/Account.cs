namespace AFORO255.AZURE.Account.Models
{
    public class Account
    {
        public int IdAccount { get; set; }
        public decimal TotalAmount { get; set; }
        public int IdCustomer { get; set; }
        public string FullName { get; set; }

    }
}
