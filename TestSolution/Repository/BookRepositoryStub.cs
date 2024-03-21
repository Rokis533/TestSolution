using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Models;

namespace TestSolution.Repository
{
    public class BookRepositoryStub : IBookRepository
    {

        public BookRepositoryStub()
        {
        }

        public Book GetBook(int id) => new Book() { Id = 1, Author = "John", Title = "Harry" };

        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>
            {
                new Book() { Id = 1, Author = "John", Title = "Harry" },
                new Book() { Id = 2, Author = "Rokas", Title = "C#" },
                new Book() { Id = 3, Author = "Paul", Title = "Course of life" }
            };
            return books;
        }

        public void AddBook(Book book)
        {

        }

        public void UpdateBook(Book book)
        {
        }

        public void DeleteBook(int id)
        {
        }
    }
}
