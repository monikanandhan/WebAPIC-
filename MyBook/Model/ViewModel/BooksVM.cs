using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Model.ViewModel
{
    public class BooksVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genere { get; set; }
        public string CoverUrl { get; set; }
        public int PublisherId { get; set; }
        public List<int> AuthorId { get; set; }
    }
    public class BooksVMWithAuthor
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genere { get; set; }
        public string CoverUrl { get; set; }
        public string  PublisherName { get; set; }
        public List<string> AuthorName { get; set; }
    }
}
