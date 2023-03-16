using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Model
{
    public class BooksDbContext:DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySQL("ConnectionStrings:DefaultConnection");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasOne(b => b.books).WithMany(ba => ba.Book_Author).HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(b => b.author).WithMany(ba => ba.Book_Author).HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Books> bookSample { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Publisher> publisher { get; set; }
        public DbSet<Book_Author> book_Author { get; set; }
    }
}
