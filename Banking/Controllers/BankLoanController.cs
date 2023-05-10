using Banking.Model;
using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankLoanController : ControllerBase
    {
        public BankLoanService service { get; set; }
        public BankLoanController(BankLoanService _service) 
        { 
            service = _service;
        }

        [HttpPost(" Add-New-BankLoan-Details")]
        public IActionResult AddNewLoan(BankLoanVM loan)
        {
            Log.Information("Inside Add-New-BankLoan-Details:{@Controller}", GetType().Name);
            service.AddNewLoan(loan);
            Log.Information($"The response for the Add-New-BankLoan-Details is {JsonConvert.SerializeObject(loan)}");
            return Ok(loan);
        }

        [HttpGet("Get-All-BankLoan-Details")]
        public IActionResult GetAllLoan()
        {
            Log.Information("Inside Get-all-BankLoan-Details:{@Controller}", GetType().Name);
            var GetAllBankLoan=service.GetAllLoan();
            Log.Information($"The response for the Get-all-BankLoan-Details is {JsonConvert.SerializeObject(GetAllBankLoan)}");
            return Ok(GetAllBankLoan);
        }

        [HttpGet("Get-BankLoan-Details-by-Bank-Loan-Name/{Name}")]
        public IActionResult GetLoanByName(string Name)
        {
            Log.Information("Inside Get-BankLoan-Details-by-Name:{@Controller}", GetType().Name);
            var GetBankLoanByName = service.GetLoanByName(Name);
            Log.Information($"The response for the Get-BankLoan-Details-by-Name is {JsonConvert.SerializeObject(GetBankLoanByName)}");
            return Ok(GetBankLoanByName);

        }

        //[HttpGet("{id}")]
        //public IActionResult GetLoanByName(int id)
        //{
        //    var result = service.GetLoanWithCustomerDetails(id);    
        //    return Ok(result);

        //}

        [HttpPut("update-BankLoan-Details-By-Id/{id}")]
        public IActionResult UpdateLoan(int id,BankLoanVM loan)
        {
            Log.Information("Inside update-BankLoan-Details-By-id:{@Controller}", GetType().Name);
            var UpdateBankLoan=service.UpdateLoanDetails(id,loan);
            Log.Information($"The response for the update-BankLoan-Details-By-id is {JsonConvert.SerializeObject(UpdateBankLoan)}");
            return Ok(UpdateBankLoan);
        }

        [HttpDelete("Delete-BankLoan-Details-By-Id/{id}")]
        public IActionResult DeleteLoan(int id)
        {
            Log.Information("Inside Delete-BankLoan-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteBankLoan=service.DeleteLoan(id);
            Log.Information($"The response for the Delete-BankLoan-Details-By-Id is {JsonConvert.SerializeObject(DeleteBankLoan)}");
            return Ok();    
        }

    }
}
