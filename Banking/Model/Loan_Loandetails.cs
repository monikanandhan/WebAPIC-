namespace Banking.Model
{
    public class Loan_Loandetails
    {
        public int Id { get; set; }
        public BankLoan BankLoan { get; set; }
        public int BankLoanId { get; set; }
        public LoanDetails LoanDetails { get; set; }
        public int LoanDetailsId { get; set;}
    }
}
