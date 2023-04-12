using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            service.AddLoanDetails(loanDetails);
            return Ok();    
        }

        [HttpGet]
        public IActionResult GetLoanDetails() 
        {
        var result=service.GetLoanDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoanDetailsById(int id)
        {
            var result = service.GetLoanDetailsByID(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoanDetailsById(int id,LoanDetailsonly loanDetailsonly)
        {
            var result = service.updateLoanDetails(id,loanDetailsonly);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoanDetailsById(int id)
        {
           service.DeleteDetails(id);
            return Ok();
        }

    }
}
