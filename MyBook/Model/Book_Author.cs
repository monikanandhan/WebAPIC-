using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Model
{
    public class Book_Author
    {
        public int Id { get; set; }

        //Navigation Property
        public int BookId { get; set; }
        public Books books { get; set; }
        public int AuthorId { get; set; }
        public Author author { get; set; }
    }
}
