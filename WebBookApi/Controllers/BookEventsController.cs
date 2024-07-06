using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebBookApi.Domain;
using WebBookApi.WebApi;
using System.Threading.Tasks;
using WebBookApi.Domain.NovaPasta1;

namespace WebBookApi.Controllers
{
    [Route("api/book-events")]
    [ApiController]
    public class BookEventsController : ControllerBase
    {
        private BookDbContext _context;

        public BookEventsController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var idBook = Guid.Parse(id);
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == idBook);
            if (book == null)
            {
                return NotFound();

            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromForm] BookDTO book) 
        {
            var books = new Book()
            {
                Id = Guid.NewGuid(),
                NameBook = book.NameBook,
                Author = book.Author,
                DescriptionBook = book.DescriptionBook,
                YearCreate = book.YearCreate,
                IsDeleted = book.IsDeleted
            };
            _context.Books.Add(books);
            await _context.SaveChangesAsync();
            return Ok(books);
        }

        [HttpPut("id")]
        public ActionResult Update(string id, Book input) 
        {
            var idBook = Guid.Parse(id);
            var book = _context.Books.SingleOrDefault(x => x.Id == idBook);

            if (book == null)
            {
                return NotFound();
            }
            input.Id = idBook;
            book.Update(input);
            _context.SaveChanges();
            return Ok(input);
        }

        [HttpDelete("id")]
        public ActionResult Delete(string id) 
        {
            var idBook = Guid.Parse(id);
            var book = _context.Books.SingleOrDefault(x => x.Id == idBook);
            if (book == null)
            {
                return NotFound();

            }
            book.Delete();
            _context.SaveChanges();
            return NoContent();
        }
    }
}
