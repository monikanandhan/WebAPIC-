using MyBook.Model;
using MyBook.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.service
{
    public class AuthorService
    {
        public BooksDbContext booksContext;
        public AuthorService(BooksDbContext _booksContext)
        {
            booksContext = _booksContext;
        }

        public void AddAuthor(AuthorVM authors)
        {
            var _author = new Author()
            {
                FullName = authors.FullName
        };
            booksContext.author.Add(_author);
            booksContext.SaveChanges();
       
        }
        public AuthorwithBooksVM GetAuthorWithBooks(int id)
        {
            var _author = booksContext.author.Where(n => n.Id == id).Select(n => new AuthorwithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Author.Select(n => n.books.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
