using Banking.Model;
using Banking.Service;
using Banking.ViewModel;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Serilog;

namespace Banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        public BankService service { get; set; }
        public BankController(BankService _service)
        {
            service = _service;
        }

       

        [HttpPost("Add-New-Bank-Details")]
        public IActionResult AddNewBank(BankListVM bank)
        {
            Log.Information("Inside Add-New-Bank-Details:{@Controller}",  GetType().Name);
            service.AddNewBankDetails(bank);
            Log.Information($"The response for the Add-New-Bank-Details is {JsonConvert.SerializeObject(bank)}");
            return Ok(bank);
        }

        [HttpGet("Get-All-Bank-Details")]
        public IActionResult GetAllBank()
        {
            Log.Information("Inside Get-All-Bank-Details:{@Controller}",GetType().Name);
            var GetAllBank = service.GetAllBanks();
            Log.Information($"The response for the Get-All-Bank-Details is {JsonConvert.SerializeObject(GetAllBank)}");
            return Ok(GetAllBank);
        }

        //[HttpGet("{Bank_Name}")]
        //public IActionResult GetBankByName(string Bank_Name)
        //{
        //    var result = service.GetBankByName(Bank_Name);
        //    return Ok(result);
        //}


        [HttpGet("Get-Bank-Details-By-Bank-Name/{Bank_Name}")]
        public IActionResult GetBankByName(string Bank_Name)
        {
            Log.Information("Inside Get-Bank-Details-By-Name Method:{@Controller}", GetType().Name);
            var GetBankByName = service.GetBankWithCustomer(Bank_Name);
            Log.Information($"The response for the Get-Bank-Details-By-Name  is {JsonConvert.SerializeObject(GetBankByName)}");
            return Ok(GetBankByName);
        }


        [HttpPut("Update-Bank-Details-By-IFSC/{IFSC}")]
        public IActionResult UpdatBank(string IFSC, BankByNameVM bank)
        {
            Log.Information("Inside Update-All-Bank-Details-By-ID Method:{@Controller}", GetType().Name);
            var UpdateBank = service.UpdateBank(IFSC,bank);
            Log.Information($"The response for the Update-All-Bank-Details-By-ID is {JsonConvert.SerializeObject(UpdateBank)}");
            return Ok(UpdateBank);
        }

        [HttpDelete("Delete-Bank-Details-By-IFSC/{IFSC}")]
        public IActionResult DeleteBank(string IFSC) 
        {
            Log.Information("Inside Delete-Bank-Details Method:{Controller}", GetType().Name);
            var DeleteBank=service.DeleteByIFSC(IFSC);
            Log.Information($"The response for the Delete-Bank-Details is {JsonConvert.SerializeObject(DeleteBank)}");
            return Ok();
        }
    }

}
