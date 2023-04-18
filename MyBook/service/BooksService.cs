using MyBook.Model;
using MyBook.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.service
{
    public class BooksService
    {
        public BooksDbContext booksContext;
        public BooksService(BooksDbContext _booksContext)
        {
            booksContext = _booksContext;
        }

        
        public void CreateNewBooksWithUthors(BooksVM book)
        {
            var NewBook = new Books()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genere = book.Genere,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId=book.PublisherId,
                
            };
            booksContext.bookSample.Add(NewBook);
            booksContext.SaveChanges();
            foreach(var id in book.AuthorId)
            {
                var _bookAuthor = new Book_Author()
                {
                    BookId = NewBook.Id,
                    AuthorId = id
                };
                booksContext.book_Author.Add(_bookAuthor);
                booksContext.SaveChanges();
            }

        }

        public List<Books> GetAllBooks() => booksContext.bookSample.ToList();

        public BooksVMWithAuthor GetById(int id)
        {
            var _bookwithAuthor = booksContext.bookSample.Where(n=>n.Id==id).Select(book => new BooksVMWithAuthor()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genere = book.Genere,
                CoverUrl = book.CoverUrl,

                PublisherName = book.publisher.Name,
                AuthorName = book.Book_Author.Select(n => n.author.FullName).ToList()
            }).FirstOrDefault();
            return _bookwithAuthor;
        }

        public Books UpdateBooks(int id,BooksVM book)
        {
           var BookId= booksContext.bookSample.FirstOrDefault(x=>x.Id==id);
            if(BookId!=null)
            {
                BookId.Title = book.Title;
                BookId.Description = book.Description;
                BookId.IsRead = book.IsRead;
                BookId.DateRead = book.IsRead ? book.DateRead.Value : null;
                BookId.Rate = book.IsRead ? book.Rate.Value : null;
                BookId.Genere = book.Genere;
                BookId.CoverUrl = book.CoverUrl;
                BookId.DateAdded = DateTime.Now;
            }
            booksContext.SaveChanges();
            return BookId;
        }
        public List<Books> Deletebooks(int id)
        {
            var ID=booksContext.bookSample.First(x => x.Id == id);
            booksContext.bookSample.Remove(ID);
            booksContext.SaveChanges();
            var books=booksContext.bookSample.ToList();
            return books;
           
        }
     
    }
}
