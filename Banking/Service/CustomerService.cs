using Banking.Model;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mysqlx;
using Newtonsoft.Json;
using Serilog;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Banking.Service
{
    public class CustomerService
    {
        public BankingDbContext Context { get; set; }
        public CustomerService(BankingDbContext _Context) 
        {
            Context = _Context;     
        }

        //validation
        /********** To check already exists or not **********/
        public int TocheckFirstNameAadhar(string First_name, string Aadhar)
        {
            Log.Information("Inside To-check-First_Name-Aadhar-exists:{@Controller}", GetType().Name);
            var GetAll = Context.Customer.Where(x => x.First_Name == First_name && x.Aadhar == Aadhar).Count();
            Log.Information($"The user input is {JsonConvert.SerializeObject(Aadhar)}");
            Log.Information($"The user input is {JsonConvert.SerializeObject(First_name)}");
            Context.SaveChanges();
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(GetAll)}");
            return GetAll;
        }

        /********** To check is alphabet or not **********/
        public bool IsAlpha(string First_name)
        {
            Log.Information("Inside To-check-alphabets-First_name:{@Controller}", GetType().Name);
           
            var boolResult= Regex.IsMatch(First_name, "^[a-zA-Z ]+$");
            Log.Information($"The user input is {JsonConvert.SerializeObject(First_name)}");
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(boolResult)}");
            
            return boolResult;
        }

      
        public void AddCustomerDetails(CustomerVM customer)
        {
            Log.Information("Inside Add-New-Customer-Details:{@Controller}", GetType().Name);
            var NewCustomer = new Customer()
            {

                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                DateOfBirth = customer.DateOfBirth,
                age = (((DateTime.Now).Subtract(customer.DateOfBirth)).Days) / 360,
                Mobile_Number = customer.Mobile_Number,
                Email = customer.Email,
                Aadhar = customer.Aadhar,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                city = customer.city,
                state = customer.state,
                Country = customer.Country,
                pincode = customer.pincode,
                Account_Number=customer.Account_Number,
                Account_Type=customer.Account_Type

                
            };
            Context.Customer.Add(NewCustomer);
            Context.SaveChanges();
            
            var ScoreDetails = Context.cibil.Where(s => s.Aadhar_Number==customer.Aadhar).AsQueryable()
                .Any(m =>m.CIBIL_year=="2023" && m.CIBIL_Score >700);
            if (!ScoreDetails)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                
                foreach (var item in customer.loanDetailsId)
                {
                    var newId = new Customer_LoanDetails()
                    {
                        CsutomerId = NewCustomer.Id,
                        LoanDetailsDemoId = item
                    };
                    Context.customer_LoanDetails.Add(newId);
                    Context.SaveChanges();
                }
            }
            foreach (var item in customer.BankId)
            {
                var newBankID = new Customer_Bank()
                {
                    customerId = NewCustomer.Id,
                    BankId = item
                };
                Context.customer_Banks.Add(newBankID);
                Context.SaveChanges();
            }
           
        }

        /************GET-ALL*************/
        //public List<CustomerWithLoanDetailsVM> GetallCustomer()
        //{
        //    Log.Information("Inside Get-all-Customer-Details:{@Controller}", GetType().Name);
        //    var GetAll = Context.Customer.Select(c => new CustomerWithLoanDetailsVM()
        //    {
        //        Id = c.Id,
        //        First_Name = c.First_Name,
        //        Last_Name = c.Last_Name,
        //        DateOfBirth = c.DateOfBirth,
        //        age = c.age,
        //        Mobile_Number = c.Mobile_Number,
        //        Email = c.Email,
        //        Aadhar = c.Aadhar,
        //        Address1 = c.Address1,
        //        Address2 = c.Address2,
        //        city = c.city,
        //        state = c.state,
        //        Country = c.Country,
        //        pincode = c.pincode,
        //        Account_Number = c.Account_Number,

        //        Account_Type = c.Account_Type,
        //        loanDetails = c.loanDetailsCusList.Where(n => n.CsutomerId == c.Id).Select(n => n.loanDetails.Id).ToList(),
        //        Bank_Details = c.Customer_Banks.Where(n => n.customerId == c.Id).Select(s => s.Bank.IFSC).ToList()


        //    }).ToList();
        //    Context.SaveChanges();
        //    return GetAll;
        //}



        //Multiple optional parameter
        public List<CustomerWithLoanDetailsVM> GetCustomer(string Account_number, string First_Name, string Aadhar)
        {
            Log.Information("Inside Get-Customer-Details-by-Account_number-First_name-Aadhar:{@Controller}", GetType().Name);
            var GetCustomer = Context.Customer.Where(x => x.Account_Number == Account_number || x.First_Name == First_Name || x.Aadhar == Aadhar).Select(c => new CustomerWithLoanDetailsVM()
            {
                Id = c.Id,
                First_Name = c.First_Name,
                Last_Name = c.Last_Name,
                DateOfBirth = c.DateOfBirth,
                age = c.age,
                Mobile_Number = c.Mobile_Number,
                Email = c.Email,
                Aadhar = c.Aadhar,
                Address1 = c.Address1,
                Address2 = c.Address2,
                city = c.city,
                state = c.state,
                Country = c.Country,
                pincode = c.pincode,
                Account_Number = c.Account_Number,
                Account_Type = c.Account_Type,
                loanDetails = c.loanDetailsCusList.Where(n => n.CsutomerId == c.Id).Select(n => n.loanDetails.Id).ToList(),
                Bank_Details = c.Customer_Banks.Where(n => n.customerId == c.Id).Select(s => s.Bank.IFSC).ToList()

            }).ToList();
            Context.SaveChanges();
            Log.Information($"The user input for Get-Customer-Details-by-Account_number is {JsonConvert.SerializeObject(Account_number)}");
            Log.Information($"The user input for Get-Customer-Details-by-First-Name is {JsonConvert.SerializeObject(First_Name)}");
            Log.Information($"The user input for Get-Customer-Details-by-Aadhar is {JsonConvert.SerializeObject(Aadhar)}");
            return GetCustomer;
        }
        public CustomerWithLoanDetailsVM GetCustomerWithID(int id)
        {
            Log.Information("Inside Get-Customer-Details-by-id:{@Controller}", GetType().Name);
            var GetCustomerID = Context.Customer.Where(x => x.Id == id).Select(c => new CustomerWithLoanDetailsVM()
            {
                Id = c.Id,
                First_Name = c.First_Name,
                Last_Name = c.Last_Name,
                DateOfBirth = c.DateOfBirth,
                age = c.age,
                Mobile_Number = c.Mobile_Number,
                Email = c.Email,
                Aadhar = c.Aadhar,
                Address1 = c.Address1,
                Address2 = c.Address2,
                city = c.city,
                state = c.state,
                Country = c.Country,
                pincode = c.pincode,
                Account_Number = c.Account_Number,
                Account_Type = c.Account_Type,
                loanDetails = c.loanDetailsCusList.Where(n => n.CsutomerId == c.Id).Select(n => n.loanDetails.Id).ToList(),
                Bank_Details = c.Customer_Banks.Where(n => n.customerId == c.Id).Select(s => s.Bank.IFSC).ToList()

            }).FirstOrDefault();
            Context.SaveChanges();
            Log.Information($"The user input for Get-Customer-Details-by-Id is {JsonConvert.SerializeObject(id)}");
            return GetCustomerID;
        }

        public Customer UpdateCustomer(string Account_Number,CustomerDetailsVM customer)
        {
            Log.Information("Inside update-Customer-Details-By-id:{@Controller}", GetType().Name);
            var updateCustomer=Context.Customer.FirstOrDefault(x=>x.Account_Number== Account_Number);
            if (updateCustomer != null)
            {
                updateCustomer.First_Name = customer.First_Name;
                updateCustomer.Last_Name = customer.Last_Name;
                updateCustomer.DateOfBirth = customer.DateOfBirth;
                updateCustomer.age = (((DateTime.Now).Subtract(customer.DateOfBirth)).Days) / 360;
                updateCustomer.Mobile_Number = customer.Mobile_Number;
                updateCustomer.Email = customer.Email;
                updateCustomer.Aadhar = customer.Aadhar;
                updateCustomer.Address1 = customer.Address1;
                updateCustomer.Address2 = customer.Address2;
                updateCustomer.city = customer.city;
                updateCustomer.state = customer.state;
                updateCustomer.Country = customer.Country;
                updateCustomer.pincode = customer.pincode;
                updateCustomer.Account_Number = customer.Account_Number;
                updateCustomer.Account_Type = customer.Account_Type;

            }
            Context.SaveChanges();
            Log.Information($"The user input  for update-Customer-Details-By-id is {JsonConvert.SerializeObject(Account_Number)}");
            return updateCustomer;
        }


        public Customer DeleteCustomerById(string Account_Number)
        {
            Log.Information("Inside Delete-Customer-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteCustomer = Context.Customer.FirstOrDefault(x => x.Account_Number == Account_Number);
            Log.Information($"The user input for Delete-Customer-Details-By-Id is {JsonConvert.SerializeObject(Account_Number)}");
            if (DeleteCustomer != null)
            {
                Context.Customer.Remove(DeleteCustomer);
                Context.SaveChanges();
            }
            return DeleteCustomer;
        }
        
    }
}
