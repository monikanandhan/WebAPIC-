﻿using Banking.Model;

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
        public List<string> bankLoans { get; set; }   
       
    }

    public class LoanDetailsonly
    {
      
        public float Loan_Amount { get; set; }
        public DateTime Loan_Provided { get; set; }
        public string payment_Mode { get; set; }
    }
    public class LoanDetailsNoIdVM
    {
       
        public float Loan_Amount { get; set; }
        public DateTime Loan_Provided { get; set; }
        public string payment_Mode { get; set; }


        public List<int> LoanID { get; set; }
    }


}
