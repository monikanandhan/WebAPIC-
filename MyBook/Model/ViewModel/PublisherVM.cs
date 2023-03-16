using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Model.ViewModel
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    public class PublisherWithAuthorBook
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
       
    }
    public class BookAuthorVM
        {

        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
