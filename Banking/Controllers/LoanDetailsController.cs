using Banking.Service;
using Banking.ViewModel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        public LoanDetailsService service { get; set; }
        public LoanDetailsController(LoanDetailsService _service) 
        {
            service = _service;
        }

        [HttpPost]
        public IActionResult AddNewLoanDetails(LoanDetailsVM loanDetails)
        {
            Log.Information("Inside Add-New-Loan-Details:{@Controller}", GetType().Name);
            service.AddLoanDetails(loanDetails);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(loanDetails)}");
            return Ok();    
        }

        [HttpGet]
        public IActionResult GetLoanDetails() 
        {
            Log.Information("Inside Get-all-Loan-Details:{@Controller}", GetType().Name);
            var result=service.GetLoanDetails();
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoanDetailsById(int id)
        {
            Log.Information("Inside Get-Loan-Details-by-id:{@Controller}", GetType().Name);
            var result = service.GetLoanDetailsByID(id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoanDetailsById(int id,LoanDetailsonly loanDetailsonly)
        {
            Log.Information("Inside update-Loan-Details-By-id:{@Controller}", GetType().Name);
            var result = service.updateLoanDetails(id,loanDetailsonly);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoanDetailsById(int id)
        {
            Log.Information("Inside Delet-Loan-Details-By-Id:{@Controller}", GetType().Name);
            var result=service.DeleteDetails(id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok();
        }

    }
}
