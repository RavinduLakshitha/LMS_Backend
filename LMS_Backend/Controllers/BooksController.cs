using LMS_Backend.Data;
using LMS_Backend.Models;
using LMS_Backend.Models.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this using directive

namespace LMS_Backend.Controllers
{

    // localhost;xxxx/api/books
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BooksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(dbContext.Set<Book>().ToList()); // Use Set<Book>() instead of Books
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = dbContext.Set<Book>().Find(id); // Use Set<Book>() instead of Books

            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto addBookDto)
        {
            var bookEntity = new Book()
            {
                Name = addBookDto.Name,
                Author = addBookDto.Author,
                Description = addBookDto.Description,
            };

            dbContext.Set<Book>().Add(bookEntity); // Use Set<Book>() instead of Books
            dbContext.SaveChanges();

            return Ok(bookEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateBook(Guid id, UpdateBookDto updateBookDto)
        {
            var book = dbContext.Set<Book>().Find(id); // Use Set<Book>() instead of Books
            if (book is null)
            {
                return NotFound();
            }
            book.Name = updateBookDto.Name;
            book.Author = updateBookDto.Author;
            book.Description = updateBookDto.Description;
            dbContext.SaveChanges();
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = dbContext.Set<Book>().Find(id); // Use Set<Book>() instead of Books
            if (book is null)
            {
                return NotFound();
            }
            dbContext.Set<Book>().Remove(book); // Use Set<Book>() instead of Books
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
