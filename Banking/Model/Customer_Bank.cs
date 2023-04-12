namespace Banking.Model
{
    public class Customer_Bank
    {
        public int Id { get; set; } 
        public int BankId { get;set; }
        public Bank Bank { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
    }
}
