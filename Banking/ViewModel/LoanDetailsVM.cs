using Banking.Model;

namespace Banking.ViewModel
{
    public class LoanDetailsVM
    {
       public int id { get; set; }  
        public float Loan_Amount { get; set; }
        public DateTime Loan_Provided { get; set; }
        public string payment_Mode { get; set; }

       
        public List<int> LoanID { get; set; }
    }
    public class LoanDetailsLoanVM
    {
        public int id { get; set; }
        public float Loan_Amount { get; set; }
        public DateTime Loan_Provided { get; set; }
        public string payment_Mode { get; set; }

        public List<BankLoan> bankLoans { get; set; }   
       
    }

    public class LoanDetailsonly
    {
        public int id { get; set; }
        public float Loan_Amount { get; set; }
        public DateTime Loan_Provided { get; set; }
        public string payment_Mode { get; set; }

       

    }


}
