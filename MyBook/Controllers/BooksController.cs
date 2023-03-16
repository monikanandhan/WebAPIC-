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
    public class BooksController : ControllerBase
    {
        public BooksService booksservice;
       public BooksController(BooksService _booksservice)
        {
            booksservice = _booksservice;
        }

        [HttpPost]
        public IActionResult AddBookWithAuthor(BooksVM book)
        {
            booksservice.CreateNewBooksWithUthors(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
           var getall= booksservice.GetAllBooks();
            return Ok(getall);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookbyID(int id)
        {
           var result= booksservice.GetById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooks(int id,BooksVM book)
        {
           var results= booksservice.UpdateBooks(id, book);
            return Ok(results);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooks(int id)
        {
           var demos= booksservice.Deletebooks(id);
            return Ok(demos);
        }
    }
}
