using Banking.Model;
using Banking.Service;
using Banking.ViewModel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Globalization;

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

        //[HttpPost]
        //public IActionResult AddNewCustomer(CustomerVM customer)
        //{
        //    Log.Information("Inside Add-New-Customer-Details:{@Controller}", GetType().Name);
        //    service.AddCustomerDetails(customer);
        //    Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(customer)}");
        //    return Ok(customer);

        //}


        //[HttpGet("Get-Customer-Details")]
        //public IActionResult GetAllCustomer()
        //{
        //    Log.Information("Inside Get-Customer-Details:{@Controller}", GetType().Name);
        //    var GetAll = service.GetallCustomer();
        //    Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(GetAll)}");
        //    return Ok(GetAll);
        //}

        [HttpPost("Add-New-Customer-Details")]
        public IActionResult AddNewCustomer(CustomerVM customer)
        {
            //DateTime dateValue;
            //string formats = "MM-dd-yyyy hh:mm:ss";
            Log.Information("Inside Add-New-Customer-Details:{@Controller}", GetType().Name);

            if (service.IsAlpha(customer.First_Name))
            {
                
                if (service.TocheckFirstNameAadhar(customer.First_Name, customer.Aadhar) > 0)
                {

                    Log.Information($"The response for the Add-New-Customer-Details is {JsonConvert.SerializeObject("user already exists")}");
                    return NotFound("user already exists");  
                }
                else 
                //if ((DateTime.TryParseExact(customer.DateOfBirth.ToString(), formats, null,
                //DateTimeStyles.None,out dateValue))==true)
                {
                    service.AddCustomerDetails(customer);
                    Log.Information($"The response for the Add-New-Customer-Details is {JsonConvert.SerializeObject(customer)}");
                    return Ok(customer);
                }
                //else
                //{
                //    Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject("Date Format is Wrong")}");
                //    return NotFound("Date Format is Wrong");
                //}
            }
            else
            {
                return NotFound("First_name input format is wrong");
            }
        }



        [HttpGet("Get-Customer-Details-By-Account-Number-First-Name-Aadhar")]
        public IActionResult GetCustomer(string? Account_number, string? First_Name, string? Aadhar)
        {
            Log.Information("Inside Get-Customer-Details-By-Account-Number-First-Name-Aadhar:{@Controller}", GetType().Name);
            var GetCustomer = service.GetCustomer(Account_number, First_Name, Aadhar);
            Log.Information($"The response for the Get-Customer-Details-By-Account-Number-First-Name-Aadhar is {JsonConvert.SerializeObject(GetCustomer)}");
            return Ok(GetCustomer);
        }


        [HttpGet("Get-Customer-Details-By-Id/{id}")]
        public IActionResult GetCustomerWithId(int id)
        {
            Log.Information("Inside Get-Customer-Details-by-id:{@Controller}", GetType().Name);
            var GetCustomerById = service.GetCustomerWithID(id);
            Log.Information($"The response for the Get-Customer-Details-by-id is {JsonConvert.SerializeObject(GetCustomerById)}");
            return Ok(GetCustomerById);
        }

        [HttpPut("Update-Customer-Details-By- Account_Number/{ Account_Number}")]
        public IActionResult PutCustomer(string Account_Number, CustomerDetailsVM customer)
        {
            Log.Information("Inside update-Customer-Details-By-id:{@Controller}", GetType().Name);
            var UpdateCustomer = service.UpdateCustomer(Account_Number, customer);
            Log.Information($"The response for the update-Customer-Details-By-id is {JsonConvert.SerializeObject(UpdateCustomer)}");
            return Ok(UpdateCustomer);
        }

        [HttpDelete("Delete-Customer-Details-By- Account_Number/{ Account_Number}")]
        public IActionResult DeleteCustomer(string Account_Number)
        {
            Log.Information("Inside Delete-Customer-Details-By-Id:{@Controller}", GetType().Name);
            var DeleteCustomer =service.DeleteCustomerById(Account_Number);
            Log.Information($"The response for the Delete-Customer-Details-By-Id is {JsonConvert.SerializeObject(DeleteCustomer)}");
            return Ok();
        }
    }
}
