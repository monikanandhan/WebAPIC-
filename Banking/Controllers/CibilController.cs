using Banking.Service;
using Banking.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            service.AddNewCibil(cibil);
            return Ok(cibil);
        }

        [HttpGet]
        public IActionResult GetAllCibil()
        {
            var result = service.GetAllCibil();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBankByCustomerID(int id)
        {
            var result = service.GetCibilbyCustomerid(id);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCibil(int Id, CibilVM cibil)
        {
            var result = service.UpdateCibilDetails(Id, cibil);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBank(int Id)
        {
            service.DeleteCibil(Id);
            return Ok();
        }
    }
}
