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

        [HttpPost("Add-New-Loan-Details")]
        public IActionResult AddNewLoanDetails(LoanDetailsNoIdVM loanDetails)
        {
            Log.Information("Inside Add-New-Loan-Details:{@Controller}", GetType().Name);
            service.AddLoanDetails(loanDetails);
            Log.Information($"The response for the Add-New-Loan-Details is {JsonConvert.SerializeObject(loanDetails)}");
            return Ok();    
        }

        [HttpGet("Get-all-Loan-Details")]
        public IActionResult GetLoanDetails() 
        {
            Log.Information("Inside Get-all-Loan-Details:{@Controller}", GetType().Name);
            var GetAllLoanDetails=service.GetLoanDetails();
            Log.Information($"The response for the Get-all-Loan-Details is {JsonConvert.SerializeObject(GetAllLoanDetails)}");
            return Ok(GetAllLoanDetails);
        }

        [HttpGet("Get-Loan-Details-By-Id/{id}")]
        public IActionResult GetLoanDetailsById(int id)
        {
            Log.Information("Inside Get-Loan-Details-by-id:{@Controller}", GetType().Name);
            var GetLoanDetailsById = service.GetLoanDetailsByID(id);
            Log.Information($"The response for the  Get-Loan-Details-by-id is {JsonConvert.SerializeObject(GetLoanDetailsById)}");
            return Ok(GetLoanDetailsById);
        }

        [HttpPut("Update-Loan-Details-By-Id/{id}")]
        public IActionResult UpdateLoanDetailsById(int id,LoanDetailsonly loanDetailsonly)
        {
            Log.Information("Inside update-Loan-Details-By-id:{@Controller}", GetType().Name);
            var UpdateLoanDetails = service.updateLoanDetails(id,loanDetailsonly);
            Log.Information($"The response for the update-Loan-Details-By-id is {JsonConvert.SerializeObject(UpdateLoanDetails)}");
            return Ok(UpdateLoanDetails);
        }

        [HttpDelete(" Delete-Loan-Details-By-Id/{id}")]
        public IActionResult DeleteLoanDetailsById(int id)
        {
            Log.Information("Inside Delete-Loan-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteLoanDetails=service.DeleteDetails(id);
            Log.Information($"The response for the Delete-Loan-Details-By-Id is {JsonConvert.SerializeObject(DeleteLoanDetails)}");
            return Ok();
        }

    }
}
