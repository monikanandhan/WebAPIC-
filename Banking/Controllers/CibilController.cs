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


        [HttpPost("Add-New-Cibil-Details")]
        public IActionResult AddNewCibil(CibilNoId cibil)
        {
            Log.Information("Inside Add-New-Cibil-Details:{@Controller}", GetType().Name);
            service.AddNewCibil(cibil);
            Log.Information($"The response for the Add-New-Cibil-Details is {JsonConvert.SerializeObject(cibil)}");
            return Ok(cibil);
        }

        [HttpGet("Get-All-Cibil-Details")]
        public IActionResult GetAllCibil()
        {
            Log.Information("Inside Get-all-Cibil-Details:{@Controller}", GetType().Name);
            var GetAllCibil = service.GetAllCibil();
            Log.Information($"The response for the Get-all-Cibil-Details is {JsonConvert.SerializeObject(GetAllCibil)}");
            return Ok(GetAllCibil);
        }

        [HttpGet("Get-Cibil-Details-By-Aadhar/{Aadhar}")]
        public IActionResult GetCibilByCustomerID(string Aadhar)
        {
            Log.Information("Inside Get-Cibil-Details-by-Aadhar:{@Controller}", GetType().Name);
            var GetCibilById = service.GetCibilbyCustomerAadhar(Aadhar);
            Log.Information($"The response for the Get-Cibil-Details-by-Aadhar is {JsonConvert.SerializeObject(GetCibilById)}");
            return Ok(GetCibilById);
        }

        [HttpPut("Update-Cibil-Details-By-Aadhar/{Aadhar}")]
        public IActionResult UpdateCibil(string Aadhar, CibilNoId cibil)
        {
            Log.Information("Inside update-Cibil-Details-By-id:{@Controller}", GetType().Name);
            var UpdateCibil = service.UpdateCibilDetails(Aadhar, cibil);
            Log.Information($"The response for the update-Cibil-Details-By-id is {JsonConvert.SerializeObject(UpdateCibil)}");
            return Ok(UpdateCibil);
        }

        [HttpDelete(" Delete-Cibil-Details-By-Aadhar/{Aadhar}")]
        public IActionResult DeleteBank(string Aadhar,int id)
        {
            Log.Information("Inside Delete-Cibil-Details-By-Customer-Id:{@Controller}", GetType().Name);
            var DeleteCibil=service.DeleteCibil(Aadhar,id);
            Log.Information($"The response for the Delete-Cibil-Details-By-Customer-Id is {JsonConvert.SerializeObject(DeleteCibil)}");
            return Ok();
        }
    }
}
