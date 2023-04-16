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

        [HttpPost]
        public IActionResult AddNewLoan(BankLoanVM loan)
        {
            Log.Information("Inside Add-New-BankLoan-Details:{@Controller}", GetType().Name);
            service.AddNewLoan(loan);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(loan)}");
            return Ok(loan);
        }

        [HttpGet]
        public IActionResult GetAllLoan()
        {
            Log.Information("Inside Get-all-BankLoan-Details:{@Controller}", GetType().Name);
            var result=service.GetAllLoan();
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpGet("{Name}")]
        public IActionResult GetLoanByName(string Name)
        {
            Log.Information("Inside Get-BankLoan-Details-by-Name:{@Controller}", GetType().Name);
            var result = service.GetLoanByName(Name);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);

        }

        //[HttpGet("{id}")]
        //public IActionResult GetLoanByName(int id)
        //{
        //    var result = service.GetLoanWithCustomerDetails(id);    
        //    return Ok(result);

        //}

        [HttpPut("{id}")]
        public IActionResult UpdateLoan(int id,BankLoanVM loan)
        {
            Log.Information("Inside update-BankLoan-Details-By-id:{@Controller}", GetType().Name);
            var result=service.UpdateLoanDetails(id,loan);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id)
        {
            Log.Information("Inside Delet-BankLoan-Details-By-Id:{@Controller}", GetType().Name);
            var result=service.DeleteLoan(id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok();    
        }

    }
}
