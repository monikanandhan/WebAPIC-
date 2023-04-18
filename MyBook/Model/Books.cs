using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Model
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genere { get; set; }
       
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        //Navigation Property
        public Publisher publisher { get; set; }
        public int PublisherId { get; set; } //Foreign Key

        public List<Book_Author> Book_Author { get; set; }

    }
}
