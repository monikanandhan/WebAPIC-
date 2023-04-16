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

        public void AddNewBankDetails(BankByNameVM bank)
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
            //Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(NewBank)}");
            Context.SaveChanges();
           
        }

        public List<BankByNameVM> GetAllBanks()
        {
            var GetBankId = Context.bank.Select(n => new BankByNameVM()
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

            return GetBankId;
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





            Log.Information($"The user input is {JsonConvert.SerializeObject(Bank_Name)}");
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
        
       public Bank UpdateBank(string IFSC, BankByNameVM bank)
        {
            Log.Information("Inside update-Bank-Details Method:{Controller}", GetType().Name);
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
            Log.Information($"The user input is {JsonConvert.SerializeObject(IFSC)}");
            return NewDetails;
        }

        public Bank DeleteByIFSC(string IFSC)
        {
            Log.Information("Inside Delete-Bank-Details Method:{Controller}", GetType().Name);
            var RemoveDetails = Context.bank.FirstOrDefault(n => n.IFSC == IFSC);
            Log.Information($"The user input is {JsonConvert.SerializeObject(IFSC)}");
            if (RemoveDetails != null)
            {
                Context.bank.Remove(RemoveDetails);   
                Context.SaveChanges();  

            }
            return RemoveDetails;
        }
    }
}
