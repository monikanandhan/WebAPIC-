using Banking.Model;
using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            service.AddNewLoan(loan);
            return Ok(loan);
        }

        [HttpGet]
        public IActionResult GetAllLoan()
        {
            var result=service.GetAllLoan();
            return Ok(result);
        }

        [HttpGet("{Name}")]
        public IActionResult GetLoanByName(string Name)
        {
            var result = service.GetLoanByName(Name);
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
            var result=service.UpdateLoanDetails(id,loan);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id)
        {
            service.DeleteLoan(id); 
            return Ok();    
        }

    }
}
