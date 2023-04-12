using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Banking.Model
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public float Loan_Amount { get; set; }
        public DateTime Loan_Provided { get; set; }
        public string payment_Mode { get; set; }

        //Navigation Properties


        //public List<BankLoan> loans { get; set; }
        //public List<Cibil> cibils { get; set; }
        
        public List<Customer_LoanDetails> loanDetailsCusList { get; set; }
      
        public List<Loan_Loandetails> loan_loanDetails { get; set; }
    }
}
