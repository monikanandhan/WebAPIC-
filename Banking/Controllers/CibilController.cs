using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Serilog;

namespace Banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CibilController : ControllerBase
    {
        public CibilService service { get; set; }
        public CibilController(CibilService _service) 
        { 
            service = _service;
        
        }


        [HttpPost]
        public IActionResult AddNewCibil(CibilVM cibil)
        {
            Log.Information("Inside Add-New-Cibil-Details:{@Controller}", GetType().Name);
            service.AddNewCibil(cibil);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(cibil)}");
            return Ok(cibil);
        }

        [HttpGet]
        public IActionResult GetAllCibil()
        {
            Log.Information("Inside Get-all-Cibil-Details:{@Controller}", GetType().Name);
            var result = service.GetAllCibil();
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBankByCustomerID(int id)
        {
            Log.Information("Inside Get-Cibil-Details-by-id:{@Controller}", GetType().Name);
            var result = service.GetCibilbyCustomerid(id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCibil(int Id, CibilVM cibil)
        {
            Log.Information("Inside update-Cibil-Details-By-id:{@Controller}", GetType().Name);
            var result = service.UpdateCibilDetails(Id, cibil);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBank(int Id)
        {
            Log.Information("Inside Delet-Cibil-Details-By-Id:{@Controller}", GetType().Name);
            var result=service.DeleteCibil(Id);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok();
        }
    }
}
