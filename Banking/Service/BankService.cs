using Banking.Model;
using Banking.ViewModel;
using System.Reflection.Metadata.Ecma335;

namespace Banking.Service
{
    public class BankService
    {
        public BankingDbContext Context { get; set; }
        public BankService(BankingDbContext _context)
        {
            Context = _context;
        }

        public void AddNewBankDetails(BankByNameVM bank)
        {
            var NewBank = new Bank()
            {
                Bank_Name = bank.Bank_Name,
                Branch_Name = bank.Branch_Name,
                IFSC = bank.IFSC,
                Contact_Number = bank.Contact_Number,
                Email = bank.Email,
                Address1 = bank.Address1,
                Address2 = bank.Address2,
                city = bank.city,
                state = bank.state,
                Country = bank.Country,
                pincode = bank.pincode

            };
            Context.bank.Add(NewBank);  
            Context.SaveChanges();
           
        }

        public List<Bank> GetAllBanks()=>Context.bank.ToList();

        public List<BankWithCustomerVM> GetBankWithCustomer(string Bank_Name)
        {
            var GetBankId = Context.bank.Where(x => x.Bank_Name == Bank_Name).Select(n => new BankWithCustomerVM()
            {
                Id = n.Id,
                Bank_Name = n.Bank_Name,
                Branch_Name = n.Branch_Name,
                IFSC = n.IFSC,
                Contact_Number = n.Contact_Number,
                Email = n.Email,
                Address1 = n.Address1,
                Address2 = n.Address2,
                city = n.city,
                state = n.state,
                Country = n.Country,
                pincode = n.pincode,
                customers = n.Customer_Banks.Where(x => x.BankId== n.Id).Select(x => x.customer).ToList()

            }).ToList();
            Context.SaveChanges();
            return GetBankId;
        }

        //public List<BankByNameVM> GetBankByName(string Bank_Name)
        //{
        //    var GetBankId = Context.bank.Where(x => x.Bank_Name == Bank_Name).Select(n => new BankByNameVM()
        //    {
        //        Id = n.Id,
        //        Bank_Name = n.Bank_Name,
        //        Branch_Name = n.Branch_Name,
        //        IFSC = n.IFSC,
        //        Contact_Number = n.Contact_Number,
        //        Email = n.Email,
        //        Address1 = n.Address1,
        //        Address2 = n.Address2,
        //        city = n.city,
        //        state = n.state,
        //        Country = n.Country,
        //        pincode = n.pincode

        //    }).ToList();
        //    Context.SaveChanges();
        //    return GetBankId;
        //}
        
       public Bank UpdateBank(string IFSC,BankVM bank)
        {
            var NewDetails = Context.bank.FirstOrDefault(n=>n.IFSC== IFSC);
            if(NewDetails != null) 
            {
                NewDetails.Bank_Name = bank.Bank_Name;
                NewDetails.Branch_Name = bank.Branch_Name;
                NewDetails.IFSC = bank.IFSC;
                NewDetails.Contact_Number = bank.Contact_Number;
                NewDetails.Email = bank.Email;
                NewDetails.Address1 = bank.Address1;
                NewDetails.Address2 = bank.Address2;
                NewDetails.city = bank.city;
                NewDetails.state = bank.state;
                NewDetails.Country = bank.Country;
                NewDetails.pincode = bank.pincode;
            }
            Context.SaveChanges();
            return NewDetails;
        }

        public void DeleteByIFSC(string IFSC)
        {
            var RemoveDetails = Context.bank.FirstOrDefault(n => n.IFSC == IFSC);
            if (RemoveDetails != null)
            {
                Context.bank.Remove(RemoveDetails);   
                Context.SaveChanges();  

            }
        }
    }
}
