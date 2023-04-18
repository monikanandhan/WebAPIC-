using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBook.Model
{
    public class BooksSampleData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {   
            using(var ServiceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<BooksDbContext>();
                if(!context.bookSample.Any())
                {
                    context.bookSample.AddRange(new Books
                    {
                        Title = "First Book",
                        Description = " Fisrt Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genere = "Fiction",
                        
                        CoverUrl = "https.....",
                        DateAdded = DateTime.Now
                    }, new Books
                    {
                        Title = "Second Book",
                        Description = " Second Book Description",
                        IsRead = false,
                        DateRead = DateTime.Now.AddDays(-8),
                        Rate = 3,
                        Genere = "Biography",
                       
                        CoverUrl = "https.....",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }
                    

            }

        }
    }
}
