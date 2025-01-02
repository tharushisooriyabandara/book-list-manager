using BookManagerAPI.Models;
using BookManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book object is null.");
            }

            var addedBook = _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var isUpdated = _bookService.UpdateBook(id, book);
            if (!isUpdated) return NotFound();

            var updatedBook = _bookService.GetBookById(id);
            return Ok(updatedBook);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (!_bookService.DeleteBook(id)) return NotFound();
            return NoContent();
        }
    }
}
