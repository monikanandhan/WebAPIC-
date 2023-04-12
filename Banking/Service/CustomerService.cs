using Banking.Model;
using Banking.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace Banking.Service
{
    public class CustomerService
    {
        public BankingDbContext Context { get; set; }
        public CustomerService(BankingDbContext _Context) 
        {
            Context = _Context;     
        }

        public void AddCustomerDetails(CustomerVM customer)
        {
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

        public List<CustomerWithLoanDetailsVM> GetallCustomer()
        {
            var GetAll = Context.Customer.Select(c => new CustomerWithLoanDetailsVM()
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
                loanDetails = c.loanDetailsCusList.Where(n => n.CsutomerId == c.Id).Select(n => n.loanDetails).ToList(),
                Bank_Details=c.Customer_Banks.Where(n=>n.customerId==c.Id).Select(s=>s.Bank).ToList()
                
              
            }).ToList();
            Context.SaveChanges();
            return GetAll;
        }

        public List<CustomerWithLoanDetailsVM> GetCustomer(string Account_number,string First_Name,string Aadhar )
        {
            var result = Context.Customer.Where(x => x.Account_Number == Account_number || x.First_Name == First_Name || x.Aadhar == Aadhar).Select(c => new CustomerWithLoanDetailsVM()
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
                loanDetails = c.loanDetailsCusList.Where(n => n.CsutomerId == c.Id).Select(n => n.loanDetails).ToList(),
                Bank_Details = c.Customer_Banks.Where(n => n.customerId == c.Id).Select(s => s.Bank).ToList()

            }).ToList();
            Context.SaveChanges();
            return result;
        }
        public List<CustomerWithLoanDetailsVM> GetCustomerWithID(int id)
        {
            var result = Context.Customer.Where(x => x.Id == id).Select(c => new CustomerWithLoanDetailsVM()
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
                loanDetails = c.loanDetailsCusList.Where(n => n.CsutomerId == c.Id).Select(n => n.loanDetails).ToList(),
                Bank_Details = c.Customer_Banks.Where(n => n.customerId == c.Id).Select(s => s.Bank).ToList()

            }).ToList();
            Context.SaveChanges();
            return result;
        }

        public Customer UpdateCustomer(int id,CustomerDetailsVM customer)
        {
            var result=Context.Customer.FirstOrDefault(x=>x.Id == id);
            if (result != null)
            {
                result.First_Name = customer.First_Name;
                result.Last_Name = customer.Last_Name;
                result.DateOfBirth = customer.DateOfBirth;
                result.age = (((DateTime.Now).Subtract(customer.DateOfBirth)).Days) / 360;
                result.Mobile_Number = customer.Mobile_Number;
                result.Email = customer.Email;
                result.Aadhar = customer.Aadhar;
                result.Address1 = customer.Address1;
                result.Address2 = customer.Address2;
                result.city = customer.city;
                result.state = customer.state;
                result.Country = customer.Country;
                result.pincode = customer.pincode;
                result.Account_Number = customer.Account_Number;
                result.Account_Type = customer.Account_Type;

            }
            Context.SaveChanges();
            return result;
        }


        public void DeleteCustomerById(int id)
        {
            var DeleteData = Context.Customer.FirstOrDefault(x => x.Id == id);
            if (DeleteData != null)
            {
                Context.Customer.Remove(DeleteData);
                Context.SaveChanges();
            }
        }
        
    }
}
