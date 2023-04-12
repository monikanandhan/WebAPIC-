using Banking.Model;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Banking.Service
{
    public class LoanDetailsService
    {
        public BankingDbContext Context { get; set; }
        public LoanDetailsService(BankingDbContext _Context)
        {

            Context = _Context;
        }

        public void AddLoanDetails(LoanDetailsVM loanDetails)
        {
            var NewDetails = new LoanDetails()
            {
                Id=loanDetails.id,
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
            var result = Context.loanDetail.Select(x => new LoanDetailsLoanVM()
            {
               
                Loan_Amount = x.Loan_Amount,
                Loan_Provided = x.Loan_Provided,
                payment_Mode = x.payment_Mode,
                bankLoans = x.loan_loanDetails.Where(s => s.LoanDetailsId == x.Id).Select(x => x.BankLoan).ToList()
            }).ToList();
            Context.SaveChanges();
           
            return result;
        }

        public List<LoanDetailsLoanVM> GetLoanDetailsByID(int id)
        {
            var result = Context.loanDetail.Where(m=>m.Id==id).Select(x => new LoanDetailsLoanVM()
            {
                id=x.Id,
                Loan_Amount = x.Loan_Amount,
                Loan_Provided = x.Loan_Provided,
                payment_Mode = x.payment_Mode,
              bankLoans=x.loan_loanDetails.Where(s=>s.LoanDetailsId==id).Select(x=>x.BankLoan).ToList()
            }).ToList();
            Context.SaveChanges();

            return result;
        }

        public LoanDetails updateLoanDetails(int id, LoanDetailsonly loanDetails)
        {
            var result = Context.loanDetail.FirstOrDefault(m => m.Id == id);
            if(result != null)
            {
                result.Loan_Amount = loanDetails.Loan_Amount;
                result.Loan_Provided = loanDetails.Loan_Provided;
                result.payment_Mode = loanDetails.payment_Mode; 
            }
            Context.SaveChanges();
            return result;
        }

        public void DeleteDetails(int id)
        {
            var result = Context.loanDetail.FirstOrDefault(m => m.Id == id);
            if (result != null)
            {
                Context.loanDetail.Remove(result);
                Context.SaveChanges();
            }
        }
    }
}
