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
            Log.Information("Inside Add-New-Customer-Details:{@Controller}", GetType().Name);
            service.AddCustomerDetails(customer);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(customer)}");
            return Ok(customer);
        }

        //[HttpGet]
        //public IActionResult GetAllCustomer() 
        //{
        //    var result = service.GetallCustomer();
        //    return Ok(result);
        //}

        [HttpGet]
        public IActionResult GetCustomer( string? Account_number,  string? First_Name, string? Aadhar)
        {
            Log.Information("Inside Get-all-Customer-Details:{@Controller}", GetType().Name);
            var result = service.GetCustomer(Account_number, First_Name, Aadhar);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetCustomerWithId(int id)
        {
            Log.Information("Inside Get-Customer-Details-by-id:{@Controller}", GetType().Name);
            var result = service.GetCustomerWithID(id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, CustomerDetailsVM customer)
        {
            Log.Information("Inside update-Customer-Details-By-id:{@Controller}", GetType().Name);
            var result = service.UpdateCustomer(id, customer);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Log.Information("Inside Delet-Customer-Details-By-Id:{@Controller}", GetType().Name);
            var result=service.DeleteCustomerById(id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok();
        }
    }
}
