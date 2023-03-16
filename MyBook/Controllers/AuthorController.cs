using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBook.Model;
using MyBook.Model.ViewModel;
using MyBook.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public AuthorService Authorservice;
        public AuthorController(AuthorService _Authorservice)
        {
            Authorservice = _Authorservice;
        }

        [HttpPost]
        public IActionResult AddNew(AuthorVM author)
        {
            Authorservice.AddAuthor(author);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorWithBook(int id)
        {
            var response=Authorservice.GetAuthorWithBooks(id);
            return Ok(response);

        }
    }
}
