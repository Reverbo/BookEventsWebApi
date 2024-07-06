using WebBookApi.Domain;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System;

namespace WebBookApi.WebApi
{
    public class BookDbContext : DbContext
    {  

        public BookDbContext(DbContextOptions<BookDbContext> options) :base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
