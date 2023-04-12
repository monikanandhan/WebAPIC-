using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
             service.AddNewBankDetails(bank);
            return Ok(bank);
        }

        [HttpGet]
        public IActionResult GetAllBank()
        {
            var result = service.GetAllBanks();
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
            var result = service.GetBankWithCustomer(Bank_Name);
            return Ok(result);
        }




        [HttpPut("{IFSC}")]
        public IActionResult UpdatBank(string IFSC,BankVM bank)
        {
            var result = service.UpdateBank(IFSC,bank);
            return Ok(result);
        }

        [HttpDelete("{IFSC}")]
        public IActionResult DeleteBank(string IFSC) 
        {
            service.DeleteByIFSC(IFSC);
            return Ok();
        }
    }

}
