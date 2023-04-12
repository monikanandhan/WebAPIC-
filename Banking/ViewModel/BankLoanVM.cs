namespace Banking.ViewModel
{
    public class BankLoanVM
    {
        public string Name { get; set; }
        public float Interest_Rate { get; set; }
        public int Loan_Tenure { get; set; }

        //public List<int> Customer {  get; set; }
    }

    public class LoanByNameVM
    {
        public int id { get;set; }
        public string Name { get; set; }
        public float Interest_Rate { get; set; }
        public int Loan_Tenure { get; set; }
    }

    public class LoanWithCustomerVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<CustomerDetailsVM> Details { get; set; }
        


    }
}
