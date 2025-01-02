using BookManagerAPI.Models;

namespace BookManagerAPI.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new();

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book AddBook(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            return book;
        }

        public bool UpdateBook(int id, Book updatedBook)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null) return false;

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.ISBN = updatedBook.ISBN;
            existingBook.PublicationDate = updatedBook.PublicationDate;

            return true;
        }

        public bool DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;

            _books.Remove(book);
            return true;
        }
    }
}
