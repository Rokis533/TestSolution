using TestSolution.Models;
using TestSolution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }
        public string GetBookName(int id)
        {
            var book = GetBook(id);
            var title = GetBookTitle(book);


            //var api = new GetFromApi();
            //var data = api.Get("google.com");


            return title;
        }
        public virtual string GetBookTitle(Book book)
        {
            return book.Title + ".DR";
        }
    }
}
