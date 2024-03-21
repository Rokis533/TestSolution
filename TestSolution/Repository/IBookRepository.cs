using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Models;

namespace TestSolution.Repository
{
    public interface IBookRepository
    {
        Book GetBook(int id);
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }

}
