using Banking.Model;
using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerService service { get; set; }
        public CustomerController( CustomerService _service) 
        { 
            service = _service;
            
        }

        [HttpPost]
        public IActionResult AddNewCustomer(CustomerVM customer)
        { 
        service.AddCustomerDetails(customer);
            return Ok(customer);
        }

        //[HttpGet]
        //public IActionResult GetAllCustomer() 
        //{
        //    var result = service.GetallCustomer();
        //    return Ok(result);
        //}

        [HttpGet]
        public IActionResult GetCustomer([FromQuery] string Account_number, [FromQuery] string First_Name, [FromQuery] string Aadhar)
        {
        var result=service.GetCustomer(Account_number, First_Name, Aadhar);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerWithId(int id)
        {
            var result = service.GetCustomerWithID(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, CustomerDetailsVM customer)
        {
            var result = service.UpdateCustomer(id, customer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            service.DeleteCustomerById(id);
            return Ok();
        }
    }
}
