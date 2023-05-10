using Banking.Model;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using Serilog;

namespace Banking.Service
{
    public class LoanDetailsService
    {
        public BankingDbContext Context { get; set; }
        public LoanDetailsService(BankingDbContext _Context)
        {

            Context = _Context;
        }

        public void AddLoanDetails(LoanDetailsNoIdVM loanDetails)
        {
            Log.Information("Inside Add-New-Loan-Details:{@Controller}", GetType().Name);
            var NewDetails = new LoanDetails()
            {
                
                Loan_Amount = loanDetails.Loan_Amount,
                Loan_Provided = loanDetails.Loan_Provided,
                payment_Mode = loanDetails.payment_Mode

            };
            Context.loanDetail.Add(NewDetails);
            Context.SaveChanges();
            foreach (var item in loanDetails.LoanID)
            {
                var NewLoanDetails = new Loan_Loandetails()
                {
                    LoanDetailsId = NewDetails.Id,
                    BankLoanId = item
                };
                Context.loan_loanDetails.Add(NewLoanDetails);
                Context.SaveChanges();              
            }

        }

        public List<LoanDetailsLoanVM> GetLoanDetails()
        {
            Log.Information("Inside Get-Loan-Details:{@Controller}", GetType().Name);
            var GetLoanDetails = Context.loanDetail.Select(x => new LoanDetailsLoanVM()
            {
               
                Loan_Amount = x.Loan_Amount,
                Loan_Provided = x.Loan_Provided,
                payment_Mode = x.payment_Mode,
                bankLoans = x.loan_loanDetails.Where(s => s.LoanDetailsId == x.Id).Select(x => x.BankLoan.Name  ).ToList()
            }).ToList();
            Context.SaveChanges();
           
            return GetLoanDetails;
        }

        public List<LoanDetailsLoanVM> GetLoanDetailsByID(int id)
        {
            Log.Information("Inside Get-Loan-Details-by-id:{@Controller}", GetType().Name);
            var GetLoanDetailsId = Context.loanDetail.Where(m=>m.Id==id).Select(x => new LoanDetailsLoanVM()
            {
                id=x.Id,
                Loan_Amount = x.Loan_Amount,
                Loan_Provided = x.Loan_Provided,
                payment_Mode = x.payment_Mode,
              bankLoans=x.loan_loanDetails.Where(s=>s.LoanDetailsId==id).Select(x=>x.BankLoan.Name).ToList()
            }).ToList();
            Context.SaveChanges();
            Log.Information($"The user input for Get-Loan-Details-by-id is {JsonConvert.SerializeObject(id)}");
            return GetLoanDetailsId;
        }

        public LoanDetails updateLoanDetails(int id, LoanDetailsonly loanDetails)
        {
            Log.Information("Inside update-Loan-Details-By-id:{@Controller}", GetType().Name);
            var updateLoanDetails = Context.loanDetail.FirstOrDefault(m => m.Id == id);
            if(updateLoanDetails != null)
            {
                updateLoanDetails.Loan_Amount = loanDetails.Loan_Amount;
                updateLoanDetails.Loan_Provided = loanDetails.Loan_Provided;
                updateLoanDetails.payment_Mode = loanDetails.payment_Mode; 
            }
            Context.SaveChanges();
            Log.Information($"The user input for update-Loan-Details-By-id is {JsonConvert.SerializeObject(id)}");
            return updateLoanDetails;
        }

        public LoanDetails DeleteDetails(int id)
        {
            Log.Information("Inside Delete-Loan-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteLoanDetails = Context.loanDetail.FirstOrDefault(m => m.Id == id);
            Log.Information($"The user input for Delete-Loan-Details-By-Id is {JsonConvert.SerializeObject(id)}");
            if (DeleteLoanDetails != null)
            {
                Context.loanDetail.Remove(DeleteLoanDetails);
                Context.SaveChanges();
            }
            return DeleteLoanDetails;
        }
    }
}
