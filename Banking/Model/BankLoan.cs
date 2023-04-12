using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Banking.Model
{
    public class BankLoan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Interest_Rate { get; set; }
        public int Loan_Tenure { get; set; }
       
        public List<Loan_Loandetails> loan_loanDetails { get; set; }
      
        public List<Customer_Bank> customer_Banks { get; set; }

        
    }
}
