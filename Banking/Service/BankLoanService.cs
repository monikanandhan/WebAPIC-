using Banking.Model;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using Serilog;

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
            Log.Information("Inside Add-New-BankLoan-Details:{@Controller}", GetType().Name);
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

        public List<LoanByNameVM> GetAllLoan()
        {
            var GetLoan = Context.bankloan.Select(x => new LoanByNameVM()
            {
                id = x.Id,
                Name = x.Name,
                Interest_Rate = x.Interest_Rate,
                Loan_Tenure = x.Loan_Tenure
            }).ToList();
            Context.SaveChanges();
           
            return GetLoan;
        }

        public List<LoanByNameVM> GetLoanByName(string Name)
        {
            Log.Information("Inside Get-BankLoan-Details-By-Name Method:{@Controller}", GetType().Name);
            var GetLoan = Context.bankloan.Where(x => x.Name == Name.ToUpper()).Select(x => new LoanByNameVM()
            {
                id = x.Id,
                Name = x.Name,
                Interest_Rate = x.Interest_Rate,
                Loan_Tenure = x.Loan_Tenure
            }).ToList();
            Context.SaveChanges();
            Log.Information($"The user input is {JsonConvert.SerializeObject(Name)}");
            return GetLoan;

        }


        //public List<LoanWithCustomerVM> GetLoanWithCustomerDetails(int id)
        //{
        //    var GetLoan = Context.bankloan.Where(x => x.Id == id).Select(x => new LoanWithCustomerVM()
        //    {
        //        id = x.Id,
        //        Name = x.Name,
        //        Details = x.customer_BankLoans.Where(m => m.Bank_loanId == x.Id).Select(n => new CustomerDetailsVM()).ToList()
        //    }).ToList();
        //    Context.SaveChanges();
        //    return GetLoan;

        //}

        public BankLoan UpdateLoanDetails(int id, BankLoanVM loan)
        {
            Log.Information("Inside update-BankLoan-Details-By-id:{@Controller}", GetType().Name);
            var updateLoan=Context.bankloan.FirstOrDefault(x => x.Id == id);    
            if(updateLoan!=null)
            {
                updateLoan.Name = loan.Name;
                updateLoan.Interest_Rate = loan.Interest_Rate;
                updateLoan.Loan_Tenure = loan.Loan_Tenure;  
            }
            Context.SaveChanges();
            Log.Information($"The user input is {JsonConvert.SerializeObject(id)}");
            return updateLoan;
        }

        public BankLoan DeleteLoan(int id)
        {
            Log.Information("Inside Delet-BankLoan-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteLoan = Context.bankloan.FirstOrDefault(x => x.Id == id);
            Log.Information($"The user input is {JsonConvert.SerializeObject(id)}");
            if (DeleteLoan != null)
            {
                Context.bankloan.Remove(DeleteLoan);
                Context.SaveChanges();
            }
            return DeleteLoan;
        }                   
    }
}
