using Banking.Model;
using Banking.ViewModel;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Serilog;
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

        public void AddNewBankDetails(BankListVM bank)
        {
            Log.Information("Inside add-Bank-Details Method:{Controller}", GetType().Name);
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

        public List<BankByNameVM> GetAllBanks()
        {
            var GetBank = Context.bank.Select(n => new BankByNameVM()
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


            }).ToList();
            Context.SaveChanges();

            return GetBank;
        }

        public List<BankWithCustomerVM> GetBankWithCustomer(string Bank_Name)
        {
            Log.Information("Inside get-Bank-Details Method:{Controller}", GetType().Name);
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
                customers = n.Customer_Banks.Where(x => x.BankId== n.Id).Select(x => x.customer.Account_Number).ToList()

            }).ToList();
            Context.SaveChanges();
            Log.Information($"The user input for get-Bank-Details is {JsonConvert.SerializeObject(Bank_Name)}");
            return GetBankId;
        }

        /***********GET-BY-NAME********/

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
        
       public Bank UpdateBank(string IFSC, BankByNameVM bank)
        {
            Log.Information("Inside update-Bank-Details Method:{Controller}", GetType().Name);
            var UpdateBank = Context.bank.FirstOrDefault(n=>n.IFSC== IFSC);
            if(UpdateBank != null) 
            {
                
                UpdateBank.Branch_Name = bank.Branch_Name;
                UpdateBank.IFSC = bank.IFSC;
                UpdateBank.Contact_Number = bank.Contact_Number;
                UpdateBank.Email = bank.Email;
                UpdateBank.Address1 = bank.Address1;
                UpdateBank.Address2 = bank.Address2;
                UpdateBank.city = bank.city;
                UpdateBank.state = bank.state;
                UpdateBank.Country = bank.Country;
                UpdateBank.pincode = bank.pincode;
            }
            Context.SaveChanges();
            Log.Information($"The user input for update-Bank-Details is {JsonConvert.SerializeObject(IFSC)}");
            return UpdateBank;
        }

        public Bank DeleteByIFSC(string IFSC)
        {
            Log.Information("Inside Delete-Bank-Details Method:{Controller}", GetType().Name);
            var RemoveDetails = Context.bank.FirstOrDefault(n => n.IFSC == IFSC);
            Log.Information($"The user input for   Delete-Bank-Details is  {JsonConvert.SerializeObject(IFSC)}");
            if (RemoveDetails != null)
            {
                Context.bank.Remove(RemoveDetails);   
                Context.SaveChanges();  

            }
            return RemoveDetails;
        }
    }
}
