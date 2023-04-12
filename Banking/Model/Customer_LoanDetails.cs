using Banking.ViewModel;

namespace Banking.Model
{
    public class Customer_LoanDetails
    {
        public int Id { get; set; }
        
        public int CsutomerId { get;set; }
        public Customer customer { get; set; }
        public int LoanDetailsDemoId { get; set; }
        public LoanDetails loanDetails { get; set; }
    }
}
