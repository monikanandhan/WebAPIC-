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

       

        [HttpPost]
        public IActionResult AddNewBank(BankByNameVM bank)
        {
            Log.Information("Inside Add-New-Bank-Details:{@Controller}",  GetType().Name);
            service.AddNewBankDetails(bank);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(bank)}");
            return Ok(bank);
        }

        [HttpGet]
        public IActionResult GetAllBank()
        {
            Log.Information("Inside Get-All-Bank-Details:{@Controller}",GetType().Name);
            var result = service.GetAllBanks();
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        //[HttpGet("{Bank_Name}")]
        //public IActionResult GetBankByName(string Bank_Name)
        //{
        //    var result = service.GetBankByName(Bank_Name);
        //    return Ok(result);
        //}


        [HttpGet("{Bank_Name}")]
        public IActionResult GetBankByName(string Bank_Name)
        {
            Log.Information("Inside Get-Bank-Details-By-Name Method:{@Controller}", GetType().Name);
            var result = service.GetBankWithCustomer(Bank_Name);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }




        [HttpPut("{IFSC}")]
        public IActionResult UpdatBank(string IFSC, BankByNameVM bank)
        {
            Log.Information("Inside Update-All-Bank-Details-By-ID Method:{@Controller}", GetType().Name);
            var result = service.UpdateBank(IFSC,bank);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok(result);
        }

        [HttpDelete("{IFSC}")]
        public IActionResult DeleteBank(string IFSC) 
        {
            Log.Information("Inside Delete-Bank-Details Method:{Controller}", GetType().Name);
            var result=service.DeleteByIFSC(IFSC);
            Log.Information($"The response for the get Banking is {JsonConvert.SerializeObject(result)}");
            return Ok();
        }
    }

}
