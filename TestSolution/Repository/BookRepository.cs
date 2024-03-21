using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Models;

namespace TestSolution.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public Book GetBook(int id) => _context.Books.FirstOrDefault(b => b.Id == id);

        public IEnumerable<Book> GetAllBooks() => _context.Books;

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var bookExist = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (bookExist != null)
            {
                bookExist = book;
                _context.SaveChanges();
            }

        }

        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book != null)
                _context.Remove(book);
        }
    }
}
