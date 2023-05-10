using Banking.Controllers;
using Banking.Model;
using Banking.Service;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBanking
{
    public abstract class CustomerTest
    {
        public DbContextOptions<BankingDbContext> options { get; set; }
        public CustomerTest(DbContextOptions<BankingDbContext> _options) 
        {
            this.options = _options;                  
        }

        //[Fact]
        //public void Get_All_Customer_Details()
        //{
        //    using (var context = new BankingDbContext(options))
        //    {
        //        var service = new CustomerService(context);

        //        var controller = new CustomerController(service);
        //        var GetTest = controller.GetAllCustomer() as OkObjectResult;
        //        var response = Assert.IsType<List<CustomerWithLoanDetailsVM>>(GetTest.Value);

        //        Assert.Equal(3, response.Count());
        //    }
        //}


        //[Fact]
        //public void Get_Customer_Details()
        //{
        //    using (var context = new BankingDbContext(options))
        //    {
        //        var service = new CustomerService(context);
        //        int pid = 2;
        //        var controller = new CustomerController(service);
        //        var GetTest = controller.GetCustomerWithId(pid) as OkObjectResult;
        //        Assert.IsType<CustomerWithLoanDetailsVM>(GetTest.Value);
        //        var response = GetTest.Value as CustomerWithLoanDetailsVM;
        //        Assert.Equal(pid, response.Id);
        //    }
        //}

        //[Fact]
        //public void Add_Customer_Details()
        //{
        //    using (var context = new BankingDbContext(options))
        //    {
        //        var service = new CustomerService(context);
        //        var controller = new CustomerController(service);

        //        //        var BeforeTest = controller.GetAllCustomer() as OkObjectResult;
        //        //        var number = Assert.IsType<List<CustomerWithLoanDetailsVM>>(BeforeTest.Value).Count();

        //        CustomerVM NewCustomer = new CustomerVM()
        //        {
        //            First_Name = "Hari",
        //            Last_Name = "priya",
        //            Mobile_Number = 9080592602,
        //            Email = "hari@gmail.com",
        //            Aadhar = "EPNPM995945C",
        //            Address1 = "chennai",
        //            Address2 = "chennai",
        //            city = "chennai",
        //            state = "Tamilnadu",
        //            Country = "India",
        //            pincode = "638451",
        //            Account_Number = "123456",
        //            Account_Type = "Savings"
        //        };

        //        var AddTest = controller.AddNewCustomer(NewCustomer);

        //        var AfterTest = controller.GetAllCustomer() as OkObjectResult;
        //        var numbers = Assert.IsType<List<CustomerWithLoanDetailsVM>>(AfterTest.Value).Count();
        //        Assert.Equal(4, numbers);
        //    }

        //}

        //[Fact]
        //public void Delete_by_Account_number()
        //{
        //    using (var context = new BankingDbContext(options))
        //    {
        //        var service = new CustomerService(context);
        //        var controller = new CustomerController(service);

        //        //var BeforeTest = controller.GetAllCustomer() as OkObjectResult;
        //        //var number = Assert.IsType<List<CustomerWithLoanDetailsVM>>(BeforeTest.Value).Count();

        //        string Account_Number = "12345";
        //        var result = controller.DeleteCustomer(Account_Number);

        //        var AfterTest = controller.GetAllCustomer() as OkObjectResult;
        //        var numbers = Assert.IsType<List<CustomerWithLoanDetailsVM>>(AfterTest.Value).Count();
        //        Assert.Equal(3, numbers);
        //    }

        //}
    }
}
