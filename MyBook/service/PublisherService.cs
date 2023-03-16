using MyBook.Model;
using MyBook.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.service
{
    public class PublisherService
    {
        public BooksDbContext booksContext;
        public PublisherService(BooksDbContext _booksDbContext)
        {
            booksContext = _booksDbContext;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var publish = new Publisher()
            {
                Name = publisher.Name
            };
            booksContext.publisher.Add(publish);
            booksContext.SaveChanges();
    }
        public PublisherWithAuthorBook GetPublisherData(int id)
        {
            var _publish = booksContext.publisher.Where(n => n.Id == id).Select(n => new PublisherWithAuthorBook()
            {
                Name = n.Name,
                BookAuthors = n.booksDemo.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Author.Select(n => n.author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publish;
        }

        public void DeletePublisherById(int id)
        {
           var DemoId= booksContext.publisher.FirstOrDefault(x => x.Id == id);
            booksContext.publisher.Remove(DemoId);
            booksContext.SaveChanges();
        }
    }
}
