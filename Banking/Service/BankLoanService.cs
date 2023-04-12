using Banking.Model;
using Banking.ViewModel;

namespace Banking.Service
{
    public class BankLoanService
    {
        public BankingDbContext Context { get; set; }
        public BankLoanService(BankingDbContext _context)
        {
            Context = _context;
        }

        public void AddNewLoan(BankLoanVM loan)
        {
            var NewLoan = new BankLoan()
            {
                Name = loan.Name,
                Interest_Rate = loan.Interest_Rate,
                Loan_Tenure = loan.Loan_Tenure
            };
            Context.bankloan.Add(NewLoan);
            Context.SaveChanges();
            //foreach (var item in loan.Customer)
            //{
            //    var NewCustomer = new Customer_BankLoan()
            //    {
            //        Bank_loanId = NewLoan.Id,
            //        CustomerId = item
            //    };
            //    Context.customer_BankLoans.Add(NewCustomer);    
            //    Context.SaveChanges();
            //}
        }

        public List<BankLoan> GetAllLoan()=>Context.bankloan.ToList();

        public List<LoanByNameVM> GetLoanByName(string Name)
        {
            var GetLoan = Context.bankloan.Where(x => x.Name == Name.ToUpper()).Select(x => new LoanByNameVM()
            {
                id = x.Id,
                Name = x.Name,
                Interest_Rate = x.Interest_Rate,
                Loan_Tenure = x.Loan_Tenure
            }).ToList();
            Context.SaveChanges();
            return GetLoan;

        }


        //public List<LoanWithCustomerVM> GetLoanWithCustomerDetails(int id)
        //{
        //    var GetLoan = Context.bankloan.Where(x => x.Id==id).Select(x => new LoanWithCustomerVM()
        //    {
        //        id = x.Id,
        //        Name = x.Name,

        //        Details=x.customer_BankLoans.Where(m=>m.Bank_loanId==x.Id).Select(n=>new CustomerDetailsVM()).ToList()
        //    }).ToList();
        //    Context.SaveChanges();
        //    return GetLoan;

        //}

        public BankLoan UpdateLoanDetails(int id, BankLoanVM loan)
        {
            var updateLoan=Context.bankloan.FirstOrDefault(x => x.Id == id);    
            if(updateLoan!=null)
            {
                updateLoan.Name = loan.Name;
                updateLoan.Interest_Rate = loan.Interest_Rate;
                updateLoan.Loan_Tenure = loan.Loan_Tenure;  
            }
            Context.SaveChanges();
            return updateLoan;
        }

        public void DeleteLoan(int id)
        {
            var DeleteLoan = Context.bankloan.FirstOrDefault(x => x.Id == id);
            if (DeleteLoan != null)
            {
                Context.bankloan.Remove(DeleteLoan);
                Context.SaveChanges();
            }
        }                   
    }
}
